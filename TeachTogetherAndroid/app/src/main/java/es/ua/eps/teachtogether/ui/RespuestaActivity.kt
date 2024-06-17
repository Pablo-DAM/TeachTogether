package es.ua.eps.teachtogether.ui

import android.app.Activity
import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.text.Editable
import android.util.Log
import android.view.View
import android.widget.EditText
import android.widget.Toast
import es.ua.eps.teachtogether.R
import es.ua.eps.teachtogether.databinding.ActivityRespuestaBinding
import es.ua.eps.teachtogether.models.autoevaluacionUsuario.AutoevaluacionUsuarioPUTRequest
import es.ua.eps.teachtogether.models.respuestas.RespuestaRequest
import es.ua.eps.teachtogether.models.userInfo.UserID
import es.ua.eps.teachtogether.services.RetrofitInstance
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response
import java.text.SimpleDateFormat
import java.util.Date
import java.util.Locale

class RespuestaActivity : AppCompatActivity() {
    private lateinit var binding: ActivityRespuestaBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityRespuestaBinding.inflate(layoutInflater)
        setContentView(binding.root)

        val pregunta = intent.getStringExtra("pregunta")
        val respuesta = intent.getStringExtra("respuesta")
        val idPregunta = intent.getIntExtra("id_pregunta", 0)
        val nombre = intent.getStringExtra("nombre")
        val idAutoevaluacion = intent.getIntExtra("id_autoevaluacion", 0)
        println("ID AUTO: "+idAutoevaluacion)
        binding.pregunta.text = pregunta

        if (respuesta == "Sin respuesta") {
            binding.respuesta.isEnabled = true
            binding.respuesta.text = null
            binding.Enviar.visibility = View.VISIBLE
        } else {
            binding.respuesta.setText(respuesta)
            binding.respuesta.isEnabled = false
            binding.Enviar.visibility = View.GONE
        }

        binding.Enviar.setOnClickListener {
            val textoRespuesta = binding.respuesta.text.toString().trim()

            if (textoRespuesta.isNotBlank()) {
                val respuestaRequest = RespuestaRequest(textoRespuesta, idPregunta,UserID.userID!!)
                enviarRespuesta(respuestaRequest, nombre!!)
                enviarAutoevaluacionUsuario(idAutoevaluacion)
            } else {
                Toast.makeText(this, "Por favor ingrese una respuesta", Toast.LENGTH_SHORT).show()
            }
        }

        binding.buttonVolver.setOnClickListener {
            finish()
        }
    }

    private fun enviarRespuesta(respuestaRequest: RespuestaRequest, nombre: String) {
        RetrofitInstance.apiService.postRespuesta(respuestaRequest).enqueue(object : Callback<Void> {
            override fun onResponse(call: Call<Void>, response: Response<Void>) {
                if (response.isSuccessful) {
                    Toast.makeText(this@RespuestaActivity, "Respuesta enviada exitosamente", Toast.LENGTH_SHORT).show()

                    val intent = Intent()
                    setResult(Activity.RESULT_OK, intent)
                    finish()
                } else {
                    Toast.makeText(this@RespuestaActivity, "Error al enviar la respuesta", Toast.LENGTH_SHORT).show()
                }
            }

            override fun onFailure(call: Call<Void>, t: Throwable) {
                Toast.makeText(this@RespuestaActivity, "Error en la conexión", Toast.LENGTH_SHORT).show()
            }
        })
    }

    private fun enviarAutoevaluacionUsuario(idAutoevaluacion: Int) {
        val idAlumno = UserID.userID
        val fechaRealizacion = Date()
        val dateFormat = SimpleDateFormat("yyyy-MM-dd", Locale.getDefault())
        val fechaRealizacionFormatted = dateFormat.format(fechaRealizacion)

        val autoevaluacionUsuarioPUTRequest = AutoevaluacionUsuarioPUTRequest(
            id_autoevaluacion = idAutoevaluacion,
            id_alumno = idAlumno!!,
            fecha_realizacion = fechaRealizacionFormatted
        )

        RetrofitInstance.apiService.putAutoevaluacionUsuario(autoevaluacionUsuarioPUTRequest).enqueue(object : Callback<Void> {
            override fun onResponse(call: Call<Void>, response: Response<Void>) {
                if (response.isSuccessful) {
                    Toast.makeText(this@RespuestaActivity, "Autoevaluación enviada exitosamente", Toast.LENGTH_SHORT).show()
                } else {
                    Toast.makeText(this@RespuestaActivity, "Error al enviar la autoevaluación", Toast.LENGTH_SHORT).show()
                }
            }

            override fun onFailure(call: Call<Void>, t: Throwable) {
                Toast.makeText(this@RespuestaActivity, "Error en la conexión", Toast.LENGTH_SHORT).show()
            }
        })
    }
}