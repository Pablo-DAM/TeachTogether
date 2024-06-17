package es.ua.eps.teachtogether.ui

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.ImageView
import android.widget.Toast
import androidx.appcompat.widget.TooltipCompat
import es.ua.eps.teachtogether.databinding.ActivityCambiarPasswordBinding
import es.ua.eps.teachtogether.models.userInfo.UserID
import es.ua.eps.teachtogether.models.usuario.UsuarioPUTRequest
import es.ua.eps.teachtogether.models.usuario.UsuarioResponse
import es.ua.eps.teachtogether.services.RetrofitInstance
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response
import java.util.regex.Pattern
class CambiarPasswordActivity : AppCompatActivity() {
    private lateinit var binding: ActivityCambiarPasswordBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityCambiarPasswordBinding.inflate(layoutInflater)
        setContentView(binding.root)

        val infoIconPassword: ImageView = binding.infoIconPassword
        val tooltipText =
            "La contraseña debe contener al menos una letra mayúscula, un número y un símbolo especial."

        TooltipCompat.setTooltipText(infoIconPassword, tooltipText)

        infoIconPassword.setOnClickListener {
            Toast.makeText(this, tooltipText, Toast.LENGTH_LONG).show()
        }

        binding.buttonRegistrar.setOnClickListener {
            val password = binding.editTextPassword.text.toString()
            val repetirPassword = binding.editTextRepetirPassword.text.toString()
            if (validarFormulario(password, repetirPassword)) {
                RetrofitInstance.apiService.getUsuarioByID(UserID.userID!!)
                    .enqueue(object : Callback<UsuarioResponse> {
                        override fun onResponse(
                            call: Call<UsuarioResponse>,
                            response: Response<UsuarioResponse>
                        ) {
                            if (response.isSuccessful) {
                                val usuarioResponse = response.body()
                                if (usuarioResponse != null) {
                                    val usuarioPutRequest = UsuarioPUTRequest(
                                        UserID.userID!!,
                                        usuarioResponse.usuario,
                                        "alumno",
                                        password

                                    )

                                    RetrofitInstance.apiService.putUsuario(usuarioPutRequest)
                                        .enqueue(object : Callback<Void> {
                                            override fun onResponse(
                                                call: Call<Void>,
                                                response: Response<Void>
                                            ) {
                                                if (response.isSuccessful) {
                                                    Toast.makeText(
                                                        this@CambiarPasswordActivity,
                                                        "Se ha cambiado la contraseña correctamente",
                                                        Toast.LENGTH_SHORT
                                                    ).show()
                                                    val intent = Intent(this@CambiarPasswordActivity, PerfilActivity::class.java)
                                                    startActivity(intent)
                                                } else {
                                                    Toast.makeText(
                                                        this@CambiarPasswordActivity,
                                                        "Error al cambiar la contraseña",
                                                        Toast.LENGTH_SHORT
                                                    ).show()
                                                }
                                            }

                                            override fun onFailure(call: Call<Void>, t: Throwable) {
                                                Toast.makeText(
                                                    this@CambiarPasswordActivity,
                                                    "Fallo en la conexión: ${t.message}",
                                                    Toast.LENGTH_SHORT
                                                ).show()
                                            }
                                        })
                                } else {
                                    Toast.makeText(
                                        this@CambiarPasswordActivity,
                                        "Error: Usuario no encontrado",
                                        Toast.LENGTH_SHORT
                                    ).show()
                                }
                            } else {
                                Toast.makeText(
                                    this@CambiarPasswordActivity,
                                    "Error al recuperar usuario",
                                    Toast.LENGTH_SHORT
                                ).show()
                            }
                        }

                        override fun onFailure(call: Call<UsuarioResponse>, t: Throwable) {
                            Toast.makeText(
                                this@CambiarPasswordActivity,
                                "Fallo en la conexión: ${t.message}",
                                Toast.LENGTH_SHORT
                            ).show()
                        }
                    })
            }
        }
        binding.buttonVolver.setOnClickListener{
            val intent = Intent (this,PerfilActivity::class.java)
            startActivity(intent)
        }
    }

    private fun validarFormulario(password: String, repetirPassword: String): Boolean {
        if (password.isEmpty() || repetirPassword.isEmpty()) {
            Toast.makeText(
                this,
                "Rellene los campos de las contraseñas",
                Toast.LENGTH_SHORT
            ).show()
            return false
        }

        if (password != repetirPassword) {
            Toast.makeText(this, "Las contraseñas no coinciden", Toast.LENGTH_SHORT).show()
            return false
        }

        val passwordPattern =
            Pattern.compile("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)(?=.*[@\$!%*?&\\-])[A-Za-z\\d@\$!%*?&\\-]{8,}\$")

        if (!passwordPattern.matcher(password).matches()) {
            Toast.makeText(
                this,
                "La contraseña debe contener al menos una mayúscula, un número y un símbolo especial",
                Toast.LENGTH_SHORT
            ).show()
            return false
        }

        return true
    }
}