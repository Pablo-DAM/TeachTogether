package com.proyecto.apiteachtoegther.dto;

import java.util.Date;

public class UsuariosPerfilModuloDTO {
    private String usuario;
    private String nombre;
    private String apellidos;
    private Date fechaNacimiento;
    private int idAutoevaluacion;
    private int idUsuario;

    public UsuariosPerfilModuloDTO(String usuario, String nombre, String apellidos, Date fechaNacimiento, int idAutoevaluacion, int idUsuario) {
        this.usuario = usuario;
        this.nombre = nombre;
        this.apellidos = apellidos;
        this.fechaNacimiento = fechaNacimiento;
        this.idAutoevaluacion = idAutoevaluacion;
        this.idUsuario = idUsuario;
    }

    public String getUsuario() {
        return usuario;
    }

    public void setUsuario(String usuario) {
        this.usuario = usuario;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public String getApellidos() {
        return apellidos;
    }

    public void setApellidos(String apellidos) {
        this.apellidos = apellidos;
    }

    public Date getFechaNacimiento() {
        return fechaNacimiento;
    }

    public void setFechaNacimiento(Date fechaNacimiento) {
        this.fechaNacimiento = fechaNacimiento;
    }

    public int getIdAutoevaluacion() {
        return idAutoevaluacion;
    }

    public void setIdAutoevaluacion(int idAutoevaluacion) {
        this.idAutoevaluacion = idAutoevaluacion;
    }

    public int getIdUsuario() {
        return idUsuario;
    }

    public void setIdUsuario(int idUsuario) {
        this.idUsuario = idUsuario;
    }
}
