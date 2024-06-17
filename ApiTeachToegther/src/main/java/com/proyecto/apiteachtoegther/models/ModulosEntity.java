package com.proyecto.apiteachtoegther.models;

import jakarta.persistence.*;

import java.sql.Time;

@Entity
@jakarta.persistence.Table(name = "modulos", schema = "teachtogether", catalog = "")
public class ModulosEntity {
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Id
    @jakarta.persistence.Column(name = "id_modulo", nullable = false)
    private int idModulo;

    public int getIdModulo() {
        return idModulo;
    }

    public void setIdModulo(int idModulo) {
        this.idModulo = idModulo;
    }

    @Basic
    @Column(name = "nombre", nullable = false, length = 70)
    private String nombre;

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    @Basic
    @Column(name = "horario", nullable = true,length = 70)
    private String horario;

    public String getHorario() {
        return horario;
    }

    public void setHorario(String horario) {
        this.horario = horario;
    }

    @Basic
    @Column(name = "horas", nullable = true)
    private Integer horas;

    public Integer getHoras() {
        return horas;
    }

    public void setHoras(Integer horas) {
        this.horas = horas;
    }

    @ManyToOne
    @JoinColumn(name = "id_profesor", nullable = false)
    private UsuariosEntity idProfesor;

    public UsuariosEntity getIdProfesor() {
        return idProfesor;
    }

    public void setIdProfesor(UsuariosEntity idProfesor) {
        this.idProfesor = idProfesor;
    }
    @Basic
    @Column(name="codigo",nullable = false,length = 45)
    private String codigo;

    public String getCodigo() {
        return codigo;
    }

    public void setCodigo(String codigo) {
        this.codigo = codigo;
    }
    @Basic
    @Column(name = "dias",nullable = true)
    private String dias;

    public String getDias() {
        return dias;
    }

    public void setDias(String dias) {
        this.dias = dias;
    }
}
