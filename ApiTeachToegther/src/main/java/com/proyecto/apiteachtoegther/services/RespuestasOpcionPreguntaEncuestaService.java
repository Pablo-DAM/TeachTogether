package com.proyecto.apiteachtoegther.services;


import com.proyecto.apiteachtoegther.models.RespuestasOpcionPreguntaEncuestaEntity;
import com.proyecto.apiteachtoegther.repositories.IRespuestaPreguntasAutoevaluacion;
import com.proyecto.apiteachtoegther.repositories.IRespuestasOpcionPreguntaEncuesta;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.Optional;

@Service
public class RespuestasOpcionPreguntaEncuestaService {

    @Autowired
    private IRespuestasOpcionPreguntaEncuesta respuestasOpcionPreguntaEncuestaRepository;

    public ArrayList<RespuestasOpcionPreguntaEncuestaEntity> getAllRespuestas() {
        return (ArrayList<RespuestasOpcionPreguntaEncuestaEntity>) respuestasOpcionPreguntaEncuestaRepository.findAll();
    }

    public RespuestasOpcionPreguntaEncuestaEntity saveRespuesta(RespuestasOpcionPreguntaEncuestaEntity respuesta) {
        return respuestasOpcionPreguntaEncuestaRepository.save(respuesta);
    }

    public Optional<RespuestasOpcionPreguntaEncuestaEntity> getById(Integer id) {
        return respuestasOpcionPreguntaEncuestaRepository.findById(id);
    }

    public boolean deleteRespuesta(Integer id) {
        if (respuestasOpcionPreguntaEncuestaRepository.existsById(id)) {
            respuestasOpcionPreguntaEncuestaRepository.deleteById(id);
            return true;
        } else {
            return false;
        }
    }

    public RespuestasOpcionPreguntaEncuestaEntity updateById(RespuestasOpcionPreguntaEncuestaEntity request, Integer id) {
        Optional<RespuestasOpcionPreguntaEncuestaEntity> respuestaExistente = respuestasOpcionPreguntaEncuestaRepository.findById(id);
        if (respuestaExistente.isPresent()) {
            RespuestasOpcionPreguntaEncuestaEntity respuesta = respuestaExistente.get();
            respuesta.setTextoOpcionalRespuesta(request.getTextoOpcionalRespuesta());
            respuesta.setIdOpcion(request.getIdOpcion());
            return respuestasOpcionPreguntaEncuestaRepository.save(respuesta);
        } else {

            return null;
        }
    }
}