package es.ua.eps.teachtogether.models.modulos

data class ModulosResponse(
    val idModulo: Long,
    val nombre: String,
    val horario: String,
    val horas: Int,
    val idProfesor: IdProfesor,
    val codigo: String,
    val dias: String,
)

data class IdProfesor(
    val idUsuario: Int,
    val usuario: String,
    val rol: String,
    val password: String,
)