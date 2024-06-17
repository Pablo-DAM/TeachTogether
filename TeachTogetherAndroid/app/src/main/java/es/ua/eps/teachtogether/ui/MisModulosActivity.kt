package es.ua.eps.teachtogether.ui

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import android.view.View
import es.ua.eps.teachtogether.R
import es.ua.eps.teachtogether.adapters.UsuarioModuloAdapter

import es.ua.eps.teachtogether.databinding.ActivityMisModulosBinding
import es.ua.eps.teachtogether.models.userInfo.UserID
import es.ua.eps.teachtogether.models.usuarioModulo.UsuarioModuloResponse
import es.ua.eps.teachtogether.services.RetrofitInstance
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response

class MisModulosActivity : AppCompatActivity() {

    private lateinit var binding: ActivityMisModulosBinding
    private lateinit var adapter: UsuarioModuloAdapter
    private var fromMenu = false

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityMisModulosBinding.inflate(layoutInflater)
        setContentView(binding.root)

        val idUsuario = UserID.userID
        fromMenu = intent.getBooleanExtra("menu", false)

        if (idUsuario != null) {
            fetchUsuariosModulos(idUsuario)
        } else {
            Log.e("MisModulosActivity", "Error: idUsuario es nulo")
            finish()
        }

        binding.lblSelecciona.visibility = if (fromMenu) View.VISIBLE else View.GONE

        binding.listViewModulos.setOnItemClickListener { parent, view, position, id ->
            val selectedModulo = adapter.getItem(position) as UsuarioModuloResponse
            val intent = if (fromMenu) {
                Intent(this, AutoevaluacionesActivity::class.java).apply {
                    putExtra("nombre", selectedModulo.idModulo.nombre)
                    putExtra("idMod", selectedModulo.idModulo.idModulo)
                }
            } else {
                Intent(this, DetallesModuloActivity::class.java).apply {
                    putExtra("nombre", selectedModulo.idModulo.nombre)
                    putExtra("horario", selectedModulo.idModulo.horario)
                    putExtra("horas", selectedModulo.idModulo.horas)
                    putExtra("profesorId", selectedModulo.idModulo.idProfesor.idUsuario)
                    putExtra("dias", selectedModulo.idModulo.dias)
                    putExtra("id_modulo", selectedModulo.idModulo.idModulo)
                    putExtra("codigo", selectedModulo.idModulo.codigo)
                    putExtra("misModulos", true)
                }
            }
            startActivity(intent)
        }

        binding.buttonVolver.setOnClickListener {
           val intent = Intent (this,ModulosActivity::class.java)
            startActivity(intent)
        }
    }

    private fun fetchUsuariosModulos(idUsuario: Int) {
        val call = RetrofitInstance.apiService.getAllUsuariosModulos()
        call.enqueue(object : Callback<List<UsuarioModuloResponse>> {
            override fun onResponse(
                call: Call<List<UsuarioModuloResponse>>,
                response: Response<List<UsuarioModuloResponse>>
            ) {
                if (response.isSuccessful) {
                    val usuarioModuloList = response.body()
                    val filteredList = usuarioModuloList?.filter { it.idAlumno.idUsuario == idUsuario } ?: emptyList()
                    adapter = UsuarioModuloAdapter(this@MisModulosActivity, filteredList, fromMenu)
                    binding.listViewModulos.adapter = adapter
                } else {
                    Log.e("MisModulosActivity", "Error al obtener los módulos: ${response.code()}")
                }
            }

            override fun onFailure(call: Call<List<UsuarioModuloResponse>>, t: Throwable) {
                Log.e("MisModulosActivity", "Error en la conexión", t)
            }
        })
    }
}