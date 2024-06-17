package es.ua.eps.teachtogether.ui

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.AdapterView
import android.widget.SearchView
import android.widget.Toast
import es.ua.eps.teachtogether.adapters.ModuloAdapter
import es.ua.eps.teachtogether.databinding.ActivityModulosBinding
import es.ua.eps.teachtogether.models.modulos.ModulosResponse
import es.ua.eps.teachtogether.services.RetrofitInstance
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response

class ModulosActivity : AppCompatActivity() {
    private lateinit var binding: ActivityModulosBinding
    private lateinit var adapter: ModuloAdapter

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityModulosBinding.inflate(layoutInflater)
        setContentView(binding.root)
        fetchModulos()
        setupSearchView()
        binding.buttonMisModulos.setOnClickListener {
            val intent = Intent(this, MisModulosActivity::class.java)
            startActivity(intent)
        }
        binding.listViewModulos.onItemClickListener =
            AdapterView.OnItemClickListener { _, _, position, _ ->
                val modulo = adapter.getItem(position) as ModulosResponse
                val intent = Intent(this, DetallesModuloActivity::class.java).apply {
                    val idModInt = modulo.idModulo.toInt()
                    putExtra("nombre", modulo.nombre)
                    putExtra("horario", modulo.horario)
                    putExtra("horas", modulo.horas)
                    putExtra("profesorId", modulo.idProfesor.idUsuario)
                    putExtra("profesor", modulo.idProfesor.usuario)
                    putExtra("dias", modulo.dias)
                    putExtra("id_modulo", idModInt)
                    putExtra("codigo", modulo.codigo)
                    putExtra("mis", false)
                }
                startActivity(intent)
            }
        binding.buttonVolver.setOnClickListener {
            val intent = Intent(this, MenuActivity::class.java)
            startActivity(intent)
        }
    }

    private fun fetchModulos() {
        val call = RetrofitInstance.apiService.getModulos()
        call.enqueue(object : Callback<List<ModulosResponse>> {
            override fun onResponse(
                call: Call<List<ModulosResponse>>,
                response: Response<List<ModulosResponse>>
            ) {
                if (response.isSuccessful) {
                    val modulos = response.body()?.sortedBy { it.nombre } ?: emptyList()
                    adapter = ModuloAdapter(this@ModulosActivity, modulos)
                    binding.listViewModulos.adapter = adapter
                } else {
                    Toast.makeText(
                        this@ModulosActivity,
                        "Error al obtener datos",
                        Toast.LENGTH_SHORT
                    ).show()
                }
            }

            override fun onFailure(call: Call<List<ModulosResponse>>, t: Throwable) {
                Toast.makeText(this@ModulosActivity, "Error: ${t.message}", Toast.LENGTH_SHORT)
                    .show()
            }
        })
    }

    private fun setupSearchView() {
        binding.searchViewModulos.setOnQueryTextListener(object : SearchView.OnQueryTextListener {
            override fun onQueryTextSubmit(query: String?): Boolean {
                return false
            }

            override fun onQueryTextChange(newText: String?): Boolean {
                adapter.filter.filter(newText)
                return true
            }
        })
    }
}