package com.proyecto.apiteachtoegther.security;

public class LoginData {
    private String usuario;
    private String password;

    // Constructor por defecto necesario para la deserialización JSON
    public LoginData() {
    }

    // Getters y setters

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
}