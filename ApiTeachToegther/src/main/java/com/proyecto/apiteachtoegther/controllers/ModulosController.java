package com.proyecto.apiteachtoegther.controllers;

import com.proyecto.apiteachtoegther.dto.AlumnoModulosDTO;
import com.proyecto.apiteachtoegther.dto.AutoevaluacionModuloDTO;
import com.proyecto.apiteachtoegther.dto.MensajeDTO;
import com.proyecto.apiteachtoegther.dto.ModuloDTO;
import com.proyecto.apiteachtoegther.models.MensajesEntity;
import com.proyecto.apiteachtoegther.models.ModulosEntity;
import com.proyecto.apiteachtoegther.models.UsuariosEntity;
import com.proyecto.apiteachtoegther.services.MensajesService;
import com.proyecto.apiteachtoegther.services.ModulosService;
import com.proyecto.apiteachtoegther.services.UsuariosService;
import jakarta.persistence.EntityNotFoundException;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.server.ResponseStatusException;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

@RestController
@RequestMapping("/modulo")
public class ModulosController {
    @Autowired
    private ModulosService modulosService;
    @Autowired
    private UsuariosService usuariosService;
    private String codigo;

    @GetMapping("")
    public ResponseEntity<ArrayList<ModulosEntity>> getModulos() {
        ArrayList<ModulosEntity> modulos = this.modulosService.getModulos();
        return ResponseEntity.ok(modulos);
    }

    @PostMapping(path = "")
    public ResponseEntity<ModulosEntity> saveMensaje(@RequestBody ModuloDTO modulo) {
        Optional<UsuariosEntity> existingProfesorOptional = this.usuariosService.getById(modulo.getId_profesor());
        if (!existingProfesorOptional.isPresent()) {

            return ResponseEntity.status(HttpStatus.CONFLICT).build();
        } else {

            UsuariosEntity profesorEntity = existingProfesorOptional.get();
            ModulosEntity moduloEntity = new ModulosEntity();
            moduloEntity.setIdProfesor(profesorEntity);
            moduloEntity.setHorario(modulo.getHorario());
            moduloEntity.setHoras(modulo.getHoras());
            moduloEntity.setNombre(modulo.getNombre());
            moduloEntity.setCodigo(modulo.getCodigo());
            moduloEntity.setDias(modulo.getDias());

            try {
                this.modulosService.saveModulos(moduloEntity);
                return ResponseEntity.ok(moduloEntity);
            } catch (Exception e) {
                e.printStackTrace();
                return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR).build();
            }
        }
    }

    @GetMapping(path = "/{id}")
    public ResponseEntity<ModulosEntity> getModulosById(@PathVariable Integer id) {
        Optional<ModulosEntity> modulosOptional = this.modulosService.getById(id);
        if (modulosOptional.isPresent()) {
            return ResponseEntity.ok(modulosOptional.get());
        } else {
            return ResponseEntity.notFound().build();
        }
    }

    @PutMapping("")
    public ModulosEntity updateModuloById(@RequestBody ModuloDTO moduloDTO) {
        try {
            int id = moduloDTO.getId_modulo(); // Obtener el ID del DTO
            Optional<ModulosEntity> existingModuloOptional = this.modulosService.getById(moduloDTO.getId_modulo());
            Optional<UsuariosEntity> existingProfesorOptional = this.usuariosService.getById(moduloDTO.getId_profesor());

            if (!existingModuloOptional.isPresent()) {
                throw new EntityNotFoundException("El modulo con ID " + id + " no existe en la base de datos.");
            }
            if (!existingProfesorOptional.isPresent()) {
                throw new EntityNotFoundException("El ID del profesor no existe");
            }

            UsuariosEntity usuarioFinal = existingProfesorOptional.get();
            ModulosEntity moduloFinal = existingModuloOptional.get();
            moduloFinal.setIdProfesor(usuarioFinal);
            moduloFinal.setNombre(moduloDTO.getNombre());
            moduloFinal.setHoras(moduloDTO.getHoras());
            moduloFinal.setHorario(moduloDTO.getHorario());
            moduloFinal.setDias(moduloDTO.getDias());
            moduloFinal.setCodigo(moduloDTO.getCodigo());
            return modulosService.updateById(moduloFinal, id);
        } catch (EntityNotFoundException e) {

            throw new ResponseStatusException(HttpStatus.NOT_FOUND, e.getMessage(), e);
        } catch (Exception e) {

            throw new ResponseStatusException(HttpStatus.INTERNAL_SERVER_ERROR, "Error al actualizar el modulo: " + e.getMessage(), e);
        }
    }

    @DeleteMapping(path = "/{id}")
    public String deleteById(@PathVariable("id") Integer id) {
        boolean ok = this.modulosService.deleteModulo(id);
        if (ok) {
            return "Modulo con id " + id + " borrado.";
        } else {
            return "Error, no se encuentra el modulo con id " + id + ".";
        }
    }

    @GetMapping(path = "/alumnosModulos/{idAutoevaluacion}")
    public ResponseEntity<List<AlumnoModulosDTO>> getAlumnosModulosByAutoevaluacionID(@PathVariable int idAutoevaluacion) {
        List<AlumnoModulosDTO> lista = this.modulosService.getAlumnoModulosByAutoevaluacionID(idAutoevaluacion);
        return ResponseEntity.ok(lista);
    }

    @GetMapping(path = "/auto/{idAuto}")
    public ResponseEntity<List<ModulosEntity>> getModuloByAutoevaluacionID(@PathVariable int idAuto) {
        List<ModulosEntity> modulos = this.modulosService.getModuloByAutoevaluacionId(idAuto);
        return ResponseEntity.ok(modulos);
    }
    @GetMapping(path = "/modAuto/{idMod}")
    public ResponseEntity<List<AutoevaluacionModuloDTO>> getAutoevaluacionesByModuloID(@PathVariable int idMod) {
        List<AutoevaluacionModuloDTO> modulos = this.modulosService.getAutoevaluacionesByModuloID(idMod);
        return ResponseEntity.ok(modulos);
    }
}