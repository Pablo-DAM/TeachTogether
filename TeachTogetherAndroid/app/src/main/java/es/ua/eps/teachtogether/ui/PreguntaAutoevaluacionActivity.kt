package es.ua.eps.teachtogether.ui

import android.R.id
import android.app.Activity
import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.SearchView
import android.widget.Toast
import es.ua.eps.teachtogether.adapters.PreguntaConRespuestasAdapter
import es.ua.eps.teachtogether.databinding.ActivityPreguntaAutoevaluacionBinding
import es.ua.eps.teachtogether.models.preguntaRespuesta.PreguntaConRespuestas
import es.ua.eps.teachtogether.models.preguntas.PreguntasResponse
import es.ua.eps.teachtogether.models.respuestas.RespuestaResponse
import es.ua.eps.teachtogether.models.userInfo.UserID
import es.ua.eps.teachtogether.services.RetrofitInstance
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response

class PreguntaAutoevaluacionActivity : AppCompatActivity() {
    private lateinit var binding: ActivityPreguntaAutoevaluacionBinding
    private lateinit var nombre: String

    private var preguntasConRespuestasList: List<PreguntaConRespuestas> = listOf()

    companion object {
        const val REQUEST_CODE_RESPUESTA = 1
    }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityPreguntaAutoevaluacionBinding.inflate(layoutInflater)
        setContentView(binding.root)
        val autoevaluacionId = intent.getIntExtra("autoevaluacionId", 0)
        nombre = intent.getStringExtra("nombre")!!
        binding.titulo.text = "Preguntas y respuestas de la autoevaluación: $nombre"

        fetchPreguntasYRespuestas(autoevaluacionId)
        setupSearchView()
        binding.buttonVolver.setOnClickListener{
          finish()
        }
    }

    private fun fetchPreguntasYRespuestas(autoevaluacionId: Int) {
        RetrofitInstance.apiService.getAllPreguntas().enqueue(object : Callback<List<PreguntasResponse>> {
            override fun onResponse(call: Call<List<PreguntasResponse>>, response: Response<List<PreguntasResponse>>) {
                if (response.isSuccessful && response.body() != null) {
                    val preguntas = response.body()!!.filter { it.idAutoevaluacion.idAutoevaluacion == autoevaluacionId }

                    if (preguntas.isNotEmpty()) {
                        fetchRespuestas(preguntas)
                    } else {
                        Toast.makeText(this@PreguntaAutoevaluacionActivity, "No hay preguntas para esta autoevaluación", Toast.LENGTH_SHORT).show()
                    }
                } else {
                    Toast.makeText(this@PreguntaAutoevaluacionActivity, "Error al obtener las preguntas", Toast.LENGTH_SHORT).show()
                }
            }

            override fun onFailure(call: Call<List<PreguntasResponse>>, t: Throwable) {
                Toast.makeText(this@PreguntaAutoevaluacionActivity, "Error en la conexión", Toast.LENGTH_SHORT).show()
            }
        })
    }

    private fun fetchRespuestas(preguntas: List<PreguntasResponse>) {
        RetrofitInstance.apiService.getAllRespuestas().enqueue(object : Callback<List<RespuestaResponse>> {
            override fun onResponse(call: Call<List<RespuestaResponse>>, response: Response<List<RespuestaResponse>>) {
                if (response.isSuccessful && response.body() != null) {
                    val respuestas = response.body()!!
                    preguntasConRespuestasList = preguntas.map { pregunta ->
                        val respuesta = respuestas.firstOrNull { it.idPregunta.idPregunta == pregunta.idPregunta && it.idAlumno.idUsuario == UserID.userID}
                        PreguntaConRespuestas(pregunta, listOfNotNull(respuesta))
                    }

                    val adapter = PreguntaConRespuestasAdapter(this@PreguntaAutoevaluacionActivity, preguntasConRespuestasList)
                    binding.listViewAutoevaluaciones.adapter = adapter
                    binding.listViewAutoevaluaciones.setOnItemClickListener { _, _, position, _ ->
                        val selectedPreguntaConRespuestas = preguntasConRespuestasList[position]
                        val intent = Intent(this@PreguntaAutoevaluacionActivity, RespuestaActivity::class.java)
                        intent.putExtra("pregunta", selectedPreguntaConRespuestas.pregunta.enunciadoPregunta)
                        intent.putExtra("id_pregunta", selectedPreguntaConRespuestas.pregunta.idPregunta)
                        intent.putExtra("nombre", nombre)
                        intent.putExtra("id_autoevaluacion", selectedPreguntaConRespuestas.pregunta.idAutoevaluacion.idAutoevaluacion)
                        val respuesta = if (selectedPreguntaConRespuestas.respuestas.isNotEmpty()) {
                            selectedPreguntaConRespuestas.respuestas[0].textoRespuesta
                        } else {
                            "Sin respuesta"
                        }
                        intent.putExtra("respuesta", respuesta)
                        startActivityForResult(intent, REQUEST_CODE_RESPUESTA)
                    }

                } else {
                    Toast.makeText(this@PreguntaAutoevaluacionActivity, "Error al obtener las respuestas", Toast.LENGTH_SHORT).show()
                }
            }

            override fun onFailure(call: Call<List<RespuestaResponse>>, t: Throwable) {
                Toast.makeText(this@PreguntaAutoevaluacionActivity, "Error en la conexión", Toast.LENGTH_SHORT).show()
            }
        })
    }

    private fun setupSearchView() {
        binding.searchViewAuto.setOnQueryTextListener(object : SearchView.OnQueryTextListener {
            override fun onQueryTextSubmit(query: String?): Boolean {
                return false
            }

            override fun onQueryTextChange(newText: String?): Boolean {
                val filteredList = preguntasConRespuestasList.filter {
                    it.pregunta.enunciadoPregunta.contains(newText ?: "", ignoreCase = true)
                }
                val adapter = PreguntaConRespuestasAdapter(this@PreguntaAutoevaluacionActivity, filteredList)
                binding.listViewAutoevaluaciones.adapter = adapter
                return true
            }
        })
    }

    override fun onActivityResult(requestCode: Int, resultCode: Int, data: Intent?) {
        super.onActivityResult(requestCode, resultCode, data)
        if (requestCode == REQUEST_CODE_RESPUESTA && resultCode == Activity.RESULT_OK) {
            val autoevaluacionId = intent.getIntExtra("autoevaluacionId", 0)
            fetchPreguntasYRespuestas(autoevaluacionId)
        }
    }
}