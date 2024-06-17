package com.proyecto.apiteachtoegther.repositories;

import com.proyecto.apiteachtoegther.dto.UsuarioPerfilDTO;
import com.proyecto.apiteachtoegther.models.PerfilesEntity;
import com.proyecto.apiteachtoegther.models.UsuariosEntity;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import java.util.List;
import java.util.Optional;

public interface IUsuariosRepository extends JpaRepository<UsuariosEntity,Integer> {
    @Query("SELECT p FROM PerfilesEntity p JOIN p.idUsuario u WHERE u.usuario = :usuario")
    List<PerfilesEntity> findPerfilesByUsuario(String usuario);
    @Query ("SELECT usu.idUsuario FROM UsuariosEntity usu WHERE usu.usuario =:usuario")
    int findIdByUsuario(String usuario);
    @Query("SELECT new com.proyecto.apiteachtoegther.dto.UsuarioPerfilDTO(u.idUsuario, u.usuario, p.nombre, p.apellidos, p.fechaNacimiento) " +
            "FROM UsuariosEntity u " +
            "JOIN PerfilesEntity p ON p.idUsuario.idUsuario = u.idUsuario " +
            "JOIN UsuariosModulosEntity um ON um.idAlumno = u.idUsuario " +
            "JOIN ModulosEntity m ON m.idModulo = um.idModulo " +
            "WHERE m.idModulo = :idMod")
    List<UsuarioPerfilDTO> getUsuariosYPerfilByIDModulo(@Param("idMod") int idMod);

}
