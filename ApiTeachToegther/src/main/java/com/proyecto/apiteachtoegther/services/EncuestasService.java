package com.proyecto.apiteachtoegther.services;

import com.proyecto.apiteachtoegther.models.EncuestasEntity;
import com.proyecto.apiteachtoegther.repositories.IEncuestasRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.Optional;


@Service
public class EncuestasService {
    @Autowired
    private IEncuestasRepository encuestasRepository;


    public ArrayList<EncuestasEntity> getEncuestas() {
        return (ArrayList<EncuestasEntity>) encuestasRepository.findAll();
    }


    public EncuestasEntity saveEncuesta(EncuestasEntity encuesta) {
        return encuestasRepository.save(encuesta);
    }


    public Optional<EncuestasEntity> getById(Integer id) {
        return encuestasRepository.findById(id);
    }


    public EncuestasEntity updateById(EncuestasEntity request, Integer id) {
        return encuestasRepository.findById(id).map(encuesta -> {
            encuesta.setTitulo(request.getTitulo());
            encuesta.setIdProfesorRealizador(request.getIdProfesorRealizador());
            return encuestasRepository.save(encuesta);
        }).orElseGet(() -> {
            request.setIdEncuesta(id);
            return encuestasRepository.save(request);
        });
    }


    public Boolean deleteEncuesta(Integer id) {

        if (this.encuestasRepository.existsById(id)) {
            this.encuestasRepository.deleteById(id);
            return true;
        } else {
            return false;
        }
    }

}
