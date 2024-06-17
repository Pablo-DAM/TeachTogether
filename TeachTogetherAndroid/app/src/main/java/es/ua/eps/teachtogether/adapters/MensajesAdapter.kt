package es.ua.eps.teachtogether.adapters

import android.content.Context
import android.content.Intent
import android.graphics.Typeface
import android.text.Spannable
import android.text.SpannableString
import android.text.style.StyleSpan
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.BaseAdapter
import android.widget.TextView
import es.ua.eps.teachtogether.R
import es.ua.eps.teachtogether.models.mensajes.MensajesResponse
import es.ua.eps.teachtogether.models.perfil.PerfilResponse
import es.ua.eps.teachtogether.ui.DetalleMensajeActivity

class MensajesAdapter(
    private val context: Context,
    private val mensajesList: List<MensajesResponse>,
    private val perfilesCache: Map<Int, PerfilResponse>
) : BaseAdapter() {

    override fun getCount(): Int {
        return mensajesList.size
    }

    override fun getItem(position: Int): Any {
        return mensajesList[position]
    }

    override fun getItemId(position: Int): Long {
        return position.toLong()
    }

    override fun getView(position: Int, convertView: View?, parent: ViewGroup?): View {
        val view: View = convertView ?: LayoutInflater.from(context).inflate(R.layout.item_mensaje, parent, false)

        val emisorTextView: TextView = view.findViewById(R.id.emisorTextView)
        val destinatarioTextView: TextView = view.findViewById(R.id.destinatarioTextView)
        val mensajeTextView: TextView = view.findViewById(R.id.mensajeTextView)
        val fechaTextView: TextView = view.findViewById(R.id.fechaTextView)

        val mensaje = mensajesList[position]
        val emisorPerfil = perfilesCache[mensaje.idCreador.idUsuario.toInt()]
        val destinatarioPerfil = perfilesCache[mensaje.idReceptor.idUsuario.toInt()]

        emisorTextView.text ="${emisorPerfil?.nombre} ${emisorPerfil?.apellidos}"
        destinatarioTextView.text = "${destinatarioPerfil?.nombre} ${destinatarioPerfil?.apellidos}"
        mensajeTextView.text =  mensaje.texto.substring(0, minOf(70, mensaje.texto.length))
        fechaTextView.text =  mensaje.fechaCreaccion


        view.setOnClickListener {
            val intent = Intent(context, DetalleMensajeActivity::class.java).apply {
                putExtra("mensajeId", mensaje.idMensaje)
                putExtra("emisor", "${emisorPerfil?.nombre} ${emisorPerfil?.apellidos}")
                putExtra("destinatario", "${destinatarioPerfil?.nombre} ${destinatarioPerfil?.apellidos}")
                putExtra("mensaje", mensaje.texto)
                putExtra("fecha", mensaje.fechaCreaccion)
            }
            context.startActivity(intent)
        }

        return view
    }

    private fun formatText(label: String, value: String): SpannableString {
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