package com.proyecto.apiteachtoegther.models;

import jakarta.persistence.*;

import java.sql.Date;

@Entity
@jakarta.persistence.Table(name = "usuarios_modulos", schema = "teachtogether", catalog = "")
@jakarta.persistence.IdClass(com.proyecto.apiteachtoegther.models.UsuariosModulosEntityPK.class)
public class UsuariosModulosEntity {
    @JoinColumn(name = "id_alumno",referencedColumnName = "id_usuario",nullable = false,insertable = false, updatable = false)
    @ManyToOne
    private UsuariosEntity id_alumno;

    @JoinColumn(name = "id_modulo",referencedColumnName = "id_modulo",nullable = false,insertable = false, updatable = false)
    @ManyToOne
    private ModulosEntity id_modulo;

    @Id
    @Column(name = "id_modulo", nullable = false)
    private int idModulo;

    @Id
    @Column(name = "id_alumno", nullable = false)
    private int idAlumno;


    public UsuariosEntity getId_alumno() {
        return id_alumno;
    }

    public void setId_alumno(UsuariosEntity id_alumno) {
        this.id_alumno = id_alumno;
    }

    public ModulosEntity getId_modulo() {
        return id_modulo;
    }

    public void setId_modulo(ModulosEntity id_modulo) {
        this.id_modulo = id_modulo;
    }

    public int getIdModulo() {
        return idModulo;
    }

    public void setIdModulo(int idModulo) {
        this.idModulo = idModulo;
    }

    public int getIdAlumno() {
        return idAlumno;
    }

    public void setIdAlumno(int idAlumno) {
        this.idAlumno = idAlumno;
    }
}
