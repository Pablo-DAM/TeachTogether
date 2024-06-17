package com.proyecto.apiteachtoegther.models;

import jakarta.persistence.*;

import java.sql.Timestamp;

@Entity
@Table(name = "mensajes", schema = "teachtogether", catalog = "")
public class MensajesEntity {
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Id
    @Column(name = "id_mensaje", nullable = false)
    private int idMensaje;
    @ManyToOne
    @JoinColumn(name = "id_creador", nullable = false)
    private UsuariosEntity idCreador;
    @Basic
    @Column(name = "texto", nullable = true, length = -1)
    private String texto;
    @Basic
    @Column(name = "fecha_creaccion", nullable = false)
    private Timestamp fechaCreaccion;
    @ManyToOne
    @JoinColumn(name = "id_receptor", nullable = false)
    private UsuariosEntity idReceptor;

    public UsuariosEntity getIdReceptor() {
        return idReceptor;
    }

    public void setIdReceptor(UsuariosEntity idReceptor) {
        this.idReceptor = idReceptor;
    }

    public int getIdMensaje() {
        return idMensaje;
    }

    public void setIdMensaje(int idMensaje) {
        this.idMensaje = idMensaje;
    }

    public UsuariosEntity getIdCreador() {
        return idCreador;
    }

    public void setIdCreador(UsuariosEntity idCreador) {
        this.idCreador = idCreador;
    }

    public String getTexto() {
        return texto;
    }

    public void setTexto(String texto) {
        this.texto = texto;
    }

    public Timestamp getFechaCreaccion() {
        return fechaCreaccion;
    }

    public void setFechaCreaccion(Timestamp fechaCreaccion) {
        this.fechaCreaccion = fechaCreaccion;
    }

}
