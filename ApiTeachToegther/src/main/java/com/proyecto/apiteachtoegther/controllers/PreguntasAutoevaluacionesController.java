package com.proyecto.apiteachtoegther.controllers;

import com.proyecto.apiteachtoegther.dto.PreguntaAutoevaluacionDTO;
import com.proyecto.apiteachtoegther.models.AutoevaluacionesEntity;
import com.proyecto.apiteachtoegther.models.PerfilesEntity;
import com.proyecto.apiteachtoegther.models.PreguntasAutoevaluacionEntity;
import com.proyecto.apiteachtoegther.models.UsuariosEntity;
import com.proyecto.apiteachtoegther.services.AutoevaluacionesService;
import com.proyecto.apiteachtoegther.services.PreguntasAutoevaluacionService;
import jakarta.persistence.EntityNotFoundException;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.server.ResponseStatusException;

import java.util.ArrayList;
import java.util.Optional;

@RestController
@RequestMapping(path = "/pregunta")
public class PreguntasAutoevaluacionesController {
    @Autowired
    private PreguntasAutoevaluacionService preguntasAutoevaluacionService;
    @Autowired
    private AutoevaluacionesService autoevaluacionesService;

    @GetMapping(path = "")
    public ResponseEntity<ArrayList<PreguntasAutoevaluacionEntity>> getPreguntasAutoevaluaciones() {
        return ResponseEntity.ok(this.preguntasAutoevaluacionService.getAllPreguntasAutoevaluaciones());
    }

    @PostMapping(path = "")
    public ResponseEntity<PreguntasAutoevaluacionEntity> updateByID(@RequestBody PreguntaAutoevaluacionDTO preguntaDTO) {
        Optional<AutoevaluacionesEntity> autoevaluacionesEntity = this.autoevaluacionesService.getById(preguntaDTO.getId_autoevaluacion());
        if (!autoevaluacionesEntity.isPresent()) {
            return ResponseEntity.status(HttpStatus.NOT_FOUND).build();
        }
        PreguntasAutoevaluacionEntity preguntasAutoevaluacionEntity = new PreguntasAutoevaluacionEntity();
        preguntasAutoevaluacionEntity.setIdAutoevaluacion(autoevaluacionesEntity.get());
        preguntasAutoevaluacionEntity.setEnunciadoPregunta(preguntaDTO.getEnunciado_pregunta());
        try {
            return ResponseEntity.ok(this.preguntasAutoevaluacionService.savePregunta(preguntasAutoevaluacionEntity));
        } catch (Exception e) {
            e.printStackTrace();
            return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR).build();
        }
    }

    @GetMapping(path = "/{id}")
    public ResponseEntity<PreguntasAutoevaluacionEntity> getPreguntaById(@PathVariable Integer id) {
        Optional<PreguntasAutoevaluacionEntity> preguntasAutoevaluacionEntity = this.preguntasAutoevaluacionService.getById(id);
        if (!preguntasAutoevaluacionEntity.isPresent()) {
            return ResponseEntity.status(HttpStatus.NOT_FOUND).build();
        }
        return ResponseEntity.ok(preguntasAutoevaluacionEntity.get());
    }

    @DeleteMapping(path = "/{id}")
    public String deleteById(@PathVariable Integer id) {
        boolean ok = this.preguntasAutoevaluacionService.deletePregunta(id);
        if (ok) {
            return "Pregunta con id " + id + " borrado.";
        } else {
            return "Error, no se encuentra la pregunta con id " + id + ".";
        }
    }
    @PutMapping(path = "")
    public PreguntasAutoevaluacionEntity updateById(@RequestBody PreguntaAutoevaluacionDTO preguntaAutoevaluacionDTO){
        try {
            int id =preguntaAutoevaluacionDTO.getId_pregunta(); // Obtener el ID del DTO
            Optional<PreguntasAutoevaluacionEntity> preguntasAutoevaluacionEntity = this.preguntasAutoevaluacionService.getById(preguntaAutoevaluacionDTO.getId_pregunta());
            Optional<AutoevaluacionesEntity> autoevaluacionesEntity = this.autoevaluacionesService.getById(preguntaAutoevaluacionDTO.getId_autoevaluacion());
            if (!preguntasAutoevaluacionEntity.isPresent()) {
                throw new EntityNotFoundException("La pregunta con ID " + id + " no existe en la base de datos.");
            }
            if (!autoevaluacionesEntity.isPresent()) {
                throw new EntityNotFoundException("El ID de la autoevaluacion no existe");
            }
            PreguntasAutoevaluacionEntity preguntaFinal=preguntasAutoevaluacionEntity.get();
            preguntaFinal.setIdPregunta(preguntaAutoevaluacionDTO.getId_pregunta());
            preguntaFinal.setIdAutoevaluacion(autoevaluacionesEntity.get());
            preguntaFinal.setEnunciadoPregunta(preguntaAutoevaluacionDTO.getEnunciado_pregunta());

            return this.preguntasAutoevaluacionService.updateById(preguntaFinal, id);
        } catch (EntityNotFoundException e) {

            throw new ResponseStatusException(HttpStatus.NOT_FOUND, e.getMessage(), e);
        } catch (Exception e) {

            throw new ResponseStatusException(HttpStatus.INTERNAL_SERVER_ERROR, "Error al actualizar la pregunta: " + e.getMessage(), e);
        }
}}
