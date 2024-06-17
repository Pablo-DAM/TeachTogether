package com.proyecto.apiteachtoegther.controllers;

import com.fasterxml.jackson.annotation.JacksonAnnotationsInside;
import com.proyecto.apiteachtoegther.dto.RespuestaPreguntaAutoevaluacionDTO;
import com.proyecto.apiteachtoegther.models.PreguntasAutoevaluacionEntity;
import com.proyecto.apiteachtoegther.models.RespuestasPreguntaAutoevaluacionEntity;
import com.proyecto.apiteachtoegther.models.UsuariosEntity;
import com.proyecto.apiteachtoegther.services.PreguntasAutoevaluacionService;
import com.proyecto.apiteachtoegther.services.RespuestasPreguntaAutoevaluacionService;
import com.proyecto.apiteachtoegther.services.UsuariosService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Optional;

@RestController
@RequestMapping(path = "/respuestaAutoevaluacion")
public class RespuestasPreguntaAutoevaluacionController {
    @Autowired
    private RespuestasPreguntaAutoevaluacionService respuestasPreguntaAutoevaluacionService;
    @Autowired
    private PreguntasAutoevaluacionService preguntasAutoevaluacionService;
    @Autowired
    private UsuariosService usuariosService;
    @GetMapping(path = "")
    public ResponseEntity<List<RespuestasPreguntaAutoevaluacionEntity>> getRespuestas() {
        return ResponseEntity.ok(respuestasPreguntaAutoevaluacionService.getAllRespuestas());
    }

    @PostMapping(path = "")
    public ResponseEntity<RespuestasPreguntaAutoevaluacionEntity> saveRespuesta(@RequestBody RespuestaPreguntaAutoevaluacionDTO respuestaDTO) {
        int pregunta_id = respuestaDTO.getId_pregunta();
        Optional<PreguntasAutoevaluacionEntity> pregunta = preguntasAutoevaluacionService.getById(pregunta_id);
        if (!pregunta.isPresent()) {
            return ResponseEntity.status(HttpStatus.NOT_FOUND).build();
        }
        Optional<UsuariosEntity>usuOptional = usuariosService.getById(respuestaDTO.getId_alumno());
        if(!usuOptional.isPresent()){
            return ResponseEntity.status(HttpStatus.NOT_FOUND).build();
        }
        UsuariosEntity usuFinal = usuOptional.get();
        PreguntasAutoevaluacionEntity preguntaFinal = pregunta.get();
        RespuestasPreguntaAutoevaluacionEntity respuestaFinal = new RespuestasPreguntaAutoevaluacionEntity();
        respuestaFinal.setIdPregunta(preguntaFinal);
        respuestaFinal.setIdAlumno(usuFinal);
        respuestaFinal.setTextoRespuesta(respuestaDTO.getTexto_respuesta());
        try {
            return ResponseEntity.ok(this.respuestasPreguntaAutoevaluacionService.saveRespuesta(respuestaFinal));
        } catch (Exception e) {
            e.printStackTrace();
            return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR).build();
        }
    }

    @GetMapping(path = "/{id}")
    public ResponseEntity<RespuestasPreguntaAutoevaluacionEntity> getRespuestaByID(@PathVariable int id) {
        Optional<RespuestasPreguntaAutoevaluacionEntity> respuesta = this.respuestasPreguntaAutoevaluacionService.getByID(id);
        if (!respuesta.isPresent()) {
            return ResponseEntity.status(HttpStatus.NOT_FOUND).build();
        }
        RespuestasPreguntaAutoevaluacionEntity respuestaFinal = respuesta.get();
        return ResponseEntity.ok(respuestaFinal);
    }

    @DeleteMapping("/{id}")
    public ResponseEntity<RespuestasPreguntaAutoevaluacionEntity> deleteRespuesta(@PathVariable int id) {
        Optional<RespuestasPreguntaAutoevaluacionEntity> respuesta = this.respuestasPreguntaAutoevaluacionService.getByID(id);
        if (!respuesta.isPresent()) {
            return ResponseEntity.status(HttpStatus.NOT_FOUND).build();
        }
        RespuestasPreguntaAutoevaluacionEntity respuestaFinal = respuesta.get();
        this.respuestasPreguntaAutoevaluacionService.deleteRespuesta(id);
        return ResponseEntity.ok(respuestaFinal);
    }

    @PutMapping(path = "")
    public ResponseEntity<RespuestasPreguntaAutoevaluacionEntity> updateRespuesta(@RequestBody RespuestaPreguntaAutoevaluacionDTO respuestaDTO) {
        int id_Pregunta = respuestaDTO.getId_pregunta();
        Optional<PreguntasAutoevaluacionEntity> preguntaOptional = preguntasAutoevaluacionService.getById(id_Pregunta);
        if (!preguntaOptional.isPresent()) {
            return ResponseEntity.status(HttpStatus.NOT_FOUND).build();
        }
        Optional<RespuestasPreguntaAutoevaluacionEntity> respuestaOptional = respuestasPreguntaAutoevaluacionService.getByID(respuestaDTO.getId_respuesta());
        if (!respuestaOptional.isPresent()) {
            return ResponseEntity.status(HttpStatus.NOT_FOUND).build();
        }
        Optional<UsuariosEntity>usuOptional = usuariosService.getById(respuestaDTO.getId_alumno());
        if(!usuOptional.isPresent()){
            return ResponseEntity.status(HttpStatus.NOT_FOUND).build();
        }
        RespuestasPreguntaAutoevaluacionEntity respuestaFinal = respuestaOptional.get();
        UsuariosEntity usuFinal = usuOptional.get();
        respuestaFinal.setIdPregunta(preguntaOptional.get());
        respuestaFinal.setIdAlumno(usuFinal);
        respuestaFinal.setTextoRespuesta(respuestaDTO.getTexto_respuesta());
        this.respuestasPreguntaAutoevaluacionService.saveRespuesta(respuestaFinal);
        return ResponseEntity.ok(respuestaFinal);
    }
}
