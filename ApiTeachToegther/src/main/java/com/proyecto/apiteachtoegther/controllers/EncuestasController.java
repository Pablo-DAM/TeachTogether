package com.proyecto.apiteachtoegther.controllers;


import com.proyecto.apiteachtoegther.dto.EncuestaDTO;
import com.proyecto.apiteachtoegther.models.EncuestasEntity;
import com.proyecto.apiteachtoegther.models.UsuariosEntity;
import com.proyecto.apiteachtoegther.services.EncuestasService;
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
@RequestMapping(path = "/encuesta")
public class EncuestasController {
    @Autowired
    private EncuestasService encuestasService;
    @Autowired
    private UsuariosService usuariosService;


    @GetMapping(path = "")
    public ResponseEntity<ArrayList<EncuestasEntity>> getAllEncuestas() {
        ArrayList<EncuestasEntity> encuestas = encuestasService.getEncuestas();
        return ResponseEntity.ok(encuestas);
    }


    @PostMapping(path = "")
    public ResponseEntity<EncuestasEntity> saveEncuesta(@RequestBody EncuestaDTO encuestaDTO) {
        Optional<UsuariosEntity> profesorOptional = usuariosService.getById(encuestaDTO.getId_profesor_realizador());
        if (!profesorOptional.isPresent()) {
            return ResponseEntity.status(HttpStatus.CONFLICT).build();
        }
        EncuestasEntity nuevaEncuesta = new EncuestasEntity();
        nuevaEncuesta.setTitulo(encuestaDTO.getTitulo());
        nuevaEncuesta.setIdProfesorRealizador(profesorOptional.get());
        try {
            EncuestasEntity encuestaGuardada = encuestasService.saveEncuesta(nuevaEncuesta);
            return ResponseEntity.ok(encuestaGuardada);
        } catch (Exception e) {
            e.printStackTrace();
            return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR).build();
        }
    }


    @GetMapping(path = "/{id}")
    public ResponseEntity<EncuestasEntity> getEncuestaById(@PathVariable Integer id) {
        Optional<EncuestasEntity> encuestaOptional = encuestasService.getById(id);
        if (encuestaOptional.isPresent()) {
            return ResponseEntity.ok(encuestaOptional.get());
        } else {
            return ResponseEntity.notFound().build();
        }
    }


    @PutMapping(path = "")
    public ResponseEntity<EncuestasEntity> updateEncuestaById(@RequestBody EncuestaDTO encuestaDTO) {

        Optional<UsuariosEntity> profesor = usuariosService.getById(encuestaDTO.getId_profesor_realizador());
        if (!profesor.isPresent()) {
            throw new EntityNotFoundException("El profesor con ID " + encuestaDTO.getId_profesor_realizador() + " no existe");
        }
        Optional<EncuestasEntity> encuestaOptional = encuestasService.getById(encuestaDTO.getId_encuesta());
        if (!encuestaOptional.isPresent()) {
            return ResponseEntity.status(HttpStatus.NOT_FOUND).build();
        }
        EncuestasEntity encuestaActualizada = encuestaOptional.get();
        UsuariosEntity profeFinal=profesor.get();
        encuestaActualizada.setTitulo(encuestaDTO.getTitulo());
        encuestaActualizada.setIdProfesorRealizador(profeFinal);
        this.encuestasService.updateById(encuestaActualizada,encuestaDTO.getId_encuesta());
        return ResponseEntity.ok(encuestaActualizada);

    }


    @DeleteMapping(path = "/{id}")
    public ResponseEntity<?> deleteEncuestaById(@PathVariable Integer id) {
        boolean ok = encuestasService.deleteEncuesta(id);
        if (ok) {
            return ResponseEntity.ok().build();
        } else {
            return ResponseEntity.status(HttpStatus.NOT_FOUND).build();
        }
    }
}