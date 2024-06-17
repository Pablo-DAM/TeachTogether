package com.proyecto.apiteachtoegther.dto;

public class EncuestaDTO {
    private int id_encuesta;
    private String titulo;
    private int id_profesor_realizador;

    public int getId_encuesta() {
        return id_encuesta;
    }

    public void setId_encuesta(int id_encuesta) {
        this.id_encuesta = id_encuesta;
    }

    public String getTitulo() {
        return titulo;
    }

    public void setTitulo(String titulo) {
        this.titulo = titulo;
    }

    public int getId_profesor_realizador() {
        return id_profesor_realizador;
    }

    public void setId_profesor_realizador(int id_profesor_realizador) {
        this.id_profesor_realizador = id_profesor_realizador;
    }
}
