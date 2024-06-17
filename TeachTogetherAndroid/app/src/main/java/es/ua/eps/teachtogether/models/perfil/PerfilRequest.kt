package es.ua.eps.teachtogether.models.perfil

data class PerfilRequest(
    val id_usuario:Int, val nombre:String, val apellidos:String, val fecha_nacimiento:String,
)
