package es.ua.eps.teachtogether.ui

import android.content.Intent
import android.net.Uri
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import es.ua.eps.teachtogether.databinding.ActivityMenuBinding

class MenuActivity : AppCompatActivity() {
    private lateinit var binding: ActivityMenuBinding
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding=ActivityMenuBinding.inflate(layoutInflater)
        setContentView(binding.root)

        binding.perfil.setOnClickListener{
            val intent = Intent(this, PerfilActivity::class.java)
            startActivity(intent)
        }
        binding.mensajes.setOnClickListener{
            val intent = Intent(this,MensajesActivity::class.java)
            startActivity(intent)
        }
        binding.modulos.setOnClickListener{
            val intent = Intent(this,ModulosActivity::class.java)
            startActivity(intent)
        }
        binding.autoevaluaciones.setOnClickListener{
            val intent = Intent(this,MisModulosActivity::class.java)
            intent.putExtra("menu",true)
            startActivity(intent)
        }
        binding.volver.setOnClickListener {
            val intent = Intent(this, LoginActivity::class.java)
            intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK or Intent.FLAG_ACTIVITY_CLEAR_TASK)
            startActivity(intent)
            finish()
        }
        binding.portal.setOnClickListener{
            val url = "https://ipsl19892.wixsite.com/teachtogether"
            val intent = Intent(Intent.ACTION_VIEW)
            intent.data = Uri.parse(url)
            startActivity(intent)
        }
    }
}