package com.proyecto.apiteachtoegther.services;


import com.proyecto.apiteachtoegther.models.OpcionesPreguntaEncuestaEntity;
import com.proyecto.apiteachtoegther.repositories.IOpcionesPreguntaEncuestaRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.Optional;

@Service
public class OpcionesPreguntaEncuestaService {

    @Autowired
    private IOpcionesPreguntaEncuestaRepository opcionesPreguntaEncuestaRepository;

    public ArrayList<OpcionesPreguntaEncuestaEntity> getAllOpcionesPreguntaEncuesta() {
        return (ArrayList<OpcionesPreguntaEncuestaEntity>) opcionesPreguntaEncuestaRepository.findAll();
    }

    public OpcionesPreguntaEncuestaEntity saveOpcion(OpcionesPreguntaEncuestaEntity opcion) {
        return opcionesPreguntaEncuestaRepository.save(opcion);
    }

    public Optional<OpcionesPreguntaEncuestaEntity> getById(Integer id) {
        return opcionesPreguntaEncuestaRepository.findById(id);
    }

    public boolean deleteOpcion(Integer id) {
        if (opcionesPreguntaEncuestaRepository.existsById(id)) {
            opcionesPreguntaEncuestaRepository.deleteById(id);
            return true;
        } else {
            return false;
        }
    }

    public OpcionesPreguntaEncuestaEntity updateById(OpcionesPreguntaEncuestaEntity request, Integer id) {
        Optional<OpcionesPreguntaEncuestaEntity> opcionExistente = opcionesPreguntaEncuestaRepository.findById(id);
        if (opcionExistente.isPresent()) {
            OpcionesPreguntaEncuestaEntity opcion = opcionExistente.get();
            opcion.setTextoOpcion(request.getTextoOpcion());
            opcion.setIdPreguntaEncuesta(request.getIdPreguntaEncuesta());
            return opcionesPreguntaEncuestaRepository.save(opcion);
        } else {

            return null;
        }
    }
}