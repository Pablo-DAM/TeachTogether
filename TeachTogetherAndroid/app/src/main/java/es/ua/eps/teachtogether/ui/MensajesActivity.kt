package es.ua.eps.teachtogether.ui

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.ListView
import android.widget.SearchView
import android.widget.Toast
import es.ua.eps.teachtogether.R
import es.ua.eps.teachtogether.adapters.MensajesAdapter
import es.ua.eps.teachtogether.databinding.ActivityMensajesBinding
import es.ua.eps.teachtogether.databinding.ActivityMenuBinding
import es.ua.eps.teachtogether.models.mensajes.MensajesResponse
import es.ua.eps.teachtogether.models.perfil.PerfilResponse
import es.ua.eps.teachtogether.models.userInfo.UserID
import es.ua.eps.teachtogether.services.RetrofitInstance
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response
class MensajesActivity : AppCompatActivity() {
    private lateinit var binding: ActivityMensajesBinding
    private lateinit var listView: ListView
    private val perfilesCache = mutableMapOf<Int, PerfilResponse>()
    private var mensajesList: List<MensajesResponse> = listOf()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityMensajesBinding.inflate(layoutInflater)
        setContentView(binding.root)

        listView = binding.listView
        binding.volverButton.setOnClickListener {
            val intent = Intent(this, MenuActivity::class.java)
            startActivity(intent)
            finish()
        }
        binding.escribirMensaje.setOnClickListener {
            val intent = Intent(this, MostrarUsuariosActivity::class.java)
            startActivity(intent)
        }

        // Configuración del SearchView
        binding.searchViewMensajes.setOnQueryTextListener(object : SearchView.OnQueryTextListener {
            override fun onQueryTextSubmit(query: String?): Boolean {
                query?.let {
                    filterMessages(it)
                }
                return false
            }

            override fun onQueryTextChange(newText: String?): Boolean {
                newText?.let {
                    filterMessages(it)
                }
                return false
            }
        })

        fetchMensajes()
    }

    private fun fetchMensajes() {
        RetrofitInstance.apiService.getMensajes()
            .enqueue(object : Callback<List<MensajesResponse>> {
                override fun onResponse(
                    call: Call<List<MensajesResponse>>,
                    response: Response<List<MensajesResponse>>
                ) {
                    if (response.isSuccessful) {
                        val mensajesListResponse = response.body()
                        if (mensajesListResponse != null) {
                            val userId = UserID.userID
                            mensajesList = mensajesListResponse.filter {
                                it.idCreador.idUsuario == userId || it.idReceptor.idUsuario == userId
                            }.sortedByDescending { it.fechaCreaccion } //Ordenar por fecha de creación
                            fetchPerfiles(mensajesList)
                        }
                    } else {
                        Toast.makeText(
                            this@MensajesActivity,
                            "Error en la respuesta de la API",
                            Toast.LENGTH_SHORT
                        ).show()
                    }
                }

                override fun onFailure(call: Call<List<MensajesResponse>>, t: Throwable) {
                    Toast.makeText(
                        this@MensajesActivity,
                        "Error en la llamada a la API",
                        Toast.LENGTH_SHORT
                    ).show()
                }
            })
    }

    private fun fetchPerfiles(mensajesList: List<MensajesResponse>) {
        val userIds = mensajesList.flatMap { listOf(it.idCreador.idUsuario.toInt(), it.idReceptor.idUsuario.toInt()) }.distinct()
        var pendingProfiles = userIds.size

        userIds.forEach { userId ->
            if (!perfilesCache.containsKey(userId)) {
                RetrofitInstance.apiService.getPerfilByUsuarioID(userId)
                    .enqueue(object : Callback<PerfilResponse> {
                        override fun onResponse(call: Call<PerfilResponse>, response: Response<PerfilResponse>) {
                            if (response.isSuccessful) {
                                response.body()?.let { perfil ->
                                    perfilesCache[userId] = perfil
                                }
                            }
                            pendingProfiles -= 1
                            checkAndSetupAdapter(mensajesList, pendingProfiles)
                        }

                        override fun onFailure(call: Call<PerfilResponse>, t: Throwable) {
                            pendingProfiles -= 1
                            Toast.makeText(this@MensajesActivity, "Error en la llamada a la API para obtener el perfil", Toast.LENGTH_SHORT).show()
                            checkAndSetupAdapter(mensajesList, pendingProfiles)
                        }
                    })
            } else {
                pendingProfiles -= 1
                checkAndSetupAdapter(mensajesList, pendingProfiles)
            }
        }
    }

    private fun checkAndSetupAdapter(mensajesList: List<MensajesResponse>, pendingProfiles: Int) {
        if (pendingProfiles == 0) {
            val adapter = MensajesAdapter(this@MensajesActivity, mensajesList, perfilesCache)
            listView.adapter = adapter
        }
    }

    private fun filterMessages(query: String) {
        val filteredList = mensajesList.filter { mensaje ->
            val emisorPerfil = perfilesCache[mensaje.idCreador.idUsuario.toInt()]
            val destinatarioPerfil = perfilesCache[mensaje.idReceptor.idUsuario.toInt()]
            val emisor = "${emisorPerfil?.nombre} ${emisorPerfil?.apellidos}"
            val destinatario = "${destinatarioPerfil?.nombre} ${destinatarioPerfil?.apellidos}"

            emisor.contains(query, ignoreCase = true) ||
                    destinatario.contains(query, ignoreCase = true) ||
                    mensaje.texto.contains(query, ignoreCase = true) ||
                    mensaje.fechaCreaccion.contains(query, ignoreCase = true)
        }
        val adapter = MensajesAdapter(this@MensajesActivity, filteredList, perfilesCache)
        listView.adapter = adapter
    }
}