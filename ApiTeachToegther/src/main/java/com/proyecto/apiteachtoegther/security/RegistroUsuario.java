package com.proyecto.apiteachtoegther.security;

import com.proyecto.apiteachtoegther.enums.Rol;

public class RegistroUsuario {
    private String usuario;
    private String password;
    private Rol rol;

    public String getUsuario() {
        return usuario;
    }

    public void setUsuario(String usuario) {
        this.usuario = usuario;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public Rol getRol() {
        return rol;
    }

    public void setRol(Rol rol) {
        this.rol = rol;
    }
}
