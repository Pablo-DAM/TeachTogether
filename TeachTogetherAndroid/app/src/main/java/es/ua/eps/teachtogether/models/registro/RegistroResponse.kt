package es.ua.eps.teachtogether.models.registro

data class RegistroResponse(
    val idUsuario:Int,
    val usuario:String,
    val rol:String,
    val password:String

)
