package com.proyecto.apiteachtoegther.models;

import jakarta.persistence.*;

@Entity
@Table(name = "autoevaluaciones", schema = "teachtogether", catalog = "")
public class AutoevaluacionesEntity {
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Id
    @Column(name = "id_autoevaluacion", nullable = false)
    private int idAutoevaluacion;
    @Basic
    @Column(name = "titulo", nullable = false, length = 100)
    private String titulo;
    @ManyToOne
    @JoinColumn(name = "id_modulo",nullable = false)
    private ModulosEntity id_modulo;
    @ManyToOne
    @JoinColumn(name = "id_profesor_creador", nullable = false)
    private UsuariosEntity idProfesorCreador;

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


    public UsuariosEntity getIdProfesorCreador() {
        return idProfesorCreador;
    }

    public void setIdProfesorCreador(UsuariosEntity idProfesorCreador) {
        this.idProfesorCreador = idProfesorCreador;
    }

    public ModulosEntity getId_modulo() {
        return id_modulo;
    }

    public void setId_modulo(ModulosEntity id_modulo) {
        this.id_modulo = id_modulo;
    }
}
