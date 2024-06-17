package es.ua.eps.teachtogether.models.usuario

data class UsuarioPUTRequest(
    val idUsuario:Int,
    val usuario:String,
    val rol:String,
    val password:String
)
