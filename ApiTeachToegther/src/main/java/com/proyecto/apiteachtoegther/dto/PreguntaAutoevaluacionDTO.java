package com.proyecto.apiteachtoegther.dto;

public class PreguntaAutoevaluacionDTO {
    private int id_pregunta;
    private int id_autoevaluacion;
    private String enunciado_pregunta;

    public int getId_pregunta() {
        return id_pregunta;
    }

    public void setId_pregunta(int id_pregunta) {
        this.id_pregunta = id_pregunta;
    }

    public int getId_autoevaluacion() {
        return id_autoevaluacion;
    }

    public void setId_autoevaluacion(int id_autoevaluacion) {
        this.id_autoevaluacion = id_autoevaluacion;
    }

    public String getEnunciado_pregunta() {
        return enunciado_pregunta;
    }

    public void setEnunciado_pregunta(String enunciado_pregunta) {
        this.enunciado_pregunta = enunciado_pregunta;
    }
}
