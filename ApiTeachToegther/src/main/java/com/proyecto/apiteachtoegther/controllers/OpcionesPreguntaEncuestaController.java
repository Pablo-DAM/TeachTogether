package com.proyecto.apiteachtoegther.controllers;


import com.proyecto.apiteachtoegther.dto.OpcionPreguntaEncuestaDTO;
import com.proyecto.apiteachtoegther.models.OpcionesPreguntaEncuestaEntity;
import com.proyecto.apiteachtoegther.models.PreguntasEncuestaEntity;
import com.proyecto.apiteachtoegther.services.OpcionesPreguntaEncuestaService;
import com.proyecto.apiteachtoegther.services.PreguntasEncuestasService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;
import java.util.Optional;

@RestController
@RequestMapping(path = "/opcionPreguntaEncuesta")
public class OpcionesPreguntaEncuestaController {

    @Autowired
    private OpcionesPreguntaEncuestaService opcionesPreguntaEncuestaService;

    @Autowired
    private PreguntasEncuestasService preguntasEncuestasService;

    @GetMapping(path = "")
    public ResponseEntity<ArrayList<OpcionesPreguntaEncuestaEntity>> getAllOpcionesPreguntaEncuesta() {
        ArrayList<OpcionesPreguntaEncuestaEntity> opciones = opcionesPreguntaEncuestaService.getAllOpcionesPreguntaEncuesta();
        return ResponseEntity.ok(opciones);
    }

    @PostMapping(path = "")
    public ResponseEntity<OpcionesPreguntaEncuestaEntity> saveOpcionPreguntaEncuesta(@RequestBody OpcionPreguntaEncuestaDTO opcionDTO) {
        Optional<PreguntasEncuestaEntity> preguntaOptional = preguntasEncuestasService.getById(opcionDTO.getId_pregunta_encuesta());
        if (!preguntaOptional.isPresent()) {
            return ResponseEntity.status(HttpStatus.CONFLICT).build();
        }
        OpcionesPreguntaEncuestaEntity nuevaOpcion = new OpcionesPreguntaEncuestaEntity();
        nuevaOpcion.setTextoOpcion(opcionDTO.getTexto_opcion());
        nuevaOpcion.setIdPreguntaEncuesta(preguntaOptional.get());
        try {
            OpcionesPreguntaEncuestaEntity opcionGuardada = opcionesPreguntaEncuestaService.saveOpcion(nuevaOpcion);
            return ResponseEntity.ok(opcionGuardada);
        } catch (Exception e) {
            e.printStackTrace();
            return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR).build();
        }
    }

    @GetMapping(path = "/{id}")
    public ResponseEntity<OpcionesPreguntaEncuestaEntity> getOpcionPreguntaEncuestaById(@PathVariable Integer id) {
        Optional<OpcionesPreguntaEncuestaEntity> opcionOptional = opcionesPreguntaEncuestaService.getById(id);
        if (opcionOptional.isPresent()) {
            return ResponseEntity.ok(opcionOptional.get());
        } else {
            return ResponseEntity.notFound().build();
        }
    }

    @PutMapping(path = "")
    public ResponseEntity<OpcionesPreguntaEncuestaEntity> updateOpcionPreguntaEncuestaById(@RequestBody OpcionPreguntaEncuestaDTO opcionDTO) {
        Optional<PreguntasEncuestaEntity> preguntaOptional = preguntasEncuestasService.getById(opcionDTO.getId_pregunta_encuesta());
        if (!preguntaOptional.isPresent()) {
            return ResponseEntity.status(HttpStatus.CONFLICT).build();
        }
        OpcionesPreguntaEncuestaEntity opcionActualizada = new OpcionesPreguntaEncuestaEntity();
        opcionActualizada.setTextoOpcion(opcionDTO.getTexto_opcion());
        opcionActualizada.setIdPreguntaEncuesta(preguntaOptional.get());
        OpcionesPreguntaEncuestaEntity opcionGuardada = opcionesPreguntaEncuestaService.updateById(opcionActualizada, opcionDTO.getId_opcion());
        if (opcionGuardada != null) {
            return ResponseEntity.ok(opcionGuardada);
        } else {
            return ResponseEntity.status(HttpStatus.NOT_FOUND).build();
        }
    }

    @DeleteMapping(path = "/{id}")
    public ResponseEntity<?> deleteOpcionPreguntaEncuestaById(@PathVariable Integer id) {
        boolean ok = opcionesPreguntaEncuestaService.deleteOpcion(id);
        if (ok) {
            return ResponseEntity.ok().build();
        } else {
            return ResponseEntity.status(HttpStatus.NOT_FOUND).build();
        }
    }
}
