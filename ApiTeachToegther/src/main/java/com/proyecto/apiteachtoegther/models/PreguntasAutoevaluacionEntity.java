package com.proyecto.apiteachtoegther.models;

import jakarta.persistence.*;

@Entity
@jakarta.persistence.Table(name = "preguntas_autoevaluacion", schema = "teachtogether", catalog = "")
public class PreguntasAutoevaluacionEntity {
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Id
    @jakarta.persistence.Column(name = "id_pregunta", nullable = false)
    private int idPregunta;

    public int getIdPregunta() {
        return idPregunta;
    }

    public void setIdPregunta(int idPregunta) {
        this.idPregunta = idPregunta;
    }

    @ManyToOne
    @JoinColumn(name = "id_autoevaluacion", nullable = false)
    private AutoevaluacionesEntity idAutoevaluacion;

    public AutoevaluacionesEntity getIdAutoevaluacion() {
        return idAutoevaluacion;
    }

    public void setIdAutoevaluacion(AutoevaluacionesEntity idAutoevaluacion) {
        this.idAutoevaluacion = idAutoevaluacion;
    }

    @Basic
    @Column(name = "enunciado_pregunta", nullable = false, length = 200)
    private String enunciadoPregunta;

    public String getEnunciadoPregunta() {
        return enunciadoPregunta;
    }

    public void setEnunciadoPregunta(String enunciadoPregunta) {
        this.enunciadoPregunta = enunciadoPregunta;
    }

}
