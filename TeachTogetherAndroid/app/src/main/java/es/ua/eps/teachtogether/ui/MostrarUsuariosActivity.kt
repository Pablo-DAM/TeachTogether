package es.ua.eps.teachtogether.ui

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.SearchView
import android.widget.Toast
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.Observer
import es.ua.eps.teachtogether.adapters.UsuariosAdapter
import es.ua.eps.teachtogether.databinding.ActivityMostrarUsuariosBinding
import es.ua.eps.teachtogether.models.perfil.PerfilResponse
import es.ua.eps.teachtogether.models.usuario.UsuarioResponse
import es.ua.eps.teachtogether.models.usuarioPerfil.UsuarioPerfil
import es.ua.eps.teachtogether.services.ApiService
import es.ua.eps.teachtogether.services.RetrofitInstance
import kotlinx.coroutines.CompletableDeferred
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response

class MostrarUsuariosActivity : AppCompatActivity() {
    private lateinit var binding: ActivityMostrarUsuariosBinding
    private lateinit var usuariosAdapter: UsuariosAdapter
    private val usuariosLiveData = MutableLiveData<List<UsuarioPerfil>>()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityMostrarUsuariosBinding.inflate(layoutInflater)
        setContentView(binding.root)
        usuariosAdapter = UsuariosAdapter(this, emptyList())
        binding.listView.adapter = usuariosAdapter
        binding.volverButton.setOnClickListener {
            val intent = Intent (this,MenuActivity::class.java)
            startActivity(intent)
        }


        binding.searchView.setOnQueryTextListener(object : SearchView.OnQueryTextListener {
            override fun onQueryTextSubmit(query: String?): Boolean {

                query?.let {
                    filterUsers(it)
                }
                return false
            }

            override fun onQueryTextChange(newText: String?): Boolean {

                newText?.let {
                    filterUsers(it)
                }
                return false
            }
        })

        usuariosLiveData.observe(this, Observer { usuarios ->
            usuariosAdapter = UsuariosAdapter(this, usuarios)
            binding.listView.adapter = usuariosAdapter
        })

        cargarDatos()

        binding.listView.setOnItemClickListener { _, _, position, _ ->
            val usuario = usuariosAdapter.getItem(position) as UsuarioPerfil
            val intent = Intent(this, EscribirMensajeActivity::class.java).apply {
                putExtra("usuario", usuario.usuario)
                putExtra("nombre", usuario.nombre)
                putExtra("apellidos", usuario.apellidos)
                putExtra("idUsuario", usuario.idUsuario)
            }
            startActivity(intent)
        }
    }

    override fun onActivityResult(requestCode: Int, resultCode: Int, data: Intent?) {
        super.onActivityResult(requestCode, resultCode, data)
        if (requestCode == UsuariosAdapter.REQUEST_CODE_ENVIAR_MENSAJE && resultCode == RESULT_OK) {
            cargarDatos()
        }
    }

    private fun cargarDatos() {
        CoroutineScope(Dispatchers.Main).launch {
            val usuarios = getUsuarios()
            val perfiles = getPerfiles()
            val usuarioPerfilList = combineData(usuarios, perfiles)
            usuariosLiveData.value = usuarioPerfilList
        }
    }

    private suspend fun getUsuarios(): List<UsuarioResponse> {
        val deferred = CompletableDeferred<List<UsuarioResponse>>()
        RetrofitInstance.apiService.getUsuarios().enqueue(object : Callback<List<UsuarioResponse>> {
            override fun onResponse(
                call: Call<List<UsuarioResponse>>,
                response: Response<List<UsuarioResponse>>
            ) {
                if (response.isSuccessful && response.body() != null) {
                    deferred.complete(response.body()!!)
                } else {
                    Toast.makeText(
                        this@MostrarUsuariosActivity,
                        "Error al obtener datos de usuarios",
                        Toast.LENGTH_SHORT
                    ).show()
                    deferred.complete(emptyList())
                }
            }

            override fun onFailure(call: Call<List<UsuarioResponse>>, t: Throwable) {
                Toast.makeText(
                    this@MostrarUsuariosActivity,
                    "Error: ${t.message}",
                    Toast.LENGTH_SHORT
                ).show()
                deferred.complete(emptyList())
            }
        })
        return deferred.await()
    }

    private suspend fun getPerfiles(): List<PerfilResponse> {
        val deferred = CompletableDeferred<List<PerfilResponse>>()
        RetrofitInstance.apiService.getPerfiles().enqueue(object : Callback<List<PerfilResponse>> {
            override fun onResponse(
                call: Call<List<PerfilResponse>>,
                response: Response<List<PerfilResponse>>
            ) {
                if (response.isSuccessful && response.body() != null) {
                    deferred.complete(response.body()!!)
                } else {
                    Toast.makeText(
                        this@MostrarUsuariosActivity,
                        "Error al obtener datos de perfiles",
                        Toast.LENGTH_SHORT
                    ).show()
                    deferred.complete(emptyList())
                }
            }

            override fun onFailure(call: Call<List<PerfilResponse>>, t: Throwable) {
                Toast.makeText(
                    this@MostrarUsuariosActivity,
                    "Error: ${t.message}",
                    Toast.LENGTH_SHORT
                ).show()
                deferred.complete(emptyList())
            }
        })
        return deferred.await()
    }

    private fun combineData(
        usuarios: List<UsuarioResponse>,
        perfiles: List<PerfilResponse>
    ): List<UsuarioPerfil> {
        val combinedList = mutableListOf<UsuarioPerfil>()
        for (perfil in perfiles) {
            val usuario = usuarios.find { it.idUsuario == perfil.idUsuario.idUsuario }
            if (usuario != null) {
                combinedList.add(
                    UsuarioPerfil(
                        usuario.usuario,
                        perfil.nombre,
                        perfil.apellidos,
                        usuario.idUsuario
                    )
                )
            }
        }
        return combinedList.sortedWith(compareBy({ it.nombre }, { it.apellidos }))
    }

    private fun filterUsers(query: String) {
        val filteredList = usuariosLiveData.value?.filter {
            it.usuario.contains(query, ignoreCase = true) ||
                    it.nombre.contains(query, ignoreCase = true) ||
                    it.apellidos.contains(query, ignoreCase = true)
        }
        filteredList?.let {
            usuariosAdapter = UsuariosAdapter(this, it)
            binding.listView.adapter = usuariosAdapter
        }
    }
}