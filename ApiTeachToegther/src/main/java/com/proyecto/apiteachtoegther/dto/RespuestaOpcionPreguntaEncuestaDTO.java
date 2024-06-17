package com.proyecto.apiteachtoegther.dto;

public class RespuestaOpcionPreguntaEncuestaDTO {
    private int id_respuesta;
    private String texto_opcional_respuesta;
    private int id_opcion;

    public int getId_respuesta() {
        return id_respuesta;
    }

    public void setId_respuesta(int id_respuesta) {
        this.id_respuesta = id_respuesta;
    }

    public String getTexto_opcional_respuesta() {
        return texto_opcional_respuesta;
    }

    public void setTexto_opcional_respuesta(String texto_opcional_respuesta) {
        this.texto_opcional_respuesta = texto_opcional_respuesta;
    }

    public int getId_opcion() {
        return id_opcion;
    }

    public void setId_opcion(int id_opcion) {
        this.id_opcion = id_opcion;
    }
}
