package com.proyecto.apiteachtoegther.models;

import jakarta.persistence.Column;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;

import java.io.Serializable;

import jakarta.persistence.Column;
import jakarta.persistence.Embeddable;
import java.io.Serializable;

@Embeddable
public class AutoevaluacionesUsuariosEntityPK implements Serializable {
    @Column(name = "id_autoevaluacion", nullable = false)
    private int idAutoevaluacion;

    @Column(name = "id_alumno", nullable = false)
    private int idAlumno;

    public int getIdAutoevaluacion() {
        return idAutoevaluacion;
    }

    public void setIdAutoevaluacion(int idAutoevaluacion) {
        this.idAutoevaluacion = idAutoevaluacion;
    }

    public int getIdAlumno() {
        return idAlumno;
    }

    public void setIdAlumno(int idAlumno) {
        this.idAlumno = idAlumno;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        AutoevaluacionesUsuariosEntityPK that = (AutoevaluacionesUsuariosEntityPK) o;

        if (idAutoevaluacion != that.idAutoevaluacion) return false;
        return idAlumno == that.idAlumno;
    }

    @Override
    public int hashCode() {
        int result = idAutoevaluacion;
        result = 31 * result + idAlumno;
        return result;
    }

}
