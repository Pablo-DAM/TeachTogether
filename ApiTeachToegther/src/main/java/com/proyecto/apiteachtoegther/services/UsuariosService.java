package com.proyecto.apiteachtoegther.services;

import com.proyecto.apiteachtoegther.dto.UsuarioPerfilDTO;
import com.proyecto.apiteachtoegther.models.PerfilesEntity;
import com.proyecto.apiteachtoegther.models.UsuariosEntity;
import com.proyecto.apiteachtoegther.repositories.IUsuariosRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

@Service
public class UsuariosService {
    @Autowired
    IUsuariosRepository usuariosRepository;

    public ArrayList<UsuariosEntity> getUsuarios() {
        return (ArrayList<UsuariosEntity>) usuariosRepository.findAll();
    }

    public UsuariosEntity saveUsuario(UsuariosEntity usuario) {
        return usuariosRepository.save(usuario);
    }

    public Optional<UsuariosEntity> getById(Integer id) {
        return usuariosRepository.findById(id);
    }

    public UsuariosEntity updateById(UsuariosEntity request, Integer id) {
        UsuariosEntity usuario = usuariosRepository.findById(id).get();
        usuario.setIdUsuario(request.getIdUsuario());
        usuario.setUsuario(request.getUsuario());
        usuario.setPassword(request.getPassword());
        usuario.setRol(request.getRol());
        usuariosRepository.save(usuario);
        return usuario;
    }

    public Boolean deleteUsuario(Integer id) {
        try {
            usuariosRepository.deleteById(id);
            return true;
        } catch (Exception e) {
            return false;
        }
    }
    public List<PerfilesEntity> obtenerPerfilesPorUsuario(String usuario) {
        return usuariosRepository.findPerfilesByUsuario(usuario);
    }
    public int obtenerId_UsuarioPorUSuario(String usuario){
        return usuariosRepository.findIdByUsuario(usuario);
    }

    public List<UsuarioPerfilDTO>getUsuarioYPerfilByIDModulo(int idMod){
        return usuariosRepository.getUsuariosYPerfilByIDModulo(idMod);
    }
}
