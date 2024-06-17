package com.proyecto.apiteachtoegther.controllers;

import com.proyecto.apiteachtoegther.dto.MensajeDTO;
import com.proyecto.apiteachtoegther.dto.PerfilDTO;
import com.proyecto.apiteachtoegther.dto.PerfilPUTDTO;
import com.proyecto.apiteachtoegther.models.MensajesEntity;
import com.proyecto.apiteachtoegther.models.PerfilesEntity;
import com.proyecto.apiteachtoegther.models.UsuariosEntity;
import com.proyecto.apiteachtoegther.services.PerfilesService;
import com.proyecto.apiteachtoegther.services.UsuariosService;
import jakarta.persistence.EntityNotFoundException;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.server.ResponseStatusException;

import java.util.ArrayList;
import java.util.Optional;

@RestController
@RequestMapping(path = "/perfil")
public class PerfilesController {
    @Autowired
    private PerfilesService perfilesService;
    @Autowired
    private UsuariosService usuariosService;

    @GetMapping(path = "")
    public ResponseEntity<ArrayList<PerfilesEntity>> getPerfil() {
        ArrayList<PerfilesEntity> perfiles = this.perfilesService.getPerfiles();
        return ResponseEntity.ok(perfiles);
    }

    @PostMapping(path = "")
    public ResponseEntity<PerfilesEntity> savePerfil(@RequestBody PerfilDTO perfilDTO) {

        Optional<UsuariosEntity>existingUsuario=usuariosService.getById(perfilDTO.getId_usuario());
        if(!existingUsuario.isPresent()){
            return ResponseEntity.notFound().build();
        }
        UsuariosEntity usuarioExistente=existingUsuario.get();

        PerfilesEntity perfilEntity = new PerfilesEntity();

        perfilEntity.setIdUsuario(usuarioExistente);
        perfilEntity.setFechaNacimiento(perfilDTO.getFecha_nacimiento());

        perfilEntity.setNombre(perfilDTO.getNombre());
        perfilEntity.setApellidos(perfilDTO.getApellidos());
        try {
            PerfilesEntity savedPerfil = this.perfilesService.savePerfil(perfilEntity);
            return ResponseEntity.ok(savedPerfil);
        } catch (Exception e) {
            e.printStackTrace();
            return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR).build();
        }
    }

    @GetMapping(path = "/{id}")
    public ResponseEntity<PerfilesEntity> getPerfilById(@PathVariable Integer id) {
        Optional<PerfilesEntity> perfilOptional = this.perfilesService.getById(id);
        if (perfilOptional.isPresent()) {
            return ResponseEntity.ok(perfilOptional.get());
        } else {
            return ResponseEntity.notFound().build();
        }
    }

    @PutMapping("")
    public ResponseEntity<PerfilesEntity> updatePerfilById(@RequestBody PerfilPUTDTO perfilDTO) {
        try {
            int id = perfilDTO.getId_perfil(); // Obtener el ID del DTO

            Optional<PerfilesEntity> existingPerfilOptional = perfilesService.getById(id);
            if (!existingPerfilOptional.isPresent()) {
                return ResponseEntity.notFound().build();
            }
            Optional<UsuariosEntity>existingUsuario=usuariosService.getById(perfilDTO.getId_usuario());
            if(!existingUsuario.isPresent()){
                return ResponseEntity.notFound().build();
            }
            UsuariosEntity usuExistente=existingUsuario.get();
            PerfilesEntity perfilFinal = existingPerfilOptional.get();
            perfilFinal.setApellidos(perfilDTO.getApellidos());
            perfilFinal.setNombre(perfilDTO.getNombre());
            perfilFinal.setFechaNacimiento(perfilDTO.getFecha_nacimiento());
            perfilFinal.setIdPerfil(perfilDTO.getId_perfil());
            perfilFinal.setIdUsuario(usuExistente);

            perfilesService.updateById(perfilFinal, id);
            return ResponseEntity.ok(perfilFinal);
        } catch (EntityNotFoundException e) {

            throw new ResponseStatusException(HttpStatus.NOT_FOUND, e.getMessage(), e);
        } catch (Exception e) {

            throw new ResponseStatusException(HttpStatus.INTERNAL_SERVER_ERROR, "Error al actualizar el perfil: " + e.getMessage(), e);
        }
    }


    @DeleteMapping(path = "/{id}")

    public String deleteById(@PathVariable("id") Integer id) {
        boolean ok = this.perfilesService.deletePerfil(id);
        if (ok) {
            return "Perfil con id " + id + " borrado.";
        } else {
            return "Error, no se encuentra el perfil con id " + id + ".";
        }
    }
    @GetMapping("/usuario/{idUsuario}")
    public ResponseEntity<PerfilesEntity> obtenerPerfilPorIdUsuario(@PathVariable Integer idUsuario) {
        try {
            PerfilesEntity perfil = perfilesService.obtenerPerfilPorIdUsuario(idUsuario);
            return ResponseEntity.ok(perfil);
        } catch (RuntimeException ex) {
            return ResponseEntity.notFound().build();
        }
    }
}

