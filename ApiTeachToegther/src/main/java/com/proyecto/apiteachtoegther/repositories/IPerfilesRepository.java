package com.proyecto.apiteachtoegther.repositories;

import com.proyecto.apiteachtoegther.models.PerfilesEntity;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.Optional;

public interface IPerfilesRepository extends JpaRepository<PerfilesEntity,Integer> {
    Optional<PerfilesEntity> findByIdUsuario_IdUsuario(Integer idUsuario);

}
