package com.proyecto.apiteachtoegther.models;

import jakarta.persistence.*;

import java.time.LocalDate;

@Entity
@jakarta.persistence.Table(name = "usuarios_encuestas", schema = "teachtogether", catalog = "")
@jakarta.persistence.IdClass(com.proyecto.apiteachtoegther.models.UsuariosEncuestasEntityPK.class)
public class UsuariosEncuestasEntity {
    @Id
    @Column(name = "id_usuario")
    private int id_usuario;
    @Id
    @Column(name = "id_encuesta")
    private int id_encuesta;
    @JoinColumn(name = "id_usuario", referencedColumnName = "id_usuario", nullable = false, insertable = false, updatable = false)
    @ManyToOne
    private UsuariosEntity idUsuario;

    public UsuariosEntity getIdUsuario() {
        return idUsuario;
    }

    private LocalDate fecha_realizacion;

    public LocalDate getFecha_realizacion() {
        return fecha_realizacion;
    }

    public void setFecha_realizacion(LocalDate fecha_realizacion) {
        this.fecha_realizacion = fecha_realizacion;
    }

    public void setIdUsuario(UsuariosEntity idUsuario) {
        this.idUsuario = idUsuario;
    }

    @JoinColumn(name = "id_encuesta", referencedColumnName = "id_encuesta", nullable = false, insertable = false, updatable = false)
    @ManyToOne
    private EncuestasEntity idEncuesta;

    public EncuestasEntity getIdEncuesta() {
        return idEncuesta;
    }

    public void setIdEncuesta(EncuestasEntity idEncuesta) {
        this.idEncuesta = idEncuesta;
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
