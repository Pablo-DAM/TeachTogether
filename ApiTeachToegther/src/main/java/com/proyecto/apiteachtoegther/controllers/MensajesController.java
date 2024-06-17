package com.proyecto.apiteachtoegther.controllers;

import com.proyecto.apiteachtoegther.dto.MensajeDTO;
import com.proyecto.apiteachtoegther.models.MensajesEntity;
import com.proyecto.apiteachtoegther.models.UsuariosEntity;
import com.proyecto.apiteachtoegther.services.MensajesService;
import com.proyecto.apiteachtoegther.services.UsuariosService;
import jakarta.persistence.EntityNotFoundException;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.server.ResponseStatusException;

import java.util.ArrayList;
import java.util.Optional;

@RestController
@RequestMapping("/mensaje")
public class MensajesController {
    @Autowired
    private MensajesService mensajesService;
    @Autowired
    private UsuariosService usuariosService;

    @GetMapping
    public ResponseEntity<ArrayList<MensajesEntity>> getMensajes() {
        ArrayList<MensajesEntity> mensajes = this.mensajesService.getMensajes();
        return ResponseEntity.ok(mensajes);
    }

    @PostMapping(path = "")
    public ResponseEntity<MensajesEntity> saveMensaje(@RequestBody MensajeDTO mensaje) {
        Optional<UsuariosEntity> existingCreadorOptional = this.usuariosService.getById(mensaje.getId_creador());
        Optional<UsuariosEntity> existingReceptorOptional = this.usuariosService.getById(mensaje.getId_receptor());
        if (!existingCreadorOptional.isPresent()) {
            
            return ResponseEntity.status(HttpStatus.CONFLICT).build();
        } else {
            if (!existingReceptorOptional.isPresent()) {

                return ResponseEntity.status(HttpStatus.CONFLICT).build();
            }
            UsuariosEntity creadorEntity = existingCreadorOptional.get();
            UsuariosEntity receptorEntity = existingReceptorOptional.get();
            MensajesEntity mensajeSalida = new MensajesEntity();
            mensajeSalida.setIdCreador(creadorEntity);
            mensajeSalida.setIdReceptor(receptorEntity);
            mensajeSalida.setFechaCreaccion(mensaje.getFecha_creaccion());
            mensajeSalida.setTexto(mensaje.getTexto());
            try {
                MensajesEntity savedMensaje = this.mensajesService.saveMensaje(mensajeSalida);
                return ResponseEntity.ok(savedMensaje);
            } catch (Exception e) {
                e.printStackTrace();
                return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR).build();
            }
        }
    }

    @GetMapping(path = "/{id}")
    public ResponseEntity<MensajesEntity> getMensajeById(@PathVariable Integer id) {
        Optional<MensajesEntity> mensajeOptional = this.mensajesService.getById(id);
        if (mensajeOptional.isPresent()) {
            return ResponseEntity.ok(mensajeOptional.get());
        } else {
            return ResponseEntity.notFound().build();
        }
    }

    @PutMapping("")
    public MensajesEntity updateEquipoById(@RequestBody MensajeDTO mensajeDTO) {
        try {
            int id = mensajeDTO.getId_mensaje(); // Obtener el ID del DTO

            MensajesEntity mensajeEntity = new MensajesEntity();
            Optional<UsuariosEntity> usuarioCreador = usuariosService.getById(mensajeDTO.getId_creador());
            Optional<UsuariosEntity> usuarioReceptor = usuariosService.getById(mensajeDTO.getId_receptor());

            // Verificar si el mensaje existe en la base de datos
            Optional<MensajesEntity> existingMensajeOptional = mensajesService.getById(id);
            if (!existingMensajeOptional.isPresent()) {
                throw new EntityNotFoundException("El mensaje con ID " + id + " no existe en la base de datos.");
            }
            if (!usuarioCreador.isPresent()){
                throw new EntityNotFoundException("El ID del creador no existe");
            }
            if(!usuarioReceptor.isPresent()){
                throw new EntityNotFoundException("El ID del receptor no existe");
            }
            UsuariosEntity usuarioCreadorFinal=usuarioCreador.get();
            UsuariosEntity usuarioReceptorFinal=usuarioReceptor.get();
            mensajeEntity.setIdMensaje(id);
            mensajeEntity.setTexto(mensajeDTO.getTexto());
            mensajeEntity.setFechaCreaccion(mensajeDTO.getFecha_creaccion());
            mensajeEntity.setIdCreador(usuarioCreadorFinal);
            mensajeEntity.setIdReceptor(usuarioReceptorFinal);


            return mensajesService.updateById(mensajeEntity, id);
        } catch (EntityNotFoundException e) {

            throw new ResponseStatusException(HttpStatus.NOT_FOUND, e.getMessage(), e);
        } catch (Exception e) {

            throw new ResponseStatusException(HttpStatus.INTERNAL_SERVER_ERROR, "Error al actualizar el mensaje: " + e.getMessage(), e);
        }
    }


    @DeleteMapping(path = "/{id}")

    public String deleteById(@PathVariable("id") Integer id) {
        boolean ok = this.mensajesService.deleteMensaje(id);
        if (ok) {
            return "Mensaje con id " + id + " borrado.";
        } else {
            return "Error, no se encuentra el mensaje con id " + id + ".";
        }
    }
}
