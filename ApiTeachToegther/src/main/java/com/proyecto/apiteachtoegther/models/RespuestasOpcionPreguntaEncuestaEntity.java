package com.proyecto.apiteachtoegther.models;

import jakarta.persistence.*;

@Entity
@jakarta.persistence.Table(name = "respuestas_opcion_pregunta_encuesta", schema = "teachtogether", catalog = "")
public class RespuestasOpcionPreguntaEncuestaEntity {
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Id
    @jakarta.persistence.Column(name = "id_respuesta", nullable = false)
    private int idRespuesta;
    @Basic
    @Column(name = "texto_opcional_respuesta", nullable = true, length = -1)
    private String textoOpcionalRespuesta;
    @ManyToOne
    @JoinColumn(name = "id_opcion", nullable = false)
    private OpcionesPreguntaEncuestaEntity idOpcion;

    public int getIdRespuesta() {
        return idRespuesta;
    }

    public void setIdRespuesta(int idRespuesta) {
        this.idRespuesta = idRespuesta;
    }

    public String getTextoOpcionalRespuesta() {
        return textoOpcionalRespuesta;
    }

    public void setTextoOpcionalRespuesta(String textoOpcionalRespuesta) {
        this.textoOpcionalRespuesta = textoOpcionalRespuesta;
    }


    public OpcionesPreguntaEncuestaEntity getIdOpcion() {
        return idOpcion;
    }

    public void setIdOpcion(OpcionesPreguntaEncuestaEntity idOpcion) {
        this.idOpcion = idOpcion;
    }

}
