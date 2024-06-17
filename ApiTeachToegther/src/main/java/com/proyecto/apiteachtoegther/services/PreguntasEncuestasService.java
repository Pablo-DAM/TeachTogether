package com.proyecto.apiteachtoegther.services;


import com.proyecto.apiteachtoegther.models.PreguntasEncuestaEntity;
import com.proyecto.apiteachtoegther.repositories.IPreguntasEncuestasRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.Optional;

@Service
public class PreguntasEncuestasService {

    @Autowired
    private IPreguntasEncuestasRepository preguntasEncuestaRepository;

    public ArrayList<PreguntasEncuestaEntity> getPreguntasEncuesta() {
        return (ArrayList<PreguntasEncuestaEntity>) preguntasEncuestaRepository.findAll();
    }

    public PreguntasEncuestaEntity savePreguntaEncuesta(PreguntasEncuestaEntity pregunta) {
        return preguntasEncuestaRepository.save(pregunta);
    }

    public Optional<PreguntasEncuestaEntity> getById(Integer id) {
        return preguntasEncuestaRepository.findById(id);
    }

    public PreguntasEncuestaEntity updateById(PreguntasEncuestaEntity request, Integer id) {
        PreguntasEncuestaEntity pregunta = preguntasEncuestaRepository.findById(id).get();
        pregunta.setTextoPregunta(request.getTextoPregunta());
        pregunta.setIdEncuesta(request.getIdEncuesta());
        preguntasEncuestaRepository.save(pregunta);
        return pregunta;
    }

    public boolean deletePreguntaEncuesta(Integer id) {
        if (preguntasEncuestaRepository.existsById(id)) {
            preguntasEncuestaRepository.deleteById(id);
            return true;
        } else {
            return false;
        }
    }
}