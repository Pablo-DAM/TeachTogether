package com.proyecto.apiteachtoegther.models;

import jakarta.persistence.*;

@Entity
@jakarta.persistence.Table(name = "respuestas_pregunta_autoevaluacion", schema = "teachtogether", catalog = "")
public class RespuestasPreguntaAutoevaluacionEntity {
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Id
    @jakarta.persistence.Column(name = "id_respuesta", nullable = false)
    private int idRespuesta;

    public int getIdRespuesta() {
        return idRespuesta;
    }

    public void setIdRespuesta(int idRespuesta) {
        this.idRespuesta = idRespuesta;
    }

    @Basic
    @Column(name = "texto_respuesta", nullable = true, length = -1)
    private String textoRespuesta;

    public String getTextoRespuesta() {
        return textoRespuesta;
    }

    public void setTextoRespuesta(String textoRespuesta) {
        this.textoRespuesta = textoRespuesta;
    }

    @ManyToOne
    @JoinColumn(name = "id_pregunta", nullable = false)
    private PreguntasAutoevaluacionEntity idPregunta;

    public PreguntasAutoevaluacionEntity getIdPregunta() {
        return idPregunta;
    }

    public void setIdPregunta(PreguntasAutoevaluacionEntity idPregunta) {
        this.idPregunta = idPregunta;
    }

    @ManyToOne
    @JoinColumn(name = "id_alumno",nullable = false)
    private UsuariosEntity idAlumno;

    public UsuariosEntity getIdAlumno() {
        return idAlumno;
    }

    public void setIdAlumno(UsuariosEntity idAlumno) {
        this.idAlumno = idAlumno;
    }
}
