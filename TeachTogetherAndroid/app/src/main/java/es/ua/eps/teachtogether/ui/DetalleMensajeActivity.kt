package es.ua.eps.teachtogether.ui

import android.content.Intent
import android.graphics.Typeface
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.text.Spannable
import android.text.SpannableString
import android.text.style.StyleSpan
import android.widget.Toast
import es.ua.eps.teachtogether.R
import es.ua.eps.teachtogether.databinding.ActivityDetalleMensajeBinding
import es.ua.eps.teachtogether.services.RetrofitInstance
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response

class DetalleMensajeActivity : AppCompatActivity() {
    private lateinit var binding: ActivityDetalleMensajeBinding
    private var mensajeId: Int = -1

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityDetalleMensajeBinding.inflate(layoutInflater)
        setContentView(binding.root)


        mensajeId = intent.getIntExtra("mensajeId", -1)
        val emisor = intent.getStringExtra("emisor")
        val destinatario = intent.getStringExtra("destinatario")
        val mensaje = intent.getStringExtra("mensaje")
        val fecha = intent.getStringExtra("fecha")


        binding.emisorTextView.text = emisor
        binding.destinatarioTextView.text =  destinatario
        binding.mensajeTextView.text =mensaje
        binding.fechaTextView.text = fecha

        binding.Eliminar.setOnClickListener {
            if (mensajeId != -1) {
                deleteMensaje(mensajeId)
            }
        }
        binding.Responder.setOnClickListener {
            Toast.makeText(this, "Funcionalidad en Desarrollo", Toast.LENGTH_SHORT).show()
        }
        binding.Volver.setOnClickListener {
            val intent = Intent(this, MensajesActivity::class.java)
            startActivity(intent)
        }
    }

    private fun deleteMensaje(id: Int) {
        RetrofitInstance.apiService.deleteMensajeByID(id).enqueue(object : Callback<Void> {
            override fun onResponse(call: Call<Void>, response: Response<Void>) {
                if (response.isSuccessful) {
                    Toast.makeText(this@DetalleMensajeActivity, "Mensaje eliminado", Toast.LENGTH_SHORT).show()
                    val intent = Intent(this@DetalleMensajeActivity, MensajesActivity::class.java)
                    startActivity(intent)
                    finish()
                } else {
                    Toast.makeText(this@DetalleMensajeActivity, "Error al eliminar el mensaje", Toast.LENGTH_SHORT).show()
                }
            }

            override fun onFailure(call: Call<Void>, t: Throwable) {
                Toast.makeText(this@DetalleMensajeActivity, "Error en la conexión", Toast.LENGTH_SHORT).show()
            }
        })
    }

    private fun formatText(label: String, value: String?): SpannableString {
        val spannableString = SpannableString("$label$value")
        spannableString.setSpan(
            StyleSpan(Typeface.BOLD),
            0,
            label.length,
            Spannable.SPAN_EXCLUSIVE_EXCLUSIVE
        )
        return spannableString
    }
}