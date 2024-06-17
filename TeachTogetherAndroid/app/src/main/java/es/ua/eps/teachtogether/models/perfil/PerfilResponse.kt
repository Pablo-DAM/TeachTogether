package es.ua.eps.teachtogether.models.perfil

data class PerfilResponse(
    val idPerfil: Int,
    val nombre: String,
    val apellidos: String,
    val fechaNacimiento: String,
    val idUsuario: IdUsuario,
)


data class IdUsuario(
    val idUsuario: Int,
    val usuario: String,
    val rol: String,
    val password: String,
)