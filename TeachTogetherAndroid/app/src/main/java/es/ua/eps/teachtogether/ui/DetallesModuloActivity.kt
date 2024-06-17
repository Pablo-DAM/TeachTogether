package es.ua.eps.teachtogether.ui

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import android.view.View
import android.widget.Toast
import androidx.appcompat.app.AlertDialog
import es.ua.eps.teachtogether.databinding.ActivityDetallesModuloBinding
import es.ua.eps.teachtogether.models.perfil.PerfilResponse
import es.ua.eps.teachtogether.models.userInfo.UserID
import es.ua.eps.teachtogether.models.usuarioModulo.UsuarioModuloResponse
import es.ua.eps.teachtogether.services.RetrofitInstance
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.Job
import kotlinx.coroutines.cancel
import kotlinx.coroutines.launch
import kotlinx.coroutines.withContext
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response

class DetallesModuloActivity : AppCompatActivity() {
    private lateinit var binding: ActivityDetallesModuloBinding
    private val scope = CoroutineScope(Dispatchers.Main + Job())

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityDetallesModuloBinding.inflate(layoutInflater)
        setContentView(binding.root)

        val nombre = intent.getStringExtra("nombre")
        val horario = intent.getStringExtra("horario")
        val horas = intent.getIntExtra("horas", 0)
        val profesorId = intent.getIntExtra("profesorId", 0)
        val dias = intent.getStringExtra("dias")
        val id_modulo = intent.getIntExtra("id_modulo", 0)
        val codigo = intent.getStringExtra("codigo")
        val misModulos = intent.getBooleanExtra("misModulos", false)

        binding.tvNombre.text = nombre
        binding.tvHorario.text = horario
        binding.tvHoras.text = horas.toString()
        binding.tvDias.text = dias

        binding.buttonGuardar.visibility = View.GONE
        binding.buttonEliminar.visibility = View.GONE

        if (misModulos) {
            binding.buttonEliminar.visibility = View.VISIBLE
        } else {
            binding.buttonEliminar.visibility = View.GONE
        }

        fetchProfesor(profesorId)

        scope.launch {
            fetchUsuarioModulo(UserID.userID!!, id_modulo)
        }

        binding.buttonEliminar.setOnClickListener {
            showDeleteConfirmationDialog(id_modulo)
        }

        binding.buttonVolver.setOnClickListener {
            if(misModulos){
                val intent = Intent (this,MisModulosActivity::class.java)
                startActivity(intent)
            }else{
                val intent = Intent (this,ModulosActivity::class.java)
                startActivity(intent)
            }

        }

        binding.buttonGuardar.setOnClickListener {
            val intent = Intent(this, RegistroModuloActivity::class.java)
            intent.putExtra("id_modulo", id_modulo)
            intent.putExtra("codigo", codigo)
            startActivity(intent)
        }
    }

    private fun showDeleteConfirmationDialog(idModulo: Int) {
        val builder = AlertDialog.Builder(this)
        builder.setTitle("Confirmación")
        builder.setMessage("¿Estás seguro de que deseas eliminar este módulo?")
        builder.setPositiveButton("Sí") { dialog, _ ->
            deleteUsuarioModulo(idModulo)
            dialog.dismiss()
        }
        builder.setNegativeButton("No") { dialog, _ ->
            dialog.dismiss()
        }
        val dialog = builder.create()
        dialog.show()
    }

    private fun deleteUsuarioModulo(idModulo: Int) {
        val call = RetrofitInstance.apiService.deleteUsuarioModulo(UserID.userID!!, idModulo)
        call.enqueue(object : Callback<Void> {
            override fun onResponse(call: Call<Void>, response: Response<Void>) {
                if (response.isSuccessful) {
                    Toast.makeText(this@DetallesModuloActivity, "Módulo eliminado con éxito", Toast.LENGTH_SHORT).show()
                    val intent = Intent(this@DetallesModuloActivity, MisModulosActivity::class.java)
                    intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP or Intent.FLAG_ACTIVITY_NEW_TASK)
                    startActivity(intent)
                    finish()
                } else {
                    Toast.makeText(this@DetallesModuloActivity, "Error al eliminar el módulo", Toast.LENGTH_SHORT).show()
                }
            }

            override fun onFailure(call: Call<Void>, t: Throwable) {
                Toast.makeText(this@DetallesModuloActivity, "Error de red", Toast.LENGTH_SHORT).show()
            }
        })
    }

    private fun fetchProfesor(profesorId: Int) {
        val call = RetrofitInstance.apiService.getPerfilByUsuarioID(profesorId)
        call.enqueue(object : Callback<PerfilResponse> {
            override fun onResponse(call: Call<PerfilResponse>, response: Response<PerfilResponse>) {
                if (response.isSuccessful) {
                    val perfil = response.body()
                    if (perfil != null) {
                        binding.tvProfesor.text = "${perfil.nombre} ${perfil.apellidos}"
                    }
                }
            }

            override fun onFailure(call: Call<PerfilResponse>, t: Throwable) {

            }
        })
    }

    private suspend fun fetchUsuarioModulo(usuarioId: Int, moduloId: Int) {
        withContext(Dispatchers.IO) {
            try {
                val call = RetrofitInstance.apiService.getUsuariosModulos(usuarioId, moduloId)
                val response = call.execute()
                withContext(Dispatchers.Main) {
                    if (response.isSuccessful) {
                        val respuesta = response.body()
                        if (respuesta != null) {
                            val isRegistered = respuesta.idModulo.idModulo == moduloId && respuesta.idAlumno.idUsuario == usuarioId
                            binding.buttonGuardar.visibility = if (isRegistered) View.GONE else View.VISIBLE
                        } else {
                            binding.buttonGuardar.visibility = View.VISIBLE
                        }
                    } else if (response.code() == 404) {
                        Log.d("DetallesModuloActivity", "Usuario no registrado en el módulo (404)")
                        binding.buttonGuardar.visibility = View.VISIBLE
                    } else {
                        Toast.makeText(this@DetallesModuloActivity, "Error al obtener datos del usuario", Toast.LENGTH_SHORT).show()
                    }
                }
            } catch (e: Exception) {
                withContext(Dispatchers.Main) {
                    Toast.makeText(this@DetallesModuloActivity, "Error al obtener datos del usuario", Toast.LENGTH_SHORT).show()
                }
            }
        }
    }

    override fun onDestroy() {
        super.onDestroy()
        scope.cancel()
    }
}
