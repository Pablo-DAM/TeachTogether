package es.ua.eps.teachtogether.adapters

import android.content.Context
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.BaseAdapter
import es.ua.eps.teachtogether.databinding.ItemModuloBinding

import es.ua.eps.teachtogether.models.usuarioModulo.UsuarioModuloResponse

class UsuarioModuloAdapter(
    private val context: Context,
    private val dataSource: List<UsuarioModuloResponse>,
    private val fromMenu: Boolean
) : BaseAdapter() {

    override fun getCount(): Int {
        return dataSource.size
    }

    override fun getItem(position: Int): Any {
        return dataSource[position]
    }

    override fun getItemId(position: Int): Long {
        return position.toLong()
    }

    override fun getView(position: Int, convertView: View?, parent: ViewGroup?): View {
        val binding: ItemModuloBinding
        val view: View

        if (convertView == null) {
            binding = ItemModuloBinding.inflate(LayoutInflater.from(context), parent, false)
            view = binding.root
            view.tag = binding
        } else {
            binding = convertView.tag as ItemModuloBinding
            view = convertView
        }

        val usuarioModulo = getItem(position) as UsuarioModuloResponse

        binding.tvNombre.text = usuarioModulo.idModulo.nombre
        binding.tvHorario.text = usuarioModulo.idModulo.horario
        binding.tvHoras.text = usuarioModulo.idModulo.horas.toString()
        binding.tvDias.text = usuarioModulo.idModulo.dias

        //Ocultar o mostrar elementos segun el valor de fromMenu
        if (fromMenu) {
            binding.tvHoras.visibility = View.GONE
            binding.tvDias.visibility = View.GONE
        } else {
            binding.tvHoras.visibility = View.VISIBLE
            binding.tvDias.visibility = View.VISIBLE
        }

        return view
    }
}