package es.ua.eps.teachtogether.models.respuestas

data class RespuestaRequest(
    val texto_respuesta: String,
    val id_pregunta: Int,
    val id_alumno:Int
)
