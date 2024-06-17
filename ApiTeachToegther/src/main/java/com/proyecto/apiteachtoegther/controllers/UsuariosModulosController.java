package com.proyecto.apiteachtoegther.controllers;

import com.proyecto.apiteachtoegther.dto.UsuarioModuloDTO;
import com.proyecto.apiteachtoegther.models.ModulosEntity;
import com.proyecto.apiteachtoegther.models.UsuariosEntity;
import com.proyecto.apiteachtoegther.models.UsuariosModulosEntity;
import com.proyecto.apiteachtoegther.models.UsuariosModulosEntityPK;
import com.proyecto.apiteachtoegther.services.ModulosService;
import com.proyecto.apiteachtoegther.services.UsuariosModulosService;
import com.proyecto.apiteachtoegther.services.UsuariosService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

@RestController
@RequestMapping(path = "/usuarioModulo")
public class UsuariosModulosController {
    @Autowired
    private UsuariosService usuariosService;
    @Autowired
    private ModulosService modulosService;
    @Autowired
    private UsuariosModulosService usuariosModulosService;

    @GetMapping(path = "")
    public ResponseEntity<List<UsuariosModulosEntity>> getAll() {
        return ResponseEntity.ok(this.usuariosModulosService.getAllUsuariosModulos());
    }

    @PostMapping(path = "")
    public ResponseEntity<UsuariosModulosEntity> saveUsuarioModulo(@RequestBody UsuarioModuloDTO usuarioModulodto) {
        Optional<UsuariosEntity> usuarioOptional = usuariosService.getById(usuarioModulodto.getId_alumno());
        if (!usuarioOptional.isPresent()) {
            return ResponseEntity.status(HttpStatus.NOT_FOUND).build();
        }
        Optional<ModulosEntity> moduloOptional = modulosService.getById(usuarioModulodto.getId_modulo());
        if (!moduloOptional.isPresent()) {
            return ResponseEntity.status(HttpStatus.NOT_FOUND).build();
        }
        UsuariosModulosEntityPK usuModPK = new UsuariosModulosEntityPK();
        usuModPK.setIdModulo(usuarioModulodto.getId_modulo());
        usuModPK.setIdAlumno(usuarioModulodto.getId_alumno());
        Optional<UsuariosModulosEntity> usuModOptional = usuariosModulosService.getById(usuModPK);
        if (usuModOptional.isPresent()) {
            return ResponseEntity.status(HttpStatus.CONFLICT).build();
        }
        UsuariosModulosEntity finalGuardar = new UsuariosModulosEntity();
        finalGuardar.setIdModulo(usuarioModulodto.getId_modulo());
        finalGuardar.setIdAlumno((usuarioModulodto.getId_alumno()));
        this.usuariosModulosService.saveUsuarioModulo(finalGuardar);
        return ResponseEntity.ok(finalGuardar);

    }

    @GetMapping(path = "/{idUsuario}/{idModulo}")
    public ResponseEntity<UsuariosModulosEntity> getById(@PathVariable int idUsuario, @PathVariable int idModulo) {
        UsuariosModulosEntityPK usuModPK = new UsuariosModulosEntityPK();
        usuModPK.setIdAlumno(idUsuario);
        usuModPK.setIdModulo(idModulo);
        Optional<UsuariosModulosEntity> usuModOptional = usuariosModulosService.getById(usuModPK);
        if (!usuModOptional.isPresent()) {
            return ResponseEntity.status(HttpStatus.NOT_FOUND).build();
        }
        UsuariosModulosEntity finalUsuMod = usuModOptional.get();
        this.usuariosModulosService.getById(usuModPK);
        return ResponseEntity.ok(finalUsuMod);
    }
/* NO HACE FALTA
    @PutMapping(path = "")
    public ResponseEntity<UsuariosModulosEntity> updateById(@RequestBody UsuarioModuloDTO usuarioModuloDTO) {
        int id_usu = usuarioModuloDTO.getId_alumno();
        int id_mod = usuarioModuloDTO.getId_modulo();
        UsuariosModulosEntityPK idPK = new UsuariosModulosEntityPK();
        idPK.setIdModulo(id_mod);
        idPK.setIdAlumno(id_usu);
        Optional<UsuariosModulosEntity> optionalUsuariosModulosEntityPK = this.usuariosModulosService.getById(idPK);
        if (!optionalUsuariosModulosEntityPK.isPresent()) {
            return ResponseEntity.status(HttpStatus.NOT_FOUND).build();
        }
        UsuariosModulosEntity usuModFinal = optionalUsuariosModulosEntityPK.get();
        usuModFinal.setIdModulo(usuarioModuloDTO.getId_modulo());
        usuModFinal.setIdAlumno(usuarioModuloDTO.getId_alumno());
        this.usuariosModulosService.saveUsuarioModulo(usuModFinal);
        return ResponseEntity.ok(usuModFinal);

    }*/

    @DeleteMapping(path = "/{idAlumno}/{idModulo}")
    public ResponseEntity delete(@PathVariable int idAlumno, @PathVariable int idModulo) {
        UsuariosModulosEntityPK idPK = new UsuariosModulosEntityPK();
        idPK.setIdModulo(idModulo);
        idPK.setIdAlumno(idAlumno);
        boolean ok = this.usuariosModulosService.deleteUsuarioModulo(idPK);
        if (ok) {
            return ResponseEntity.status(HttpStatus.ACCEPTED).build();
        } else {
            return ResponseEntity.status(HttpStatus.NOT_FOUND).build();
        }
    }

}
