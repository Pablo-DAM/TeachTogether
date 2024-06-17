package com.proyecto.apiteachtoegther.dto;

import java.sql.Date;

public class AutoevaluacionUsuarioDTO {
    private int id_autoevaluacion;
    private int id_alumno;
    private Date fecha_realizacion;


    public int getId_autoevaluacion() {
        return id_autoevaluacion;
    }

    public void setId_autoevaluacion(int id_autoevaluacion) {
        this.id_autoevaluacion = id_autoevaluacion;
    }

    public int getId_alumno() {
        return id_alumno;
    }

    public void setId_alumno(int id_alumno) {
        this.id_alumno = id_alumno;
    }

    public Date getFecha_realizacion() {
        return fecha_realizacion;
    }

    public void setFecha_realizacion(Date fecha_realizacion) {
        this.fecha_realizacion = fecha_realizacion;
    }
}
