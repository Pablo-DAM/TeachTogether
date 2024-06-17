package es.ua.eps.teachtogether.models.mensajes

data class MensajesResponse(
    val idMensaje: Int,
    val idCreador: IdCreador,
    val texto: String,
    val fechaCreaccion: String,
    val idReceptor: IdReceptor,
)

data class IdCreador(
    val idUsuario: Int,
    val usuario: String,
    val rol: String,
    val password: String,
)

data class IdReceptor(
    val idUsuario: Int,
    val usuario: String,
    val rol: String,
    val password: String,
)

