package com.proyecto.apiteachtoegther.security;

import com.proyecto.apiteachtoegther.models.UsuariosEntity;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.GrantedAuthority;
import org.springframework.security.core.authority.SimpleGrantedAuthority;
import org.springframework.security.core.userdetails.User;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.stereotype.Service;

import java.util.Collections;
import java.util.List;

@Service
public class CustomUserDetailsService implements UserDetailsService {

    @Autowired
    private IUsuariosApiRepository usuarioApiRepository;
    @Override
    public UserDetails loadUserByUsername(String username) throws UsernameNotFoundException {
        UsuariosEntity usuarioApi = usuarioApiRepository.findByUsuario(username);
        if (usuarioApi == null) {
            throw new UsernameNotFoundException("User not found with username: " + username);
        }

        String roleName = usuarioApi.getRol().name();

        List<GrantedAuthority> authorities = Collections.singletonList(
                new SimpleGrantedAuthority(roleName)
        );

        return new User(usuarioApi.getUsuario(), usuarioApi.getPassword(), authorities);
    }
}