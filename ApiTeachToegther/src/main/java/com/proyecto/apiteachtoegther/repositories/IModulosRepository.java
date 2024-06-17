package com.proyecto.apiteachtoegther.repositories;

import com.proyecto.apiteachtoegther.dto.AlumnoModulosDTO;
import com.proyecto.apiteachtoegther.dto.AutoevaluacionModuloDTO;
import com.proyecto.apiteachtoegther.models.ModulosEntity;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import java.util.List;

public interface IModulosRepository extends JpaRepository<ModulosEntity,Integer> {
    @Query("SELECT um.idModulo as idModulo, um.idAlumno as idAlumno from ModulosEntity m " +
            "inner join UsuariosModulosEntity um on m.idModulo = um.idModulo " +
            "INNER JOIN UsuariosEntity u on u.idUsuario = um.idAlumno " +
            "INNER JOIN AutoevaluacionesUsuariosEntity au on au.idAlumno = u.idUsuario " +
            "where au.idAutoevaluacion = :idAu")
    List<AlumnoModulosProjection> getAlumnosYModulosByAuevaluacionID(@Param("idAu") int idAutoevaluacion);

    @Query("Select m FROM ModulosEntity m inner join UsuariosEntity u on u.idUsuario = m.idProfesor.idUsuario inner join AutoevaluacionesEntity a on " +
            "a.idProfesorCreador.idUsuario = u.idUsuario where a.idAutoevaluacion = :IdAu group by m.idModulo")
   List<ModulosEntity> getModuloByIdAutoevaluacion(@Param("IdAu") int idAutoevaluacion);

    @Query("SELECT new com.proyecto.apiteachtoegther.dto.AutoevaluacionModuloDTO(a.idAutoevaluacion, a.titulo, m.idModulo,m.nombre) " +
            "FROM AutoevaluacionesEntity a INNER JOIN UsuariosEntity u " +
            "ON u.idUsuario = a.idProfesorCreador.idUsuario INNER JOIN " +
            "ModulosEntity m ON m.idProfesor.idUsuario = u.idUsuario WHERE " +
            "m.idModulo = :idMod")
    List<AutoevaluacionModuloDTO> getAutoevaluacionesByIDModulo(@Param("idMod") int idModulo);
}
