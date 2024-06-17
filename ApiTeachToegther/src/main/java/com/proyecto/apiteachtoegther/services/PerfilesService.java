package com.proyecto.apiteachtoegther.services;

import com.proyecto.apiteachtoegther.models.MensajesEntity;
import com.proyecto.apiteachtoegther.models.PerfilesEntity;
import com.proyecto.apiteachtoegther.repositories.IPerfilesRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.Optional;

@Service
public class PerfilesService {
    @Autowired
    private IPerfilesRepository perfilesRepository;
    public ArrayList<PerfilesEntity> getPerfiles() {
        return (ArrayList<PerfilesEntity>) perfilesRepository.findAll();
    }
    public PerfilesEntity savePerfil(PerfilesEntity perfil) {
        return perfilesRepository.save(perfil);
    }

    public Optional<PerfilesEntity> getById(Integer id) {
        return perfilesRepository.findById(id);
    }

    public PerfilesEntity updateById(PerfilesEntity request, Integer id) {
        PerfilesEntity perfil = perfilesRepository.findById(id).get();
        perfil.setIdPerfil(request.getIdPerfil());
        perfil.setApellidos(request.getApellidos());
        perfil.setNombre(request.getNombre());
        perfil.setIdUsuario(request.getIdUsuario());
        perfil.setFechaNacimiento(request.getFechaNacimiento());
        perfilesRepository.save(perfil);
        return perfil;
    }

    public boolean deletePerfil(Integer id) {
        if (perfilesRepository.existsById(id)) {
            perfilesRepository.deleteById(id);
            return true;
        } else {
            return false;
        }
    }
    public PerfilesEntity obtenerPerfilPorIdUsuario(Integer idUsuario) {
        return perfilesRepository.findByIdUsuario_IdUsuario(idUsuario)
                .orElseThrow(() -> new RuntimeException("No se encontró un perfil para el usuario con ID: " + idUsuario));
    }
}
