package es.ua.eps.teachtogether.adapters

import android.content.Context
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup

import android.widget.BaseAdapter
import android.widget.TextView
import es.ua.eps.teachtogether.R

import es.ua.eps.teachtogether.models.autoevaluacionUsuarioModulo.AutoevaluacionUsuarioModuloResponse
import es.ua.eps.teachtogether.models.autoevaluaciones.AutoevaluacionesResponse

class AutoevaluacionAdapter(
    private val context: Context,
    private val autoevaluaciones: List<AutoevaluacionesResponse>
) : BaseAdapter() {

    override fun getCount(): Int {
        return autoevaluaciones.size
    }

    override fun getItem(position: Int): Any {
        return autoevaluaciones[position]
    }

    override fun getItemId(position: Int): Long {
        return position.toLong()
    }

    override fun getView(position: Int, convertView: View?, parent: ViewGroup?): View {
        val view: View = convertView ?: LayoutInflater.from(context).inflate(R.layout.item_autoevaluacion, parent, false)
        val tituloTextView: TextView = view.findViewById(R.id.tituloAutoevaluacion)
        val autoevaluacion = autoevaluaciones[position]
        tituloTextView.text = autoevaluacion.titulo
        return view
    }
}