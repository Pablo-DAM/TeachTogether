package com.proyecto.apiteachtoegther.dto;

public class AlumnoModulosDTO {
    private int idModulo;
    private int idAlumno;

    public AlumnoModulosDTO(int idModulo, int idAlumno) {
        this.idModulo = idModulo;
        this.idAlumno = idAlumno;
    }

    public int getIdModulo() {
        return idModulo;
    }

    public void setIdModulo(int idModulo) {
        this.idModulo = idModulo;
    }

    public int getIdAlumno() {
        return idAlumno;
    }

    public void setIdAlumno(int idAlumno) {
        this.idAlumno = idAlumno;
    }
}
