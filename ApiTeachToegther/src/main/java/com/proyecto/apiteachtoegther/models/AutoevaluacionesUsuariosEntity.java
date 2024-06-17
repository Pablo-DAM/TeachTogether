package com.proyecto.apiteachtoegther.models;

import jakarta.persistence.*;

import java.sql.Date;
@Entity
@Table(name = "autoevaluaciones_usuarios", schema = "teachtogether", catalog = "")
@IdClass(AutoevaluacionesUsuariosEntityPK.class)
public class AutoevaluacionesUsuariosEntity {
    @Id
    @Column(name = "id_autoevaluacion", nullable = false)
    private int idAutoevaluacion;

    @Id
    @Column(name = "id_alumno", nullable = false)
    private int idAlumno;

    @ManyToOne
    @JoinColumn(name = "id_autoevaluacion", referencedColumnName = "id_autoevaluacion", insertable = false, updatable = false)
    private AutoevaluacionesEntity autoevaluacion;

    @ManyToOne
    @JoinColumn(name = "id_alumno", referencedColumnName = "id_usuario", insertable = false, updatable = false)
    private UsuariosEntity alumno;

    @Basic
    @Column(name = "fecha_realizacion",nullable = true)
    private Date fecha_realizacion;

    public Date getFecha_realizacion() {
        return fecha_realizacion;
    }

    public void setFecha_realizacion(Date fecha_realizacion) {
        this.fecha_realizacion = fecha_realizacion;
    }

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

    public AutoevaluacionesEntity getAutoevaluacion() {
        return autoevaluacion;
    }

    public void setAutoevaluacion(AutoevaluacionesEntity autoevaluacion) {
        this.autoevaluacion = autoevaluacion;
    }

    public UsuariosEntity getAlumno() {
        return alumno;
    }

    public void setAlumno(UsuariosEntity alumno) {
        this.alumno = alumno;
    }
}
