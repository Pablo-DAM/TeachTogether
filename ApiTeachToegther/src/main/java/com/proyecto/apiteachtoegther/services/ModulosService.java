package com.proyecto.apiteachtoegther.services;

import com.proyecto.apiteachtoegther.dto.AlumnoModulosDTO;
import com.proyecto.apiteachtoegther.dto.AutoevaluacionModuloDTO;
import com.proyecto.apiteachtoegther.models.AutoevaluacionesEntity;
import com.proyecto.apiteachtoegther.models.ModulosEntity;
import com.proyecto.apiteachtoegther.repositories.AlumnoModulosProjection;
import com.proyecto.apiteachtoegther.repositories.IAutoevaluacionesRepository;
import com.proyecto.apiteachtoegther.repositories.IModulosRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;
import java.util.stream.Collectors;

@Service
public class ModulosService {
    @Autowired
    IModulosRepository modulosRepository;

    public ArrayList<ModulosEntity> getModulos() {
        return (ArrayList<ModulosEntity>) modulosRepository.findAll();
    }

    public ModulosEntity saveModulos(ModulosEntity modulo) {
        return modulosRepository.save(modulo);
    }

    public Optional<ModulosEntity> getById(Integer id) {
        return modulosRepository.findById(id);
    }

    public ModulosEntity updateById(ModulosEntity request, Integer id) {
        ModulosEntity modulosEntity = this.modulosRepository.findById(id).get();
        modulosEntity.setIdModulo(id);
        modulosEntity.setHorario(request.getHorario());
        modulosEntity.setHoras(request.getHoras());
        modulosEntity.setNombre(request.getNombre());
        modulosEntity.setIdProfesor(request.getIdProfesor());
        modulosEntity.setCodigo(request.getCodigo());
        modulosEntity.setDias(request.getDias());
        this.modulosRepository.save(modulosEntity);
        return modulosEntity;
    }

    public boolean deleteModulo(Integer id) {
        if (this.modulosRepository.existsById(id)) {
            this.modulosRepository.deleteById(id);
            return true;
        } else {
            return false;
        }
    }

    public List<AlumnoModulosDTO> getAlumnoModulosByAutoevaluacionID(int idAu) {
        List<AlumnoModulosProjection> projections = this.modulosRepository.getAlumnosYModulosByAuevaluacionID(idAu);
        return projections.stream()
                .map(p -> new AlumnoModulosDTO(p.getIdModulo(), p.getIdAlumno()))
                .collect(Collectors.toList());
    }

    public List<ModulosEntity> getModuloByAutoevaluacionId(int idAu) {
        List<ModulosEntity> modulo = this.modulosRepository.getModuloByIdAutoevaluacion(idAu);
        return modulo;
    }

    public List<AutoevaluacionModuloDTO> getAutoevaluacionesByModuloID(int idMod) {
        List<AutoevaluacionModuloDTO> modulos = this.modulosRepository.getAutoevaluacionesByIDModulo(idMod);
        return  modulos;
    }
}
