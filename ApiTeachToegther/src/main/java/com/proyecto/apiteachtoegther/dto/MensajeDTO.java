package com.proyecto.apiteachtoegther.dto;

import jakarta.persistence.criteria.CriteriaBuilder;

import java.sql.Timestamp;

public class MensajeDTO {
    private Integer id_mensaje;
    private Integer id_creador;
    private String texto;
    private Timestamp fecha_creaccion;
    private Integer id_receptor;

    public Integer getId_mensaje() {
        return id_mensaje;
    }

    public void setId_mensaje(Integer id_mensajes) {
        this.id_mensaje = id_mensajes;
    }

    public Integer getId_creador() {
        return id_creador;
    }

    public void setId_creador(Integer id_creador) {
        this.id_creador = id_creador;
    }

    public String getTexto() {
        return texto;
    }

    public void setTexto(String texto) {
        this.texto = texto;
    }

    public Timestamp getFecha_creaccion() {
        return fecha_creaccion;
    }

    public void setFecha_creaccion(Timestamp fecha_creaccion) {
        this.fecha_creaccion = fecha_creaccion;
    }

    public Integer getId_receptor() {
        return id_receptor;
    }

    public void setId_receptor(Integer id_receptor) {
        this.id_receptor = id_receptor;
    }
}
