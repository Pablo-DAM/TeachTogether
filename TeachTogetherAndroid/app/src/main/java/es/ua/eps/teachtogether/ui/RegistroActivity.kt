package es.ua.eps.teachtogether.ui

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.DatePicker
import android.widget.ImageView
import android.widget.Toast
import androidx.appcompat.widget.TooltipCompat
import es.ua.eps.teachtogether.databinding.ActivityRegistroBinding
import es.ua.eps.teachtogether.models.perfil.PerfilRequest
import es.ua.eps.teachtogether.models.registro.RegistroRequest
import es.ua.eps.teachtogether.models.registro.RegistroResponse
import es.ua.eps.teachtogether.services.RetrofitInstance
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response
import java.util.Calendar
import java.util.regex.Pattern

class RegistroActivity : AppCompatActivity() {

    private lateinit var binding: ActivityRegistroBinding
    private var fechaNacimiento: String? = null
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityRegistroBinding.inflate(layoutInflater)
        setContentView(binding.root)
        // Configurar el tooltip para el ícono de información sobre la contraseña
        val infoIconPassword: ImageView = binding.infoIconPassword
        val tooltipText =
            "La contraseña debe tener al menos 8 carácteres y contener al menos una letra mayúscula, un número y un símbolo especial."

        TooltipCompat.setTooltipText(infoIconPassword, tooltipText)

        infoIconPassword.setOnClickListener {
            Toast.makeText(this, tooltipText, Toast.LENGTH_LONG).show()
        }

        val datePicker: DatePicker = binding.datePickerFechaNacimiento

        datePicker.setOnDateChangedListener { _, year, monthOfYear, dayOfMonth ->
            val selectedDate = Calendar.getInstance()
            selectedDate.set(year, monthOfYear, dayOfMonth)
            val dateStr = "$year-${
                (monthOfYear + 1).toString().padStart(2, '0')
            }-${dayOfMonth.toString().padStart(2, '0')}"


            fechaNacimiento = dateStr
        }

        binding.buttonVolver.setOnClickListener {
            val volver = Intent(this, LoginActivity::class.java)
            startActivity(volver)
        }

        binding.buttonRegistrar.setOnClickListener {
            val usuario = binding.editTextUsuario.text.toString()
            val nombre = binding.editTextNombre.text.toString()
            val apellidos = binding.editTextApellidos.text.toString()
            val password = binding.editTextPassword.text.toString()
            val repetirPassword = binding.editTextRepetirPassword.text.toString()

            if (validarFormulario(usuario, nombre, apellidos, password, repetirPassword)) {
                val registroRequest = RegistroRequest(usuario, password, "alumno")

                RetrofitInstance.apiService.registro(registroRequest)
                    .enqueue(object : Callback<RegistroResponse> {
                        override fun onResponse(
                            call: Call<RegistroResponse>,
                            response: Response<RegistroResponse>
                        ) {
                            if (response.isSuccessful) {
                                val registroResponse = response.body()
                                if (registroResponse != null) {

                                    Toast.makeText(
                                        this@RegistroActivity,
                                        "Registro exitoso",
                                        Toast.LENGTH_SHORT
                                    ).show()
                                    //Crear solicitud de perfil
                                    val perfilPostRequest = PerfilRequest(
                                        id_usuario = registroResponse.idUsuario,
                                        nombre = nombre,
                                        apellidos = apellidos,
                                        fecha_nacimiento = fechaNacimiento.toString()

                                    )
                                    RetrofitInstance.apiService.postPerfil(perfilPostRequest)
                                        .enqueue(object : Callback<Void> {
                                            override fun onResponse(
                                                call: Call<Void>,
                                                response: Response<Void>
                                            ) {
                                                if (response.isSuccessful) {
                                                    val volver = Intent(
                                                        this@RegistroActivity,
                                                        LoginActivity::class.java
                                                    )
                                                    startActivity(volver)
                                                }
                                            }

                                            override fun onFailure(call: Call<Void>, t: Throwable) {
                                                Toast.makeText(
                                                    this@RegistroActivity,
                                                    "Fallo en la conexión: ${t.message}",
                                                    Toast.LENGTH_SHORT
                                                ).show()
                                            }
                                        })
                                }
                            } else {
                                Toast.makeText(
                                    this@RegistroActivity,
                                    "Error en el registro: ${response.message()}",
                                    Toast.LENGTH_SHORT
                                ).show()
                            }
                        }

                        override fun onFailure(call: Call<RegistroResponse>, t: Throwable) {
                            Toast.makeText(
                                this@RegistroActivity,
                                "Fallo en la conexión: ${t.message}",
                                Toast.LENGTH_SHORT
                            ).show()
                        }
                    })
            }
        }
    }

    private fun validarFormulario(
        usuario: String,
        nombre: String,
        apellidos: String,
        password: String,
        repetirPassword: String
    ): Boolean {
        if (usuario.isEmpty() || nombre.isEmpty() || apellidos.isEmpty() || password.isEmpty() || repetirPassword.isEmpty()) {
            Toast.makeText(
                this,
                "Todos los campos excepto la fecha de nacimiento son obligatorios",
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
                "La contraseña debe tener 8 caracteres y contener al menos una mayúscula, un número y un símbolo especial",
                Toast.LENGTH_SHORT
            ).show()
            return false
        }

        return true
    }
}