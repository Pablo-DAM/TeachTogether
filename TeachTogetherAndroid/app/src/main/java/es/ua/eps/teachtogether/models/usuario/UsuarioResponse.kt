package es.ua.eps.teachtogether.models.usuario

data class UsuarioResponse(
    val idUsuario:Int,
    val usuario:String,
    val rol:String,
    val password:String
)
