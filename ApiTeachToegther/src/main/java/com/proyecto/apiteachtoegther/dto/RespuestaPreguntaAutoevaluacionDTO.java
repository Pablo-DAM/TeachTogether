package com.proyecto.apiteachtoegther.dto;

public class RespuestaPreguntaAutoevaluacionDTO {
    private Integer id_respuesta;
    private String texto_respuesta;
    private Integer id_pregunta;

    private Integer id_alumno;

    public Integer getId_respuesta() {
        return id_respuesta;
    }

    public void setId_respuesta(Integer id_respuesta) {
        this.id_respuesta = id_respuesta;
    }

    public String getTexto_respuesta() {
        return texto_respuesta;
    }

    public void setTexto_respuesta(String texto_respuesta) {
        this.texto_respuesta = texto_respuesta;
    }

    public Integer getId_pregunta() {
        return id_pregunta;
    }

    public void setId_pregunta(Integer id_pregunta) {
        this.id_pregunta = id_pregunta;
    }

    public Integer getId_alumno() {
        return id_alumno;
    }

    public void setId_alumno(Integer id_alumno) {
        this.id_alumno = id_alumno;
    }
}
