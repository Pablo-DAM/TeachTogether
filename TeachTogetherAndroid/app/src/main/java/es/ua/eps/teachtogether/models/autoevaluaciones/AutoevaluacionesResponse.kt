package es.ua.eps.teachtogether.models.autoevaluaciones

import com.fasterxml.jackson.annotation.JsonProperty
import com.google.gson.annotations.SerializedName

data class AutoevaluacionesResponse(
    val idAutoevaluacion: Int,
    val titulo: String,
    @SerializedName("id_modulo")
    val idModulo: IdModulo,
)

data class IdModulo(
    val idModulo: Int,
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