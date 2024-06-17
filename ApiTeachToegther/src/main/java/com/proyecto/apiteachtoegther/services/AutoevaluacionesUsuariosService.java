package com.proyecto.apiteachtoegther.services;

import com.proyecto.apiteachtoegther.models.*;

import com.proyecto.apiteachtoegther.repositories.IAutoevaluacionesUsuariosRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

@Service
public class AutoevaluacionesUsuariosService {
    @Autowired
    private IAutoevaluacionesUsuariosRepository autoevaluacionesUsuariosRepository;
    public List<AutoevaluacionesUsuariosEntity> getAllAutoevaluacionesUsuarios() {
        return autoevaluacionesUsuariosRepository.findAll();
    }

    public AutoevaluacionesUsuariosEntity saveAutoevaluacionUsuario(AutoevaluacionesUsuariosEntity autoevaluacionUsuario) {
        return autoevaluacionesUsuariosRepository.save(autoevaluacionUsuario);
    }

    public Optional<AutoevaluacionesUsuariosEntity> getAutoevaluacionUsuarioById(AutoevaluacionesUsuariosEntityPK id) {
        return autoevaluacionesUsuariosRepository.findById(id);
    }

    public AutoevaluacionesUsuariosEntity updateAutoevaluacionUsuario(AutoevaluacionesUsuariosEntity newData) {
        return autoevaluacionesUsuariosRepository.save(newData);
    }


    public boolean deleteAutoevaluacionUsuario(AutoevaluacionesUsuariosEntityPK id) {
        if (autoevaluacionesUsuariosRepository.existsById(id)) {
            autoevaluacionesUsuariosRepository.deleteById(id);
            return true;
        } else {
            return false;
        }
    }
}

