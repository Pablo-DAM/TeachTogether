package es.ua.eps.teachtogether.models.autoevaluacionUsuario

import java.util.Date

data class AutoevaluacionUsuarioPUTRequest(
    val id_autoevaluacion:Int,
    val id_alumno:Int,
    val fecha_realizacion:String
)
