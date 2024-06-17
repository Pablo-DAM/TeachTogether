package com.proyecto.apiteachtoegther.models;

import jakarta.persistence.*;

@Entity
@Table(name = "encuestas", schema = "teachtogether", catalog = "")
public class EncuestasEntity {
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Id
    @Column(name = "id_encuesta", nullable = false)
    private int idEncuesta;
    @Basic
    @Column(name = "titulo", nullable = false, length = 200)
    private String titulo;
    @ManyToOne
    @JoinColumn(name = "id_profesor_realizador", nullable = false)
    private UsuariosEntity idProfesorRealizador;

    public int getIdEncuesta() {
        return idEncuesta;
    }

    public void setIdEncuesta(int idEncuesta) {
        this.idEncuesta = idEncuesta;
    }

    public String getTitulo() {
        return titulo;
    }

    public void setTitulo(String titulo) {
        this.titulo = titulo;
    }

    public UsuariosEntity getIdProfesorRealizador() {
        return idProfesorRealizador;
    }

    public void setIdProfesorRealizador(UsuariosEntity idProfesorRealizador) {
        this.idProfesorRealizador = idProfesorRealizador;
    }


}
