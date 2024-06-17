package com.proyecto.apiteachtoegther.controllers;


import com.proyecto.apiteachtoegther.dto.PreguntaEncuestaDTO;
import com.proyecto.apiteachtoegther.models.EncuestasEntity;
import com.proyecto.apiteachtoegther.models.PreguntasEncuestaEntity;
import com.proyecto.apiteachtoegther.services.EncuestasService;
import com.proyecto.apiteachtoegther.services.PreguntasEncuestasService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;
import java.util.Optional;

@RestController
@RequestMapping(path = "/preguntaEncuesta")
public class PreguntasEncuestasController {

    @Autowired
    private PreguntasEncuestasService preguntasEncuestasService;

    @Autowired
    private EncuestasService encuestasService;

    @GetMapping(path = "")
    public ResponseEntity<ArrayList<PreguntasEncuestaEntity>> getAllPreguntasEncuesta() {
        ArrayList<PreguntasEncuestaEntity> preguntas = preguntasEncuestasService.getPreguntasEncuesta();
        return ResponseEntity.ok(preguntas);
    }

    @PostMapping(path = "")
    public ResponseEntity<PreguntasEncuestaEntity> savePreguntaEncuesta(@RequestBody PreguntaEncuestaDTO preguntaDTO) {
        Optional<EncuestasEntity> encuestaOptional = encuestasService.getById(preguntaDTO.getId_encuesta());
        if (!encuestaOptional.isPresent()) {
            return ResponseEntity.status(HttpStatus.CONFLICT).build();
        }
        PreguntasEncuestaEntity nuevaPregunta = new PreguntasEncuestaEntity();
        nuevaPregunta.setTextoPregunta(preguntaDTO.getTexto_pregunta());
        nuevaPregunta.setIdEncuesta(encuestaOptional.get());
        try {
            PreguntasEncuestaEntity preguntaGuardada = preguntasEncuestasService.savePreguntaEncuesta(nuevaPregunta);
            return ResponseEntity.ok(preguntaGuardada);
        } catch (Exception e) {
            e.printStackTrace();
            return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR).build();
        }
    }

    @GetMapping(path = "/{id}")
    public ResponseEntity<PreguntasEncuestaEntity> getPreguntaEncuestaById(@PathVariable Integer id) {
        Optional<PreguntasEncuestaEntity> preguntaOptional = preguntasEncuestasService.getById(id);
        if (preguntaOptional.isPresent()) {
            return ResponseEntity.ok(preguntaOptional.get());
        } else {
            return ResponseEntity.notFound().build();
        }
    }

    @PutMapping(path = "/{id}")
    public ResponseEntity<PreguntasEncuestaEntity> updatePreguntaEncuestaById(@RequestBody PreguntaEncuestaDTO preguntaDTO, @PathVariable Integer id) {
        Optional<EncuestasEntity> encuestaOptional = encuestasService.getById(preguntaDTO.getId_encuesta());
        if (!encuestaOptional.isPresent()) {
            return ResponseEntity.status(HttpStatus.CONFLICT).build();
        }
        PreguntasEncuestaEntity preguntaActualizada = new PreguntasEncuestaEntity();
        preguntaActualizada.setIdPregunta(preguntaDTO.getId_pregunta());
        preguntaActualizada.setTextoPregunta(preguntaDTO.getTexto_pregunta());
        preguntaActualizada.setIdEncuesta(encuestaOptional.get());
        preguntasEncuestasService.updateById(preguntaActualizada, id);
        return ResponseEntity.ok(preguntaActualizada);
    }

    @DeleteMapping(path = "/{id}")
    public ResponseEntity<?> deletePreguntaEncuestaById(@PathVariable Integer id) {
        boolean ok = preguntasEncuestasService.deletePreguntaEncuesta(id);
        if (ok) {
            return ResponseEntity.ok().build();
        } else {
            return ResponseEntity.status(HttpStatus.NOT_FOUND).build();
        }
    }
}
