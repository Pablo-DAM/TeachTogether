package es.ua.eps.teachtogether.ui

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Toast
import es.ua.eps.teachtogether.R
import es.ua.eps.teachtogether.databinding.ActivityEscribirMensajeBinding
import es.ua.eps.teachtogether.databinding.ActivityMostrarUsuariosBinding
import es.ua.eps.teachtogether.models.mensajes.MensajeRequest
import es.ua.eps.teachtogether.models.userInfo.UserID
import es.ua.eps.teachtogether.services.RetrofitInstance
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response
import java.sql.Timestamp
import java.text.SimpleDateFormat
import java.util.Date


class EscribirMensajeActivity : AppCompatActivity() {
    private lateinit var binding: ActivityEscribirMensajeBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityEscribirMensajeBinding.inflate(layoutInflater)
        setContentView(binding.root)
        val usuario = intent.getStringExtra("usuario")
        val nombre = intent.getStringExtra("nombre")
        val apellidos = intent.getStringExtra("apellidos")
        val idUsuario = intent.getIntExtra("idUsuario", -1)
        binding.usuarioTextView.text = usuario
        binding.nombreTextView.text = nombre
        binding.apellidosTextView.text = apellidos
        binding.buttonEnviar.setOnClickListener {
            val mensaje = binding.mensajeEditText.text.toString()
            if (mensaje.isNotEmpty()) {
                enviarMensaje(idUsuario, mensaje, nombre, apellidos)
            } else {
                Toast.makeText(this, "Por favor, escribe un mensaje.", Toast.LENGTH_SHORT).show()
            }
        }
        binding.buttonVolver.setOnClickListener{
            val intent = Intent(this,MostrarUsuariosActivity::class.java)
            startActivity(intent)
        }
    }
    private fun enviarMensaje(idUsuario: Int, mensaje: String, nombre: String?, apellidos: String?) {
        val fecha = obtenerFechaActualFormateada()
        val mensajeRequest = MensajeRequest(UserID.userID!!, mensaje, fecha, idUsuario)
        RetrofitInstance.apiService.postMensaje(mensajeRequest).enqueue(object : Callback<Void> {
            override fun onResponse(call: Call<Void>, response: Response<Void>) {
                if (response.isSuccessful) {
                    Toast.makeText(this@EscribirMensajeActivity, "Mensaje enviado exitosamente", Toast.LENGTH_SHORT).show()
                    val resultIntent = Intent().apply {
                        putExtra("mensaje", mensaje)
                        putExtra("fecha", fecha)
                        putExtra("nombre", nombre)
                        putExtra("apellidos", apellidos)
                    }
                    setResult(RESULT_OK, resultIntent)
                    val intent= Intent(this@EscribirMensajeActivity,MensajesActivity::class.java)
                    intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP or Intent.FLAG_ACTIVITY_NEW_TASK)
                    startActivity(intent)
                    finish()
                } else {
                    Toast.makeText(this@EscribirMensajeActivity, "Error al enviar mensaje", Toast.LENGTH_SHORT).show()
                }
            }

            override fun onFailure(call: Call<Void>, t: Throwable) {
                Toast.makeText(this@EscribirMensajeActivity, "Error: ${t.message}", Toast.LENGTH_SHORT).show()
            }
        })
    }

    private fun obtenerFechaActualFormateada(): String {
        val sdf = SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss")
        return sdf.format(Date())
    }
}