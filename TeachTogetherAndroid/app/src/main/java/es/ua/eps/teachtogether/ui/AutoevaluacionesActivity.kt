package es.ua.eps.teachtogether.ui

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import android.widget.SearchView
import android.widget.Toast
import es.ua.eps.teachtogether.R
import es.ua.eps.teachtogether.adapters.AutoevaluacionAdapter
import es.ua.eps.teachtogether.databinding.ActivityAutoevaluacionesBinding
import es.ua.eps.teachtogether.models.autoevaluacionUsuario.AutoevaluacionUsuarioResponse
import es.ua.eps.teachtogether.models.autoevaluacionUsuarioModulo.AutoevaluacionUsuarioModuloResponse
import es.ua.eps.teachtogether.models.autoevaluaciones.AutoevaluacionesResponse
import es.ua.eps.teachtogether.models.userInfo.UserID
import es.ua.eps.teachtogether.services.RetrofitInstance
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response

class AutoevaluacionesActivity : AppCompatActivity() {
    private lateinit var binding: ActivityAutoevaluacionesBinding
    private var idModulo: Int = 0
    private var autoevaluacionesList: List<AutoevaluacionesResponse> = listOf()
    private var autoevaluacionUsuarioList: List<AutoevaluacionUsuarioResponse> = listOf()
    private var autoevaluacionesIDS: List<Int> = listOf()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityAutoevaluacionesBinding.inflate(layoutInflater)
        setContentView(binding.root)

        val nombreModulo = intent.getStringExtra("nombre")
        binding.titulo.text = "Autoevaluaciones del Módulo: $nombreModulo"
        idModulo = intent.getIntExtra("idMod", 0)
        getAutoevaluacionesAlumno()
        setupSearchView()
        binding.buttonVolver.setOnClickListener {
            finish()
        }
    }

    private fun fetchAutoevaluaciones(idModulo: Int) {
        RetrofitInstance.apiService.getAutoevaluaciones()
            .enqueue(object : Callback<List<AutoevaluacionesResponse>> {
                override fun onResponse(
                    call: Call<List<AutoevaluacionesResponse>>,
                    response: Response<List<AutoevaluacionesResponse>>
                ) {
                    if (response.isSuccessful && response.body() != null) {
                        autoevaluacionesList = response.body()!!

                        val filteredAutoevaluaciones = autoevaluacionesList.filter {
                            it.idModulo.idModulo == idModulo && autoevaluacionesIDS.contains(it.idAutoevaluacion)
                        }

                        if (filteredAutoevaluaciones.isNotEmpty()) {
                            val adapter = AutoevaluacionAdapter(
                                this@AutoevaluacionesActivity,
                                filteredAutoevaluaciones
                            )
                            binding.listViewAutoevaluaciones.adapter = adapter

                            binding.listViewAutoevaluaciones.setOnItemClickListener { parent, view, position, id ->
                                val selectedAutoevaluacion = filteredAutoevaluaciones[position]
                                val intent = Intent(
                                    this@AutoevaluacionesActivity,
                                    PreguntaAutoevaluacionActivity::class.java
                                )
                                intent.putExtra(
                                    "autoevaluacionId",
                                    selectedAutoevaluacion.idAutoevaluacion
                                )
                                intent.putExtra("nombre", selectedAutoevaluacion.titulo)
                                startActivity(intent)
                            }
                        } else {
                            Toast.makeText(
                                this@AutoevaluacionesActivity,
                                "No hay autoevaluaciones para este módulo",
                                Toast.LENGTH_SHORT
                            ).show()
                        }
                    } else {
                        Toast.makeText(
                            this@AutoevaluacionesActivity,
                            "Error al obtener las autoevaluaciones",
                            Toast.LENGTH_SHORT
                        ).show()
                    }
                }

                override fun onFailure(call: Call<List<AutoevaluacionesResponse>>, t: Throwable) {
                    Toast.makeText(
                        this@AutoevaluacionesActivity,
                        "Error en la conexión",
                        Toast.LENGTH_SHORT
                    ).show()
                }
            })
    }

    private fun setupSearchView() {
        binding.searchViewAuto.setOnQueryTextListener(object : SearchView.OnQueryTextListener {
            override fun onQueryTextSubmit(query: String?): Boolean {
                return false
            }

            override fun onQueryTextChange(newText: String?): Boolean {
                val filteredList = autoevaluacionesList.filter {
                    it.titulo.contains(
                        newText ?: "",
                        ignoreCase = true
                    ) && it.idModulo.idModulo == idModulo
                }
                val adapter = AutoevaluacionAdapter(this@AutoevaluacionesActivity, filteredList)
                binding.listViewAutoevaluaciones.adapter = adapter
                return true
            }
        })
    }

    private fun getAutoevaluacionesAlumno() {
        RetrofitInstance.apiService.getAllAutoevaluacionesUsuarios()
            .enqueue(object : Callback<List<AutoevaluacionUsuarioResponse>> {
                override fun onResponse(
                    call: Call<List<AutoevaluacionUsuarioResponse>>,
                    response: Response<List<AutoevaluacionUsuarioResponse>>
                ) {
                    if (response.isSuccessful && response.body() != null) {
                        autoevaluacionUsuarioList = response.body()!!
                        val filteredAutoevaluacionesUsuario = autoevaluacionUsuarioList.filter {
                            it.idAlumno == UserID.userID
                        }
                        autoevaluacionesIDS = filteredAutoevaluacionesUsuario.map { it.idAutoevaluacion }


                        fetchAutoevaluaciones(idModulo)
                    }
                }

                override fun onFailure(
                    call: Call<List<AutoevaluacionUsuarioResponse>>,
                    t: Throwable
                ) {
                    Toast.makeText(
                        this@AutoevaluacionesActivity,
                        "Error en la conexión",
                        Toast.LENGTH_SHORT
                    ).show()
                }
            })
    }
}
