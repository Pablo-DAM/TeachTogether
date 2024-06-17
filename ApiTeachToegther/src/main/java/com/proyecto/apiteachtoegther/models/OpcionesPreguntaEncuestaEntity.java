package com.proyecto.apiteachtoegther.models;

import jakarta.persistence.*;

@Entity
@jakarta.persistence.Table(name = "opciones_pregunta_encuesta", schema = "teachtogether", catalog = "")
public class OpcionesPreguntaEncuestaEntity {
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Id
    @jakarta.persistence.Column(name = "id_opcion", nullable = false)
    private int idOpcion;

    public int getIdOpcion() {
        return idOpcion;
    }

    public void setIdOpcion(int idOpcion) {
        this.idOpcion = idOpcion;
    }

    @Basic
    @Column(name = "texto_opcion", nullable = false, length = 150)
    private String textoOpcion;

    public String getTextoOpcion() {
        return textoOpcion;
    }

    public void setTextoOpcion(String textoOpcion) {
        this.textoOpcion = textoOpcion;
    }

    @ManyToOne
    @JoinColumn(name = "id_pregunta_encuesta", nullable = false)
    private PreguntasEncuestaEntity idPreguntaEncuesta;

    public PreguntasEncuestaEntity getIdPreguntaEncuesta() {
        return idPreguntaEncuesta;
    }

    public void setIdPreguntaEncuesta(PreguntasEncuestaEntity idPreguntaEncuesta) {
        this.idPreguntaEncuesta = idPreguntaEncuesta;
    }
}
