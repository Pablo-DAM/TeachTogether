package com.proyecto.apiteachtoegther.models;

import jakarta.persistence.Column;
import jakarta.persistence.Embeddable;

import java.io.Serializable;
import java.util.Objects;

@Embeddable
public class UsuariosModulosEntityPK implements Serializable {
    @Column(name = "id_alumno", nullable = false)
    private int idAlumno;
    @Column(name = "id_modulo", nullable = false)
    private int idModulo;

    public int getIdAlumno() {
        return idAlumno;
    }

    public void setIdAlumno(int idAlumno) {
        this.idAlumno = idAlumno;
    }

    public int getIdModulo() {
        return idModulo;
    }

    public void setIdModulo(int idModulo) {
        this.idModulo = idModulo;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        UsuariosModulosEntityPK that = (UsuariosModulosEntityPK) o;
        return idAlumno == that.idAlumno && idModulo == that.idModulo;
    }

    @Override
    public int hashCode() {
        return Objects.hash(idAlumno, idModulo);
    }
}
