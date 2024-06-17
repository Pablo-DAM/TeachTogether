package es.ua.eps.teachtogether.adapters

import android.app.Activity
import android.content.Context
import android.content.Intent
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.BaseAdapter
import androidx.recyclerview.widget.RecyclerView
import es.ua.eps.teachtogether.databinding.ItemUsuarioBinding
import es.ua.eps.teachtogether.models.usuario.UsuarioResponse
import es.ua.eps.teachtogether.models.usuarioPerfil.UsuarioPerfil
import es.ua.eps.teachtogether.ui.EscribirMensajeActivity

class UsuariosAdapter(private val context: Context, private val usuarios: List<UsuarioPerfil>) : BaseAdapter() {

    override fun getCount(): Int = usuarios.size

    override fun getItem(position: Int): Any = usuarios[position]

    override fun getItemId(position: Int): Long = position.toLong()

    override fun getView(position: Int, convertView: View?, parent: ViewGroup?): View {
        val binding: ItemUsuarioBinding
        val view: View

        if (convertView == null) {
            binding = ItemUsuarioBinding.inflate(LayoutInflater.from(context), parent, false)
            view = binding.root
            view.tag = binding
        } else {
            binding = convertView.tag as ItemUsuarioBinding
            view = convertView
        }

        val usuarioPerfil = usuarios[position]
        binding.usuarioTextView.text = usuarioPerfil.usuario
        binding.nombreTextView.text = usuarioPerfil.nombre
        binding.apellidosTextView.text = usuarioPerfil.apellidos

        return view
    }

    companion object {
        const val REQUEST_CODE_ENVIAR_MENSAJE = 1
    }
}