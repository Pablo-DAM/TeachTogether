package com.proyecto.apiteachtoegther.services;

import com.proyecto.apiteachtoegther.dto.AutoevaluacionDTO;
import com.proyecto.apiteachtoegther.dto.IdDTO;
import com.proyecto.apiteachtoegther.dto.UsuariosPerfilModuloDTO;
import com.proyecto.apiteachtoegther.models.AutoevaluacionesEntity;
import com.proyecto.apiteachtoegther.models.MensajesEntity;
import com.proyecto.apiteachtoegther.models.ModulosEntity;
import com.proyecto.apiteachtoegther.models.UsuariosModulosEntity;
import com.proyecto.apiteachtoegther.repositories.IAutoevaluacionesRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

@Service
public class AutoevaluacionesService {
    @Autowired
    IAutoevaluacionesRepository autoevaluacionesRepository;
    public ArrayList<AutoevaluacionesEntity> getAutoevaluaciones(){
        return (ArrayList<AutoevaluacionesEntity>) autoevaluacionesRepository.findAll();
    }
    public AutoevaluacionesEntity saveAutoevaluacion(AutoevaluacionesEntity autoevaluacion) {
        return autoevaluacionesRepository.save(autoevaluacion);
    }
    public Optional<AutoevaluacionesEntity> getById(Integer id) {
        return autoevaluacionesRepository.findById(id);
    }
    public AutoevaluacionesEntity updateById(AutoevaluacionesEntity request, Integer id) {
        AutoevaluacionesEntity autoevaluacion = autoevaluacionesRepository.findById(id).get();
        autoevaluacion.setIdAutoevaluacion(request.getIdAutoevaluacion());
        autoevaluacion.setTitulo(request.getTitulo());
        autoevaluacion.setIdProfesorCreador(request.getIdProfesorCreador());
        autoevaluacionesRepository.save(autoevaluacion);
        return autoevaluacion;
    }

    public boolean deleteAutoevaluacion(Integer id) {
        if (autoevaluacionesRepository.existsById(id)) {
            autoevaluacionesRepository.deleteById(id);
            return true;
        } else {
            return false;
        }
    }
    public List<AutoevaluacionesEntity> getAutoevaluacionesByProfesorID(int id){
        List<AutoevaluacionesEntity>lista=this.autoevaluacionesRepository.listaAutoevaluaciones(id);
        return lista;
    }


    public List<UsuariosPerfilModuloDTO> getModulosByAutoevaluacionID(int idAutoevaluacion) {
        return autoevaluacionesRepository.listaModulos(idAutoevaluacion);
    }
    public List<IdDTO>getUsuarioIdWhereUsuarioAutoevaluacionIsNull(int idAu){
        return autoevaluacionesRepository.listaIdUsuario(idAu);
    }
}
