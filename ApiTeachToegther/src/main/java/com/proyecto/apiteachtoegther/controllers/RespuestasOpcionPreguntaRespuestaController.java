package com.proyecto.apiteachtoegther.controllers;


import com.proyecto.apiteachtoegther.dto.RespuestaOpcionPreguntaEncuestaDTO;
import com.proyecto.apiteachtoegther.models.OpcionesPreguntaEncuestaEntity;
import com.proyecto.apiteachtoegther.models.RespuestasOpcionPreguntaEncuestaEntity;
import com.proyecto.apiteachtoegther.services.OpcionesPreguntaEncuestaService;
import com.proyecto.apiteachtoegther.services.RespuestasOpcionPreguntaEncuestaService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;
import java.util.Optional;

@RestController
@RequestMapping(path = "/respuestaOpcionPreguntaEncuesta")
public class RespuestasOpcionPreguntaRespuestaController {

    @Autowired
    private RespuestasOpcionPreguntaEncuestaService respuestasOpcionPreguntaEncuestaService;

    @Autowired
    private OpcionesPreguntaEncuestaService opcionesPreguntaEncuestaService;

    @GetMapping(path = "")
    public ResponseEntity<ArrayList<RespuestasOpcionPreguntaEncuestaEntity>> getAllRespuestasOpcionPreguntaEncuesta() {
        ArrayList<RespuestasOpcionPreguntaEncuestaEntity> respuestas = respuestasOpcionPreguntaEncuestaService.getAllRespuestas();
        return ResponseEntity.ok(respuestas);
    }

    @PostMapping(path = "")
    public ResponseEntity<RespuestasOpcionPreguntaEncuestaEntity> saveRespuestaOpcionPreguntaEncuesta(@RequestBody RespuestaOpcionPreguntaEncuestaDTO respuestaDTO) {
        Optional<OpcionesPreguntaEncuestaEntity> opcionOptional = opcionesPreguntaEncuestaService.getById(respuestaDTO.getId_opcion());
        if (!opcionOptional.isPresent()) {
            return ResponseEntity.status(HttpStatus.CONFLICT).build();
        }
        RespuestasOpcionPreguntaEncuestaEntity nuevaRespuesta = new RespuestasOpcionPreguntaEncuestaEntity();
        nuevaRespuesta.setTextoOpcionalRespuesta(respuestaDTO.getTexto_opcional_respuesta());
        nuevaRespuesta.setIdOpcion(opcionOptional.get());
        try {
            RespuestasOpcionPreguntaEncuestaEntity respuestaGuardada = respuestasOpcionPreguntaEncuestaService.saveRespuesta(nuevaRespuesta);
            return ResponseEntity.ok(respuestaGuardada);
        } catch (Exception e) {
            e.printStackTrace();
            return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR).build();
        }
    }

    @GetMapping(path = "/{id}")
    public ResponseEntity<RespuestasOpcionPreguntaEncuestaEntity> getRespuestaOpcionPreguntaEncuestaById(@PathVariable Integer id) {
        Optional<RespuestasOpcionPreguntaEncuestaEntity> respuestaOptional = respuestasOpcionPreguntaEncuestaService.getById(id);
        if (respuestaOptional.isPresent()) {
            return ResponseEntity.ok(respuestaOptional.get());
        } else {
            return ResponseEntity.notFound().build();
        }
    }

    @PutMapping(path = "")
    public ResponseEntity<RespuestasOpcionPreguntaEncuestaEntity> updateRespuestaOpcionPreguntaEncuestaById(
            @RequestBody RespuestaOpcionPreguntaEncuestaDTO respuestaDTO) {
        Optional<OpcionesPreguntaEncuestaEntity> opcionOptional = opcionesPreguntaEncuestaService.getById(respuestaDTO.getId_opcion());
        if (!opcionOptional.isPresent()) {
            return ResponseEntity.status(HttpStatus.CONFLICT).build();
        }
        RespuestasOpcionPreguntaEncuestaEntity respuestaActualizada = new RespuestasOpcionPreguntaEncuestaEntity();
        respuestaActualizada.setTextoOpcionalRespuesta(respuestaDTO.getTexto_opcional_respuesta());
        respuestaActualizada.setIdOpcion(opcionOptional.get());
        RespuestasOpcionPreguntaEncuestaEntity respuestaGuardada = respuestasOpcionPreguntaEncuestaService.updateById(respuestaActualizada, respuestaDTO.getId_respuesta());
        if (respuestaGuardada != null) {
            return ResponseEntity.ok(respuestaGuardada);
        } else {
            return ResponseEntity.status(HttpStatus.NOT_FOUND).build();
        }
    }

    @DeleteMapping(path = "/{id}")
    public ResponseEntity<?> deleteRespuestaOpcionPreguntaEncuestaById(@PathVariable Integer id) {
        boolean ok = respuestasOpcionPreguntaEncuestaService.deleteRespuesta(id);
        if (ok) {
            return ResponseEntity.ok().build();
        } else {
            return ResponseEntity.status(HttpStatus.NOT_FOUND).build();
        }
    }
}