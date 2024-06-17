package es.ua.eps.teachtogether.models.preguntas

import com.google.gson.annotations.SerializedName

data class PreguntasResponse(
    val idPregunta: Int,
    val idAutoevaluacion: IdAutoevaluacion,
    val enunciadoPregunta: String,
)
data class IdAutoevaluacion(
    val idAutoevaluacion: Int,
    val titulo: String,
    @SerializedName("id_modulo")
    val idModulo: IdModulo,
    val idProfesorCreador: IdProfesorCreador,
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

data class IdProfesorCreador(
    val idUsuario: Int,
    val usuario: String,
    val rol: String,
    val password: String,
)