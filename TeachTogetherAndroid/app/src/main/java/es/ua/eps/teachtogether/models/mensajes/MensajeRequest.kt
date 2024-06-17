package es.ua.eps.teachtogether.models.mensajes

import java.sql.Timestamp

data class MensajeRequest (
    val id_creador:Int,
    val texto:String,
    val fecha_creaccion:String,
    val id_receptor:Int
)
