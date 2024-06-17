package es.ua.eps.teachtogether.adapters

import android.content.Context
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.BaseAdapter
import android.widget.TextView
import es.ua.eps.teachtogether.R
import es.ua.eps.teachtogether.models.respuestas.RespuestaResponse

/*class RespuestasAdapter(
    private val context: Context,
    private val respuestas: List<RespuestaResponse>
) : BaseAdapter() {

    override fun getCount(): Int = respuestas.size

    override fun getItem(position: Int): RespuestaResponse = respuestas[position]

    override fun getItemId(position: Int): Long = respuestas[position].idRespuesta.toLong()

    override fun getView(position: Int, convertView: View?, parent: ViewGroup?): View {
        val view: View = convertView ?: LayoutInflater.from(context).inflate(R.layout.item_pregunta, parent, false)
        val preguntaTextView: TextView = view.findViewById(R.id.Pregunta)
        val respuestaTextView: TextView = view.findViewById(R.id.Respuesta)
        val respuesta = getItem(position)
        preguntaTextView.text = respuesta.idPregunta.enunciadoPregunta
        respuestaTextView.text = respuesta.textoRespuesta
        return view
    }
}*/