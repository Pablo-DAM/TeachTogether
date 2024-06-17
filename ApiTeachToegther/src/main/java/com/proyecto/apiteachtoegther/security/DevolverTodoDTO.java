package com.proyecto.apiteachtoegther.security;

public class DevolverTodoDTO {
    private Integer id;
    private AuthTokenResponse token;

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public AuthTokenResponse getToken() {
        return token;
    }

    public void setToken(AuthTokenResponse token) {
        this.token = token;
    }
}
