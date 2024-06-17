package es.ua.eps.teachtogether.models.usuarioModulo

import com.fasterxml.jackson.annotation.JsonProperty
import com.google.gson.annotations.SerializedName


data class UsuarioModuloResponse(
    @SerializedName("id_alumno")
    val idAlumno: IdAlumno,
    @SerializedName("id_modulo")
    val idModulo: IdModulo,
    @SerializedName("idModulo")
    val idModuloNumber: Int,
    @SerializedName("idAlumno")
    val idAlumnoNumber: Int
)

data class IdAlumno(
    val idUsuario: Int,
    val usuario: String,
    val rol: String,
    val password: String
)

data class IdModulo(
    val idModulo: Int,
    val nombre: String,
    val horario: String,
    val horas: Int,
    val idProfesor: IdProfesor,
    val codigo: String,
    val dias: String
)

data class IdProfesor(
    val idUsuario: Int,
    val usuario: String,
    val rol: String,
    val password: String
)