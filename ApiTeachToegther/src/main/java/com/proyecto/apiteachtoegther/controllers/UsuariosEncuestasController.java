package com.proyecto.apiteachtoegther.controllers;

import com.proyecto.apiteachtoegther.dto.UsuarioEncuestaDTO;
import com.proyecto.apiteachtoegther.models.*;
import com.proyecto.apiteachtoegther.repositories.IUsuariosEncuestasRepository;
import com.proyecto.apiteachtoegther.services.EncuestasService;
import com.proyecto.apiteachtoegther.services.UsuariosEncuestasService;
import com.proyecto.apiteachtoegther.services.UsuariosService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Optional;

@RestController
@RequestMapping(path = "/usuarioEncuesta")
public class UsuariosEncuestasController {
    @Autowired
    private UsuariosEncuestasService usuariosEncuestasService;
    @Autowired
    private EncuestasService encuestasService;
    @Autowired
    private UsuariosService usuariosService;

    @GetMapping(path = "")
    public ResponseEntity<List<UsuariosEncuestasEntity>> getAll() {
        this.usuariosEncuestasService.getAll();
        return ResponseEntity.ok(this.usuariosEncuestasService.getAll());
    }

    @PostMapping(path = "")
    public ResponseEntity<UsuariosEncuestasEntity> saveUsuarioEncuesta(
            @RequestBody UsuarioEncuestaDTO dto) {
        Optional<UsuariosEntity> usuario = this.usuariosService.getById(dto.getId_usuario());
        if (!usuario.isPresent()) {
            return ResponseEntity.status(HttpStatus.NOT_FOUND).build();
        }
        Optional<EncuestasEntity> encuesta = this.encuestasService.getById(dto.getId_encuesta());
        if (!encuesta.isPresent()) {
            return ResponseEntity.status(HttpStatus.NOT_FOUND).build();
        }
        UsuariosEncuestasEntityPK idPK = new UsuariosEncuestasEntityPK();
        idPK.setId_encuesta(dto.getId_encuesta());
        idPK.setId_usuario(dto.getId_usuario());

        Optional<UsuariosEncuestasEntity> usuEncOptional = this.usuariosEncuestasService.getById(idPK);
        if (usuEncOptional.isPresent()) {
            return ResponseEntity.status(HttpStatus.CONFLICT).build();
        }
        UsuariosEncuestasEntity usuEncFinal = new UsuariosEncuestasEntity();
        usuEncFinal.setFecha_realizacion(dto.getFecha_realizacion());
        usuEncFinal.setId_usuario(dto.getId_usuario());
        usuEncFinal.setId_encuesta(dto.getId_encuesta());
        this.usuariosEncuestasService.saveUsuarioEncuesta(usuEncFinal);
        return ResponseEntity.ok(usuEncFinal);
    }

    @GetMapping(path = "/{idUsuario}/{idEncuesta}")
    public ResponseEntity<UsuariosEncuestasEntity> getById(
            @PathVariable int idUsuario, @PathVariable int idEncuesta) {
      /*  Optional<UsuariosEntity> usuOptional = this.usuariosService.getById(idUsuario);
        if (!usuOptional.isPresent()) {
            return ResponseEntity.status(HttpStatus.NOT_FOUND).build();
        }
        Optional<EncuestasEntity> encuestaOptional = this.encuestasService.getById(idEncuesta);
        if (!encuestaOptional.isPresent()) {
            return ResponseEntity.status(HttpStatus.NOT_FOUND).build();
        }*/
        UsuariosEncuestasEntityPK idPK = new UsuariosEncuestasEntityPK();
        idPK.setId_encuesta(idEncuesta);
        idPK.setId_usuario(idUsuario);
        Optional<UsuariosEncuestasEntity> usuEncOptional = this.usuariosEncuestasService.getById(idPK);
        if (!usuEncOptional.isPresent()) {
            return ResponseEntity.status(HttpStatus.NOT_FOUND).build();
        }
        UsuariosEncuestasEntity usuEncFinal = usuEncOptional.get();
        this.usuariosEncuestasService.getById(idPK);
        return ResponseEntity.ok(usuEncFinal);
    }

    @PutMapping(path = "")
    public ResponseEntity<UsuariosEncuestasEntity> updateById(@RequestBody UsuarioEncuestaDTO dto) {
        UsuariosEncuestasEntityPK idPK = new UsuariosEncuestasEntityPK();
        idPK.setId_encuesta(dto.getId_encuesta());
        idPK.setId_usuario(dto.getId_usuario());
        Optional<UsuariosEncuestasEntity> usuEncOptional = this.usuariosEncuestasService.getById(idPK);
        if (!usuEncOptional.isPresent()) {
            return ResponseEntity.status(HttpStatus.NOT_FOUND).build();
        }
        UsuariosEncuestasEntity usuEncFinal = usuEncOptional.get();
        usuEncFinal.setFecha_realizacion(dto.getFecha_realizacion());
        this.usuariosEncuestasService.saveUsuarioEncuesta(usuEncFinal);
        return ResponseEntity.ok(usuEncFinal);
    }

    @DeleteMapping(path = "/{idUsuario}/{idEncuesta}")
    public ResponseEntity deleteById(@PathVariable int idUsuario,
                                     @PathVariable int idEncuesta) {
        UsuariosEncuestasEntityPK idPK = new UsuariosEncuestasEntityPK();
        idPK.setId_usuario(idUsuario);
        idPK.setId_encuesta(idEncuesta);
        boolean ok = this.usuariosEncuestasService.deleteUsuarioEncuesta(idPK);
        if (ok) {
            return ResponseEntity.status(HttpStatus.ACCEPTED).build();
        } else {
            return ResponseEntity.status(HttpStatus.NOT_FOUND).build();
        }
    }
}
