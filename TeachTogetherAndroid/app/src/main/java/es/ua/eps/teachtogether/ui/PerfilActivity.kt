package es.ua.eps.teachtogether.ui

import android.content.Intent
import android.os.Bundle
import android.text.Editable
import android.widget.DatePicker
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import es.ua.eps.teachtogether.databinding.ActivityPerfilBinding
import es.ua.eps.teachtogether.models.perfil.PerfilPUTRequest
import es.ua.eps.teachtogether.models.perfil.PerfilResponse
import es.ua.eps.teachtogether.models.userInfo.PerfilID
import es.ua.eps.teachtogether.models.userInfo.UserID
import es.ua.eps.teachtogether.services.RetrofitInstance
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response
import java.text.SimpleDateFormat
import java.util.Calendar
import java.util.Locale

class PerfilActivity : AppCompatActivity() {
    private lateinit var binding: ActivityPerfilBinding
    private var fechaNacimiento: String? = null

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityPerfilBinding.inflate(layoutInflater)
        setContentView(binding.root)

        // Configurar DatePicker para inicializar fechaNacimiento
        val datePicker: DatePicker = binding.datePickerFechaNacimiento

        datePicker.init(datePicker.year, datePicker.month, datePicker.dayOfMonth) { _, year, monthOfYear, dayOfMonth ->
            val selectedDate = Calendar.getInstance()
            selectedDate.set(year, monthOfYear, dayOfMonth)
            val dateStr = "$year-${
                (monthOfYear + 1).toString().padStart(2, '0')
            }-${dayOfMonth.toString().padStart(2, '0')}"

            fechaNacimiento = dateStr
        }

        RetrofitInstance.apiService.getPerfil(UserID.userID!!)
            .enqueue(object : Callback<PerfilResponse> {
                override fun onResponse(
                    call: Call<PerfilResponse>,
                    response: Response<PerfilResponse>
                ) {
                    if (response.isSuccessful) {
                        val perfilResponse = response.body()
                        PerfilID.perfilID = perfilResponse!!.idPerfil
                        binding.editTextNombre.text =
                            Editable.Factory.getInstance().newEditable(perfilResponse.nombre)
                        binding.editTextApellidos.text =
                            Editable.Factory.getInstance().newEditable(perfilResponse.apellidos)

                        val calendar = perfilResponse.fechaNacimiento.toCalendar()

                        binding.datePickerFechaNacimiento.updateDate(
                            calendar.get(Calendar.YEAR),
                            calendar.get(Calendar.MONTH),
                            calendar.get(Calendar.DAY_OF_MONTH)
                        )
                    } else {
                        Toast.makeText(
                            this@PerfilActivity,
                            "Error recuperando el perfil",
                            Toast.LENGTH_SHORT
                        ).show()
                    }
                }

                override fun onFailure(call: Call<PerfilResponse>, t: Throwable) {
                    Toast.makeText(
                        this@PerfilActivity,
                        "Fallo en la conexión: ${t.message}",
                        Toast.LENGTH_SHORT
                    ).show()
                }
            })

        binding.buttonVolver.setOnClickListener {
            val intent = Intent(this, MenuActivity::class.java)
            startActivity(intent)
        }

        binding.buttonGuardar.setOnClickListener {
            if (binding.editTextNombre.text.isNotEmpty() && binding.editTextApellidos.text.isNotEmpty()) {
                val idUsuario = UserID.userID
                val nombre = binding.editTextNombre.text.toString()
                val apellidos = binding.editTextApellidos.text.toString()
                val idPerfil = PerfilID.perfilID

                val perfilPut = PerfilPUTRequest(
                    idUsuario!!, nombre, apellidos, fechaNacimiento.toString(), idPerfil!!
                )

                RetrofitInstance.apiService.putPerfil(perfilPut)
                    .enqueue(object : Callback<PerfilResponse> {
                        override fun onResponse(
                            call: Call<PerfilResponse>,
                            response: Response<PerfilResponse>
                        ) {
                            if (response.isSuccessful) {
                                Toast.makeText(
                                    this@PerfilActivity,
                                    "Perfil actualizado correctamente",
                                    Toast.LENGTH_SHORT
                                ).show()
                            } else {
                                Toast.makeText(
                                    this@PerfilActivity,
                                    "Error actualizando el perfil",
                                    Toast.LENGTH_SHORT
                                ).show()
                            }
                        }

                        override fun onFailure(call: Call<PerfilResponse>, t: Throwable) {
                            Toast.makeText(
                                this@PerfilActivity,
                                "Fallo en la conexión: ${t.message}",
                                Toast.LENGTH_SHORT
                            ).show()
                        }
                    })
            } else {
                Toast.makeText(
                    this@PerfilActivity,
                    "Los campos Nombre y Apellidos son obligatorios",
                    Toast.LENGTH_SHORT
                ).show()
            }
        }
        binding.buttonCambiarContra.setOnClickListener {
            val intent = Intent(this, CambiarPasswordActivity::class.java)
            startActivity(intent)
        }
    }

    fun String.toCalendar(): Calendar {
        val format = SimpleDateFormat("yyyy-MM-dd", Locale.getDefault())
        val date = format.parse(this)
        return Calendar.getInstance().apply {
            time = date!!
        }
    }
}