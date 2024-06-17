package es.ua.eps.teachtogether.models.preguntaRespuesta

import es.ua.eps.teachtogether.models.preguntas.PreguntasResponse
import es.ua.eps.teachtogether.models.respuestas.RespuestaResponse

data class PreguntaConRespuestas(
    val pregunta: PreguntasResponse,
    val respuestas: List<RespuestaResponse>
)
