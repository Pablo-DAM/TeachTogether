package com.proyecto.apiteachtoegther.controllers;

import com.proyecto.apiteachtoegther.dto.UsuarioModuloDTO;
import com.proyecto.apiteachtoegther.dto.UsuarioPerfilDTO;
import com.proyecto.apiteachtoegther.models.PerfilesEntity;
import com.proyecto.apiteachtoegther.services.UsuariosService;
import com.proyecto.apiteachtoegther.models.MensajesEntity;
import com.proyecto.apiteachtoegther.models.UsuariosEntity;
import com.proyecto.apiteachtoegther.repositories.IUsuariosRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

@RestController
@RequestMapping("/usuario")
public class UsuariosController {
    @Autowired
    private UsuariosService usuariosService;
    @Autowired
    private PasswordEncoder passwordEncoder;

    @GetMapping(path = "")
    public ResponseEntity<ArrayList<UsuariosEntity>> getUsuarios() {
        ArrayList<UsuariosEntity> usuarios = this.usuariosService.getUsuarios();
        return ResponseEntity.ok(usuarios);
    }

    @PostMapping(path = "")
    public ResponseEntity<UsuariosEntity> saveUsuario(@RequestBody UsuariosEntity usuario) {
        try {
            UsuariosEntity savedUsuario = this.usuariosService.saveUsuario(usuario);
            return ResponseEntity.ok(savedUsuario);
        } catch (Exception e) {
            return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR).build();
        }
    }

    @GetMapping(path = "/{id}")
    public ResponseEntity<UsuariosEntity> getUsuarioById(@PathVariable Integer id) {
        Optional<UsuariosEntity> usuarioOptional = this.usuariosService.getById(id);
        if (usuarioOptional.isPresent()) {
            return ResponseEntity.ok(usuarioOptional.get());
        } else {
            return ResponseEntity.notFound().build();
        }
    }

    @PutMapping(path="")
    public ResponseEntity<UsuariosEntity> updateUsuarioById(@RequestBody UsuariosEntity request) {
        Integer id = request.getIdUsuario();
        if (id == null) {
            return ResponseEntity.badRequest().build();
        }
        Optional<UsuariosEntity> existingUsuarioOptional = this.usuariosService.getById(id);
        if (!existingUsuarioOptional.isPresent()) {
            return ResponseEntity.notFound().build();
        }
        try {
            request.setPassword(passwordEncoder.encode(request.getPassword()));
            UsuariosEntity updatedUsuario = this.usuariosService.updateById(request, id);
            return ResponseEntity.ok(updatedUsuario);
        } catch (Exception e) {

            return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR).build();
        }
    }

    @DeleteMapping(path = "/{id}")
    public String deleteById(@PathVariable("id") Integer id) {
        boolean ok = this.usuariosService.deleteUsuario(id);
        if (ok) {
            return "Usuario con id " + id + " borrado.";
        } else {
            return "Error, no se encuentra el usuario con id " + id + ".";
        }
    }
    @GetMapping(path = "/usuarioPerfil/{usuario}")
    public ResponseEntity <List<PerfilesEntity>> perfilesUsuario(@PathVariable String usuario){
        List<PerfilesEntity>perfiles=this.usuariosService.obtenerPerfilesPorUsuario(usuario);
        return ResponseEntity.ok(perfiles);
    }
    @GetMapping(path = "/usuario/{usuario}")
    public ResponseEntity<Integer>getIdByUsuario(@PathVariable String usuario){
        int usuarioId=this.usuariosService.obtenerId_UsuarioPorUSuario(usuario);
        return  ResponseEntity.ok((usuarioId));
    }
    @GetMapping(path = "/usuPerfil/{idMod}")
    public ResponseEntity<List<UsuarioPerfilDTO>>getUsuPerfilesByIDModulo(@PathVariable int idMod){
        List<UsuarioPerfilDTO>listaUsuPerf=this.usuariosService.getUsuarioYPerfilByIDModulo(idMod);
        return ResponseEntity.ok(listaUsuPerf);
    }
}
