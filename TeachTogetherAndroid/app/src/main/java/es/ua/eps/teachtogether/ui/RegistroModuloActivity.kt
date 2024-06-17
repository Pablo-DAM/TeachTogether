package es.ua.eps.teachtogether.ui

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Toast
import es.ua.eps.teachtogether.databinding.ActivityRegistroModuloBinding
import es.ua.eps.teachtogether.models.userInfo.UserID
import es.ua.eps.teachtogether.models.usuarioModulo.usuarioModuloRequest
import es.ua.eps.teachtogether.services.RetrofitInstance
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response

class RegistroModuloActivity : AppCompatActivity() {
    private lateinit var binding: ActivityRegistroModuloBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityRegistroModuloBinding.inflate(layoutInflater)
        setContentView(binding.root)
        val id_usuario = UserID.userID
        val id_modulo = intent.getIntExtra("id_modulo", 0)
        val codigo = intent.getStringExtra("codigo")

        binding.buttonRegistrarse.setOnClickListener {
            val textoIngresado = binding.editTextCodigoModulo.text.toString()
            if (textoIngresado == codigo) {
                val request = usuarioModuloRequest(id_alumno = id_usuario!!, id_modulo = id_modulo)
                val apiService = RetrofitInstance.apiService
                val call = apiService.postUsuarioModulo(request)
                call.enqueue(object : Callback<Void> {
                    override fun onResponse(call: Call<Void>, response: Response<Void>) {
                        if (response.isSuccessful) {
                            Toast.makeText(
                                applicationContext,
                                "Registro exitoso en el módulo",
                                Toast.LENGTH_SHORT
                            ).show()
                            val intent = Intent (this@RegistroModuloActivity,ModulosActivity::class.java)
                            startActivity(intent)
                        } else {
                            Toast.makeText(
                                applicationContext,
                                "Error al registrar en el módulo",
                                Toast.LENGTH_SHORT
                            ).show()
                        }
                    }

                    override fun onFailure(call: Call<Void>, t: Throwable) {
                        Toast.makeText(
                            applicationContext,
                            "Error de comunicación con el servidor",
                            Toast.LENGTH_SHORT
                        ).show()
                    }
                })
            } else {
                Toast.makeText(applicationContext, "Código incorrecto", Toast.LENGTH_SHORT).show()
            }
        }

        binding.buttonVolver.setOnClickListener {
            finish()
        }
    }
}