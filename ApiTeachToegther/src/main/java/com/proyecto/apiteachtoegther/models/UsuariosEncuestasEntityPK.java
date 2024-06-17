package com.proyecto.apiteachtoegther.models;

import jakarta.persistence.Column;
import jakarta.persistence.Embeddable;
import jakarta.persistence.Embedded;
import jakarta.persistence.Id;

import java.io.Serializable;
import java.util.Objects;

@Embeddable
public class UsuariosEncuestasEntityPK implements Serializable {
    @Column(name = "id_usuario", nullable = false)
    private int id_usuario;
    @Column(name = "id_encuesta", nullable = false)
    private int id_encuesta;

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (!(o instanceof UsuariosEncuestasEntityPK that)) return false;
        return id_usuario == that.id_usuario && id_encuesta == that.id_encuesta;
    }

    @Override
    public int hashCode() {
        return Objects.hash(id_usuario, id_encuesta);
    }

    public int getId_usuario() {
        return id_usuario;
    }

    public void setId_usuario(int id_usuario) {
        this.id_usuario = id_usuario;
    }

    public int getId_encuesta() {
        return id_encuesta;
    }

    public void setId_encuesta(int id_encuesta) {
        this.id_encuesta = id_encuesta;
    }
}
