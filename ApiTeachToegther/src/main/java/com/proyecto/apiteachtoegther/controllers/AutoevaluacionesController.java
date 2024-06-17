package com.proyecto.apiteachtoegther.controllers;

import com.proyecto.apiteachtoegther.dto.AutoevaluacionDTO;
import com.proyecto.apiteachtoegther.dto.IdDTO;
import com.proyecto.apiteachtoegther.dto.MensajeDTO;
import com.proyecto.apiteachtoegther.dto.UsuariosPerfilModuloDTO;
import com.proyecto.apiteachtoegther.models.*;
import com.proyecto.apiteachtoegther.services.AutoevaluacionesService;
import com.proyecto.apiteachtoegther.services.ModulosService;
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
@RequestMapping(path = "/autoevaluacion")
public class AutoevaluacionesController {
    @Autowired
    private AutoevaluacionesService autoevaluacionesService;
    @Autowired
    private UsuariosService usuariosService;
    @Autowired
    private ModulosService modulosService;

    @GetMapping(path = "")
    public ResponseEntity<ArrayList<AutoevaluacionesEntity>> getAutoevaluacion() {
        ArrayList<AutoevaluacionesEntity> autoevaluaciones = this.autoevaluacionesService.getAutoevaluaciones();
        return ResponseEntity.ok(autoevaluaciones);
    }

    @PostMapping(path = "")
    public ResponseEntity<AutoevaluacionesEntity> saveAutoevaluacion(@RequestBody AutoevaluacionDTO autoevaluacionDTO) {
        Optional<UsuariosEntity> existingProfesorCreadorOptional = this.usuariosService.getById(autoevaluacionDTO.getId_profesor());
        if (!existingProfesorCreadorOptional.isPresent()) {
            // El ID del profesor creador no existe, ERROR
            return ResponseEntity.status(HttpStatus.CONFLICT).build();
        }
        UsuariosEntity creadorEntity = existingProfesorCreadorOptional.get();
        AutoevaluacionesEntity autoevaluacionesEntity = new AutoevaluacionesEntity();
        autoevaluacionesEntity.setTitulo(autoevaluacionDTO.getTitulo());
        autoevaluacionesEntity.setIdProfesorCreador(creadorEntity);
        Optional<ModulosEntity> existingModuloOptiona = this.modulosService.getById(autoevaluacionDTO.getId_modulo());
        if (!existingModuloOptiona.isPresent()) {
            return ResponseEntity.status(HttpStatus.CONFLICT).build();
        } else {
            ModulosEntity mod = existingModuloOptiona.get();
            autoevaluacionesEntity.setId_modulo(mod);
        }
        try {
            this.autoevaluacionesService.saveAutoevaluacion(autoevaluacionesEntity);
            return ResponseEntity.ok(autoevaluacionesEntity);
        } catch (Exception e) {
            e.printStackTrace();
            return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR).build();
        }
    }

    @GetMapping(path = "/{id}")
    public ResponseEntity<AutoevaluacionesEntity> getAutoevaluacionById(@PathVariable Integer id) {
        Optional<AutoevaluacionesEntity> autoevaluacionOptional = this.autoevaluacionesService.getById(id);
        if (autoevaluacionOptional.isPresent()) {
            return ResponseEntity.ok(autoevaluacionOptional.get());
        } else {
            return ResponseEntity.notFound().build();
        }
    }

    @PutMapping("")
    public AutoevaluacionesEntity updateAutoevaluacionById(@RequestBody AutoevaluacionDTO autoevaluacionDTO) {
        try {
            int id = autoevaluacionDTO.getId_autoevaluacion(); // Obtener el ID del DTO

            AutoevaluacionesEntity autoevaluacionesEntity = new AutoevaluacionesEntity();
            Optional<UsuariosEntity> usuarioCreador = usuariosService.getById(autoevaluacionDTO.getId_profesor());

            Optional<AutoevaluacionesEntity> existingAutoevaluacionesOptional = autoevaluacionesService.getById(id);
            if (!existingAutoevaluacionesOptional.isPresent()) {
                throw new EntityNotFoundException("La evaluacion con ID " + id + " no existe en la base de datos.");
            }
            if (!usuarioCreador.isPresent()) {
                throw new EntityNotFoundException("El ID del creador no existe");
            }

            UsuariosEntity usuarioCreadorFinal = usuarioCreador.get();

            autoevaluacionesEntity.setIdAutoevaluacion(autoevaluacionDTO.getId_autoevaluacion());
            autoevaluacionesEntity.setTitulo(autoevaluacionDTO.getTitulo());
            autoevaluacionesEntity.setIdProfesorCreador(usuarioCreadorFinal);
            return autoevaluacionesService.updateById(autoevaluacionesEntity, id);
        } catch (EntityNotFoundException e) {

            throw new ResponseStatusException(HttpStatus.NOT_FOUND, e.getMessage(), e);
        } catch (Exception e) {

            throw new ResponseStatusException(HttpStatus.INTERNAL_SERVER_ERROR, "Error al actualizar el mensaje: " + e.getMessage(), e);
        }
    }


    @DeleteMapping(path = "/{id}")
    public String deleteById(@PathVariable("id") Integer id) {
        boolean ok = this.autoevaluacionesService.deleteAutoevaluacion(id);
        if (ok) {
            return "Autoevaluacion con id " + id + " borrado.";
        } else {
            return "Error, no se encuentra la Autoevaluacion con id " + id + ".";
        }
    }

    @GetMapping(path = "/byProfId/{idProf}")
    public ResponseEntity<List<AutoevaluacionesEntity>> getAutoevaluacionesByProfId(@PathVariable int idProf) {
        List<AutoevaluacionesEntity> lista = this.autoevaluacionesService.getAutoevaluacionesByProfesorID(idProf);
        return ResponseEntity.ok(lista);
    }

    @GetMapping(path = "/moduloByAutoevaluacionId/{idAutoevaluacion}")
    public ResponseEntity<List<UsuariosPerfilModuloDTO>> getModulosByAutoevaluacionID(@PathVariable int idAutoevaluacion) {
        List<UsuariosPerfilModuloDTO> listaUsuariosPerfil = this.autoevaluacionesService.getModulosByAutoevaluacionID(idAutoevaluacion);
        return ResponseEntity.ok(listaUsuariosPerfil);
    }

    @GetMapping(path = "/idUsuario/{idAu}")
    public ResponseEntity<List<IdDTO>> getIDUsuariosWhereAutoevaluacionUsuarioIsNull(@PathVariable int idAu) {
        List<IdDTO> listaIds = this.autoevaluacionesService.getUsuarioIdWhereUsuarioAutoevaluacionIsNull(idAu);
        return ResponseEntity.ok(listaIds);
    }
}
