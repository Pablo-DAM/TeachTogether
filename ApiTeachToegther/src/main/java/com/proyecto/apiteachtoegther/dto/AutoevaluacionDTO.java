package com.proyecto.apiteachtoegther.dto;

public class AutoevaluacionDTO {
    private int id_autoevaluacion;
    private String titulo;
    private int id_profesor;
    private int id_modulo;
    public int getId_autoevaluacion() {
        return id_autoevaluacion;
    }

    public void setId_autoevaluacion(int id_autoevaluacion) {
        this.id_autoevaluacion = id_autoevaluacion;
    }

    public String getTitulo() {
        return titulo;
    }

    public void setTitulo(String titulo) {
        this.titulo = titulo;
    }

    public int getId_profesor() {
        return id_profesor;
    }

    public void setId_profesor(int id_profesor) {
        this.id_profesor = id_profesor;
    }

    public int getId_modulo() {
        return id_modulo;
    }

    public void setId_modulo(int id_modulo) {
        this.id_modulo = id_modulo;
    }
}
