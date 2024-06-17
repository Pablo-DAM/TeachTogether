package com.proyecto.apiteachtoegther.services;

import com.proyecto.apiteachtoegther.models.AutoevaluacionesUsuariosEntityPK;
import com.proyecto.apiteachtoegther.models.UsuariosEntity;
import com.proyecto.apiteachtoegther.models.UsuariosModulosEntity;
import com.proyecto.apiteachtoegther.models.UsuariosModulosEntityPK;
import com.proyecto.apiteachtoegther.repositories.IUsuariosModulosRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

@Service
public class UsuariosModulosService {
    @Autowired
    private IUsuariosModulosRepository usuariosModulosRepository;

    public List<UsuariosModulosEntity> getAllUsuariosModulos() {
        return usuariosModulosRepository.findAll();
    }

    public Optional<UsuariosModulosEntity> getById(UsuariosModulosEntityPK id) {
        return usuariosModulosRepository.findById(id);
    }

    public UsuariosModulosEntity saveUsuarioModulo(UsuariosModulosEntity usuarioModulo) {
        return usuariosModulosRepository.save(usuarioModulo);
    }

    public UsuariosModulosEntity updateById(UsuariosModulosEntity usuarioModulo) {
        return usuariosModulosRepository.save(usuarioModulo);
    }

    public boolean deleteUsuarioModulo(UsuariosModulosEntityPK id) {
        if (usuariosModulosRepository.existsById(id)) {
            usuariosModulosRepository.deleteById(id);
            return true;
        } else {
            return false;
        }
    }
}
