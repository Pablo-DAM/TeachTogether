package com.proyecto.apiteachtoegther.controllers;

import com.proyecto.apiteachtoegther.dto.AutoevaluacionUsuarioDTO;
import com.proyecto.apiteachtoegther.dto.PerfilDTO;
import com.proyecto.apiteachtoegther.models.*;
import com.proyecto.apiteachtoegther.services.AutoevaluacionesService;
import com.proyecto.apiteachtoegther.services.AutoevaluacionesUsuariosService;
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
@RequestMapping("/autoevaluacionUsuario")
public class AutoevaluacionesUsuariosController {
    @Autowired
    private AutoevaluacionesUsuariosService autoevaluacionesUsuariosService;
    @Autowired
    private UsuariosService usuariosService;
    @Autowired
    private AutoevaluacionesService autoevaluacionesService;

    @GetMapping(path = "")
    public ResponseEntity<List<AutoevaluacionesUsuariosEntity>> getAutoevaluacionesUsuarios() {
        List<AutoevaluacionesUsuariosEntity> autoevaluacionesUsuariosEntities = this.autoevaluacionesUsuariosService.getAllAutoevaluacionesUsuarios();
        return ResponseEntity.ok(autoevaluacionesUsuariosEntities);
    }

    @PostMapping(path = "")
    public ResponseEntity<?> saveAutoevaluacionUsuario(@RequestBody AutoevaluacionUsuarioDTO autoevaluacionUsuarioDTO) {
        Optional<UsuariosEntity> existingUsuarioOptional = this.usuariosService.getById(autoevaluacionUsuarioDTO.getId_alumno());
        Optional<AutoevaluacionesEntity> existingAutoevaluacionOptional = this.autoevaluacionesService.getById(autoevaluacionUsuarioDTO.getId_autoevaluacion());
        if (!existingUsuarioOptional.isPresent()) {
            // El ID del usuario no existe, ERROR
            return ResponseEntity.status(HttpStatus.CONFLICT).body("Error: El ID del usuario no existe.");
        }
        if (!existingAutoevaluacionOptional.isPresent()) {
            return ResponseEntity.status(HttpStatus.CONFLICT) .body("Error: El ID de la autoevaluación no existe.");
        }
        AutoevaluacionesUsuariosEntityPK existe = new AutoevaluacionesUsuariosEntityPK();
        existe.setIdAutoevaluacion(autoevaluacionUsuarioDTO.getId_autoevaluacion());
        existe.setIdAlumno(autoevaluacionUsuarioDTO.getId_alumno());
        if (this.autoevaluacionesUsuariosService.getAutoevaluacionUsuarioById(existe).isPresent()) {
            return ResponseEntity.status(HttpStatus.CONFLICT).body("Error: El usuario ya está registrado para esta autoevaluación.");
        }
        UsuariosEntity usuarioEntity = existingUsuarioOptional.get();
        AutoevaluacionesEntity autoevaluacionesEntity = existingAutoevaluacionOptional.get();
        AutoevaluacionesUsuariosEntity autoevaluacionesUsuarios = new AutoevaluacionesUsuariosEntity();
        autoevaluacionesUsuarios.setAlumno(usuarioEntity);
        autoevaluacionesUsuarios.setAutoevaluacion(autoevaluacionesEntity);
        autoevaluacionesUsuarios.setFecha_realizacion(autoevaluacionUsuarioDTO.getFecha_realizacion());
        autoevaluacionesUsuarios.setIdAutoevaluacion(autoevaluacionUsuarioDTO.getId_autoevaluacion());
        autoevaluacionesUsuarios.setIdAlumno(autoevaluacionUsuarioDTO.getId_alumno());

        try {
            this.autoevaluacionesUsuariosService.saveAutoevaluacionUsuario(autoevaluacionesUsuarios);
            return ResponseEntity.ok(autoevaluacionesUsuarios);
        } catch (Exception e) {
            e.printStackTrace();
            return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR).build();
        }
    }

    @GetMapping(path = "/{idAutoevaluacion}/{idAlumno}")
    public ResponseEntity<AutoevaluacionesUsuariosEntity> getAutoevaluacionUsuarioById(@PathVariable int idAutoevaluacion,
                                                                                       @PathVariable int idAlumno) {
        AutoevaluacionesUsuariosEntityPK idPK = new AutoevaluacionesUsuariosEntityPK();
        idPK.setIdAutoevaluacion(idAutoevaluacion);
        idPK.setIdAlumno(idAlumno);
        Optional<AutoevaluacionesUsuariosEntity> autoevaluacionesEntityOptional = this.autoevaluacionesUsuariosService.getAutoevaluacionUsuarioById(idPK);
        if (autoevaluacionesEntityOptional.isPresent()) {
            AutoevaluacionesUsuariosEntity autoevaluacionesUsuariosEntity = autoevaluacionesEntityOptional.get();
            return ResponseEntity.ok(autoevaluacionesUsuariosEntity);
        } else {
            return ResponseEntity.notFound().build();
        }
    }

    @PutMapping("")
    public AutoevaluacionesUsuariosEntity updateAutoEvaluacionUsuarioById(@RequestBody AutoevaluacionUsuarioDTO autoevaluacionUsuarioDTO) {
        try {
            AutoevaluacionesUsuariosEntityPK autoevaluacionesUsuariosEntityPK = new AutoevaluacionesUsuariosEntityPK();
            autoevaluacionesUsuariosEntityPK.setIdAlumno(autoevaluacionUsuarioDTO.getId_alumno());
            autoevaluacionesUsuariosEntityPK.setIdAutoevaluacion(autoevaluacionUsuarioDTO.getId_autoevaluacion());
            Optional<AutoevaluacionesUsuariosEntity> existingAutoevaluacionesUsuariosEntityOptional = this.autoevaluacionesUsuariosService.getAutoevaluacionUsuarioById(autoevaluacionesUsuariosEntityPK);
            if (!existingAutoevaluacionesUsuariosEntityOptional.isPresent()) {
                throw new EntityNotFoundException(" Ese ID no existe en la base de datos.");
            }
            AutoevaluacionesUsuariosEntity autoevaluacionesUsuariosEntity = new AutoevaluacionesUsuariosEntity();
            autoevaluacionesUsuariosEntity.setIdAlumno(autoevaluacionUsuarioDTO.getId_alumno());
            autoevaluacionesUsuariosEntity.setIdAutoevaluacion(autoevaluacionUsuarioDTO.getId_autoevaluacion());
            autoevaluacionesUsuariosEntity.setFecha_realizacion(autoevaluacionUsuarioDTO.getFecha_realizacion());
            return autoevaluacionesUsuariosService.updateAutoevaluacionUsuario(autoevaluacionesUsuariosEntity);
        } catch (EntityNotFoundException e) {

            throw new ResponseStatusException(HttpStatus.NOT_FOUND, e.getMessage(), e);
        } catch (Exception e) {

            throw new ResponseStatusException(HttpStatus.INTERNAL_SERVER_ERROR, "Error al actualizar : " + e.getMessage(), e);
        }
    }

    @DeleteMapping(path = "/{id_autoevaluacion}/{id_alumno}")

    public String deleteById(@PathVariable int id_autoevaluacion, @PathVariable int id_alumno) {
        AutoevaluacionesUsuariosEntityPK autoevaluacionesUsuariosEntityPK = new AutoevaluacionesUsuariosEntityPK();
        autoevaluacionesUsuariosEntityPK.setIdAutoevaluacion(id_autoevaluacion);
        autoevaluacionesUsuariosEntityPK.setIdAlumno(id_alumno);
        boolean ok = this.autoevaluacionesUsuariosService.deleteAutoevaluacionUsuario(autoevaluacionesUsuariosEntityPK);
        if (ok) {
            return "Fila borrada.";
        } else {
            return "Error, no se encuentra el ID.";
        }
    }
}



