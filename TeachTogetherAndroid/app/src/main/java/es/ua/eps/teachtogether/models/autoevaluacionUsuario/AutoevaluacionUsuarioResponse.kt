package es.ua.eps.teachtogether.models.autoevaluacionUsuario

import com.fasterxml.jackson.annotation.JsonProperty
import com.google.gson.annotations.SerializedName

data class AutoevaluacionUsuarioResponse(
    val idAutoevaluacion: Int,
    val idAlumno: Int,
    val autoevaluacion: Autoevaluacion,
    val alumno: Alumno,
    @SerializedName("fecha_realizacion")
    val fechaRealizacion: String,
)
data class Autoevaluacion(
    val idAutoevaluacion: Int,
    val titulo: String,
    val idProfesorCreador: IdProfesorCreador,
)

data class IdProfesorCreador(
    val idUsuario: Int,
    val usuario: String,
    val rol: String,
    val password: String,
)

data class Alumno(
    val idUsuario: Int,
    val usuario: String,
    val rol: String,
    val password: String,
)
