package com.proyecto.apiteachtoegther.services;

import com.proyecto.apiteachtoegther.models.*;
import com.proyecto.apiteachtoegther.repositories.IEncuestasRepository;
import com.proyecto.apiteachtoegther.repositories.IUsuariosEncuestasRepository;

import com.proyecto.apiteachtoegther.repositories.IUsuariosRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class UsuariosEncuestasService {
    @Autowired
    private IUsuariosEncuestasRepository usuariosEncuestasRepository;

    public List<UsuariosEncuestasEntity> getAll() {
        return this.usuariosEncuestasRepository.findAll();
    }

    public UsuariosEncuestasEntity saveUsuarioEncuesta(UsuariosEncuestasEntity usuarioEncuesta) {
        return this.usuariosEncuestasRepository.save(usuarioEncuesta);
    }
    public Optional<UsuariosEncuestasEntity> getById(UsuariosEncuestasEntityPK id) {
        return usuariosEncuestasRepository.findById(id);
    }


    public UsuariosEncuestasEntity updateById(UsuariosEncuestasEntity usuarioEncuesta) {
        return usuariosEncuestasRepository.save(usuarioEncuesta);
    }

    public boolean deleteUsuarioEncuesta(UsuariosEncuestasEntityPK id) {
        if (usuariosEncuestasRepository.existsById(id)) {
            usuariosEncuestasRepository.deleteById(id);
            return true;
        } else {
            return false;
        }
    }
}
