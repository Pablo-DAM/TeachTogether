package com.proyecto.apiteachtoegther.services;

import com.proyecto.apiteachtoegther.models.RespuestasPreguntaAutoevaluacionEntity;
import com.proyecto.apiteachtoegther.repositories.IRespuestaPreguntasAutoevaluacion;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

@Service
public class RespuestasPreguntaAutoevaluacionService {
    @Autowired
    private IRespuestaPreguntasAutoevaluacion preguntasAutoevaluacion;

    public List<RespuestasPreguntaAutoevaluacionEntity> getAllRespuestas() {
        return preguntasAutoevaluacion.findAll();
    }
    public Optional<RespuestasPreguntaAutoevaluacionEntity> getByID(int id){
        return   preguntasAutoevaluacion.findById(id);
    }
    public RespuestasPreguntaAutoevaluacionEntity saveRespuesta(RespuestasPreguntaAutoevaluacionEntity respuesta){
        return preguntasAutoevaluacion.save(respuesta);
    }
    public RespuestasPreguntaAutoevaluacionEntity updateById(RespuestasPreguntaAutoevaluacionEntity respuesta){
        return  preguntasAutoevaluacion.save(respuesta);
    }
    public boolean deleteRespuesta(Integer id) {
        if (preguntasAutoevaluacion.existsById(id)) { // Verifica si el mensaje existe
            preguntasAutoevaluacion.deleteById(id); // Elimina
            return true; //
        } else {
            return false; //
        }
    }
}
