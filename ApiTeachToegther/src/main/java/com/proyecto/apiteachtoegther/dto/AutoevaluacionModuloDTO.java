package com.proyecto.apiteachtoegther.dto;

public class AutoevaluacionModuloDTO {
    private int idAutoevaluacion;
    private String titulo;
    private int idModulo;
    private String nombre;

    public AutoevaluacionModuloDTO(int idAutoevaluacion, String titulo, int idModulo, String nombre) {
        this.idAutoevaluacion = idAutoevaluacion;
        this.titulo = titulo;
        this.idModulo = idModulo;
        this.nombre = nombre;
    }

    public int getIdAutoevaluacion() {
        return idAutoevaluacion;
    }

    public void setIdAutoevaluacion(int idAutoevaluacion) {
        this.idAutoevaluacion = idAutoevaluacion;
    }

    public String getTitulo() {
        return titulo;
    }

    public void setTitulo(String titulo) {
        this.titulo = titulo;
    }

    public int getIdModulo() {
        return idModulo;
    }

    public void setIdModulo(int idModulo) {
        this.idModulo = idModulo;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }
}