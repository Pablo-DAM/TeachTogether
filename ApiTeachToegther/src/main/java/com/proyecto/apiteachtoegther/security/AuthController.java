package com.proyecto.apiteachtoegther.security;

import com.proyecto.apiteachtoegther.models.UsuariosEntity;
import com.proyecto.apiteachtoegther.repositories.IUsuariosRepository;
import com.proyecto.apiteachtoegther.services.UsuariosService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.security.authentication.AuthenticationManager;
import org.springframework.security.authentication.UsernamePasswordAuthenticationToken;
import org.springframework.security.core.Authentication;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class AuthController {
    @Autowired
    private AuthenticationManager authenticationManager;
    @Autowired
    private JwtTokenUtil jwtTokenUtil;
    @Autowired
    private PasswordEncoder passwordEncoder;
    @Autowired
    private IUsuariosApiRepository usuariosApiRepository;
    @Autowired
    private UsuariosService usuariosService;
    @CrossOrigin(origins = "http://10.0.2.2:4001")
    @PostMapping("/login")
    public ResponseEntity<DevolverTodoDTO> login(@RequestBody LoginData loginData) {
        Authentication authentication = authenticationManager.authenticate(
                new UsernamePasswordAuthenticationToken(loginData.getUsuario(), loginData.getPassword()));
        SecurityContextHolder.getContext().setAuthentication(authentication);
        String token = jwtTokenUtil.generateToken(authentication);

        UsuariosEntity usuarioApi = usuariosApiRepository.findByUsuario(loginData.getUsuario());
        if (usuarioApi == null) {
            return ResponseEntity.status(HttpStatus.UNAUTHORIZED).build();
        }
        DevolverTodoDTO devolver = new DevolverTodoDTO();
        UsuariosEntity usuario = usuariosApiRepository.findByUsuario(loginData.getUsuario());
        devolver.setId(usuario.getIdUsuario());
        devolver.setToken(new AuthTokenResponse(token));
        return ResponseEntity.ok().body(devolver);
    }
    @PostMapping("/registro")
    public ResponseEntity<?> registerUser(@RequestBody UsuariosEntity usuario) {
        // Verificar si el usuario ya existe
        if (this.usuariosApiRepository.findByUsuario(usuario.getUsuario()) != null) {
            return ResponseEntity.badRequest().body("Error: El nombre de usuario ya está en uso!");
        }
        UsuariosEntity usuarioGuardar=new UsuariosEntity();
        usuarioGuardar.setPassword(passwordEncoder.encode(usuario.getPassword()));
        usuarioGuardar.setUsuario(usuario.getUsuario());
        usuarioGuardar.setRol(usuario.getRol());


       this.usuariosService.saveUsuario(usuarioGuardar);

        return ResponseEntity.ok(usuarioGuardar);
    }
}
