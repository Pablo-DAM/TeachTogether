package com.proyecto.apiteachtoegther.repositories;

import com.proyecto.apiteachtoegther.dto.AutoevaluacionDTO;
import com.proyecto.apiteachtoegther.dto.UsuariosPerfilModuloDTO;
import com.proyecto.apiteachtoegther.models.AutoevaluacionesEntity;
import com.proyecto.apiteachtoegther.models.ModulosEntity;
import com.proyecto.apiteachtoegther.models.UsuariosModulosEntity;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.web.bind.annotation.PathVariable;
import com.proyecto.apiteachtoegther.dto.IdDTO;
import java.util.List;

public interface IAutoevaluacionesRepository extends JpaRepository<AutoevaluacionesEntity,Integer> {
    @Query("SELECT a FROM AutoevaluacionesEntity a WHERE a.idProfesorCreador.idUsuario = :idProf")
    List<AutoevaluacionesEntity> listaAutoevaluaciones(@Param("idProf") int idProf);

    @Query("SELECT  new com.proyecto.apiteachtoegther." +
            "dto.UsuariosPerfilModuloDTO(u.usuario, p.nombre, p.apellidos, p.fechaNacimiento,a.idAutoevaluacion,u.idUsuario) FROM " +
            "PerfilesEntity  p INNER JOIN UsuariosEntity u on p.idUsuario.idUsuario = u.idUsuario "+
            "INNER JOIN AutoevaluacionesUsuariosEntity au on u.idUsuario=au.idAlumno INNER JOIN "+
            "AutoevaluacionesEntity  a on a.idAutoevaluacion = au.idAutoevaluacion where" +
            " a.idAutoevaluacion = :idAutoevaluacion")

    List<UsuariosPerfilModuloDTO> listaModulos(@Param("idAutoevaluacion") int idAutoevaluacion);

    @Query("Select new com.proyecto.apiteachtoegther.dto.IdDTO (u.idUsuario) from UsuariosModulosEntity um " +
            "inner join UsuariosEntity u on u.idUsuario = um.id_alumno.idUsuario " +
            "LEFT JOIN AutoevaluacionesUsuariosEntity au on au.idAlumno = u.idUsuario and au.idAutoevaluacion = :idAu " +
            "where au.idAlumno is null")
    List<IdDTO> listaIdUsuario(@Param("idAu")int idAu);
}