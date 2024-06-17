package es.ua.eps.teachtogether.ui

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Toast
import es.ua.eps.teachtogether.databinding.ActivityLoginBinding
import es.ua.eps.teachtogether.models.login.LoginRequest
import es.ua.eps.teachtogether.models.login.LoginResponse
import es.ua.eps.teachtogether.models.userInfo.UserID
import es.ua.eps.teachtogether.models.usuario.UsuarioResponse
import es.ua.eps.teachtogether.security.AuthToken
import es.ua.eps.teachtogether.services.RetrofitInstance
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response

class LoginActivity : AppCompatActivity() {
    private lateinit var binding: ActivityLoginBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityLoginBinding.inflate(layoutInflater)
        setContentView(binding.root)

        binding.btnIniciarSesion.setOnClickListener {
            val usuario = binding.txtUsuario.text.toString()
            val password = binding.txtContrasena.text.toString()
            val loginRequest = LoginRequest(usuario, password, "alumno")

            RetrofitInstance.apiService.login(loginRequest)
                .enqueue(object : Callback<LoginResponse> {
                    override fun onResponse(
                        call: Call<LoginResponse>,
                        response: Response<LoginResponse>
                    ) {
                        if (response.isSuccessful) {
                            val loginResponse = response.body()
                            if (loginResponse != null) {
                                val token = loginResponse.token.token
                                val id = loginResponse.id
                                UserID.userID = id
                                AuthToken.token = token

                                verificarRolUsuario(id)
                            }
                        } else {
                            Toast.makeText(
                                this@LoginActivity,
                                "Error en el login: ${response.message()}",
                                Toast.LENGTH_SHORT
                            ).show()
                        }
                    }

                    override fun onFailure(call: Call<LoginResponse>, t: Throwable) {
                        Toast.makeText(
                            this@LoginActivity,
                            "Fallo en la conexión: ${t.message}",
                            Toast.LENGTH_SHORT
                        ).show()
                    }
                })
        }
        binding.btnRegistrarse.setOnClickListener {
            val intent = Intent(this, RegistroActivity::class.java)
            startActivity(intent)
        }
    }

    private fun verificarRolUsuario(id: Int) {
        RetrofitInstance.apiService.getUsuarioByID(id)
            .enqueue(object : Callback<UsuarioResponse> {
                override fun onResponse(
                    call: Call<UsuarioResponse>,
                    response: Response<UsuarioResponse>
                ) {
                    if (response.isSuccessful) {
                        val usuarioResponse = response.body()
                        if (usuarioResponse != null && usuarioResponse.rol == "alumno") {
                            Toast.makeText(
                                this@LoginActivity,
                                "Usuario verificado. Acceso permitido.",
                                Toast.LENGTH_SHORT
                            ).show()
                            val enviarMenu = Intent(this@LoginActivity, MenuActivity::class.java)
                            startActivity(enviarMenu)
                        } else {
                            Toast.makeText(
                                this@LoginActivity,
                                "Acceso denegado. El usuario no tiene el rol de alumno.",
                                Toast.LENGTH_SHORT
                            ).show()
                        }
                    } else {
                        Toast.makeText(
                            this@LoginActivity,
                            "Error al verificar el rol del usuario.",
                            Toast.LENGTH_SHORT
                        ).show()
                    }
                }

                override fun onFailure(call: Call<UsuarioResponse>, t: Throwable) {
                    Toast.makeText(
                        this@LoginActivity,
                        "Fallo en la conexión: ${t.message}",
                        Toast.LENGTH_SHORT
                    ).show()
                }
            })
    }
}