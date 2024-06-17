package com.proyecto.apiteachtoegther.dto;

public class OpcionPreguntaEncuestaDTO {
    private int id_opcion;
    private String texto_opcion;
    private int id_pregunta_encuesta;

    public int getId_opcion() {
        return id_opcion;
    }

    public void setId_opcion(int id_opcion) {
        this.id_opcion = id_opcion;
    }

    public String getTexto_opcion() {
        return texto_opcion;
    }

    public void setTexto_opcion(String texto_opcion) {
        this.texto_opcion = texto_opcion;
    }

    public int getId_pregunta_encuesta() {
        return id_pregunta_encuesta;
    }

    public void setId_pregunta_encuesta(int id_pregunta_encuesta) {
        this.id_pregunta_encuesta = id_pregunta_encuesta;
    }
}
