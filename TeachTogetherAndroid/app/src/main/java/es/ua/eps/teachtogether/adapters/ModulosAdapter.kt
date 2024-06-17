package es.ua.eps.teachtogether.adapters

import android.content.Context
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.BaseAdapter
import android.widget.Filter
import android.widget.Filterable
import android.widget.TextView
import es.ua.eps.teachtogether.R
import es.ua.eps.teachtogether.databinding.ItemModuloBinding
import es.ua.eps.teachtogether.models.modulos.ModulosResponse
class ModuloAdapter(private val context: Context, private var modulos: List<ModulosResponse>) : BaseAdapter(),
    Filterable {

    private var filteredModulos: List<ModulosResponse> = modulos

    override fun getCount(): Int {
        return filteredModulos.size
    }

    override fun getItem(position: Int): Any {
        return filteredModulos[position]
    }

    override fun getItemId(position: Int): Long {
        return filteredModulos[position].idModulo
    }

    override fun getView(position: Int, convertView: View?, parent: ViewGroup?): View {
        val binding: ItemModuloBinding
        var itemView: View? = convertView

        if (itemView == null) {
            binding = ItemModuloBinding.inflate(LayoutInflater.from(context), parent, false)
            itemView = binding.root
            itemView.tag = binding
        } else {
            binding = itemView.tag as ItemModuloBinding
        }

        val modulo = filteredModulos[position]

        binding.tvNombre.text = modulo.nombre
        binding.tvHorario.text = modulo.horario
        binding.tvHoras.text = modulo.horas.toString()
        binding.tvDias.text = modulo.dias

        return itemView
    }

    override fun getFilter(): Filter {
        return object : Filter() {
            override fun performFiltering(constraint: CharSequence?): FilterResults {
                val query = constraint?.toString()?.lowercase()?.trim()
                val results = FilterResults()

                results.values = if (query.isNullOrEmpty()) {
                    modulos
                } else {
                    modulos.filter {
                        it.nombre.lowercase().contains(query) ||
                                it.horario.lowercase().contains(query) ||
                                it.dias.lowercase().contains(query)
                    }
                }

                return results
            }

            @Suppress("UNCHECKED_CAST")
            override fun publishResults(constraint: CharSequence?, results: FilterResults?) {
                filteredModulos = results?.values as List<ModulosResponse>
                notifyDataSetChanged()
            }
        }
    }
}