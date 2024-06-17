package es.ua.eps.teachtogether.adapters

import android.content.Context
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.BaseAdapter
import android.widget.TextView
import es.ua.eps.teachtogether.R
import es.ua.eps.teachtogether.models.preguntaRespuesta.PreguntaConRespuestas
import es.ua.eps.teachtogether.models.preguntas.PreguntasResponse

class PreguntaConRespuestasAdapter(
    private val context: Context,
    private val preguntasConRespuestas: List<PreguntaConRespuestas>
) : BaseAdapter() {

    override fun getCount(): Int = preguntasConRespuestas.size

    override fun getItem(position: Int): PreguntaConRespuestas = preguntasConRespuestas[position]

    override fun getItemId(position: Int): Long = preguntasConRespuestas[position].pregunta.idPregunta.toLong()

    override fun getView(position: Int, convertView: View?, parent: ViewGroup?): View {
        val view: View = convertView ?: LayoutInflater.from(context).inflate(R.layout.item_pregunta, parent, false)

        val preguntaTextView: TextView = view.findViewById(R.id.Pregunta)
        val respuestaTextView: TextView = view.findViewById(R.id.Respuesta)

        val preguntaConRespuestas = getItem(position)

        preguntaTextView.text = preguntaConRespuestas.pregunta.enunciadoPregunta
        val respuesta = preguntaConRespuestas.respuestas.firstOrNull()
        respuestaTextView.text =  respuesta?.textoRespuesta ?: "Sin respuesta"

        return view
    }
}