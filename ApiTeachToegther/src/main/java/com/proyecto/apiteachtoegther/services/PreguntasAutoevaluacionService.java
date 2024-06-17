package com.proyecto.apiteachtoegther.services;

import com.proyecto.apiteachtoegther.models.AutoevaluacionesEntity;
import com.proyecto.apiteachtoegther.models.PreguntasAutoevaluacionEntity;
import com.proyecto.apiteachtoegther.repositories.IMensajesRepository;
import com.proyecto.apiteachtoegther.repositories.IPreguntasAutoevaluacionRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

@Service
public class PreguntasAutoevaluacionService {
    @Autowired
    private IPreguntasAutoevaluacionRepository preguntasAutoevaluacionRepository;

    public ArrayList<PreguntasAutoevaluacionEntity> getAllPreguntasAutoevaluaciones() {
        return (ArrayList<PreguntasAutoevaluacionEntity>) this.preguntasAutoevaluacionRepository.findAll();
    }

    public PreguntasAutoevaluacionEntity savePregunta(PreguntasAutoevaluacionEntity pregunta) {
        return preguntasAutoevaluacionRepository.save(pregunta);
    }

    public Optional<PreguntasAutoevaluacionEntity> getById(Integer id) {
        return this.preguntasAutoevaluacionRepository.findById(id);
    }

    public boolean deletePregunta(Integer id) {
        if (this.preguntasAutoevaluacionRepository.existsById(id)) {
            preguntasAutoevaluacionRepository.deleteById(id);
            return true;
        } else {
            return false;
        }
    }

    public PreguntasAutoevaluacionEntity updateById(PreguntasAutoevaluacionEntity request, Integer id) {
        PreguntasAutoevaluacionEntity pregunta = this.preguntasAutoevaluacionRepository.findById(id).get();
        pregunta.setIdPregunta(request.getIdPregunta());
        pregunta.setIdAutoevaluacion(request.getIdAutoevaluacion());
        pregunta.setEnunciadoPregunta(request.getEnunciadoPregunta());
        this.preguntasAutoevaluacionRepository.save(pregunta);
        return pregunta;
    }
}
