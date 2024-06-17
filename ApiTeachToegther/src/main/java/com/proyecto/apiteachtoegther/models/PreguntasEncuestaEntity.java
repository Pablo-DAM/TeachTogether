package com.proyecto.apiteachtoegther.models;

import jakarta.persistence.*;

@Entity
@jakarta.persistence.Table(name = "preguntas_encuesta", schema = "teachtogether", catalog = "")
public class PreguntasEncuestaEntity {
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Id
    @jakarta.persistence.Column(name = "id_pregunta", nullable = false)
    private int idPregunta;
    @Basic
    @Column(name = "texto_pregunta", nullable = false, length = 200)
    private String textoPregunta;

    public int getIdPregunta() {
        return idPregunta;
    }

    public void setIdPregunta(int idPregunta) {
        this.idPregunta = idPregunta;
    }



    public String getTextoPregunta() {
        return textoPregunta;
    }

    public void setTextoPregunta(String textoPregunta) {
        this.textoPregunta = textoPregunta;
    }

    @ManyToOne
    @JoinColumn(name = "id_encuesta", nullable = false)
    private EncuestasEntity idEncuesta;

    public EncuestasEntity getIdEncuesta() {
        return idEncuesta;
    }

    public void setIdEncuesta(EncuestasEntity idEncuesta) {
        this.idEncuesta = idEncuesta;
    }


}
