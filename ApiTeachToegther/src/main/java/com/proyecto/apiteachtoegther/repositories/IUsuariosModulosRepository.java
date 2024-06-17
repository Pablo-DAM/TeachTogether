package com.proyecto.apiteachtoegther.repositories;

import com.proyecto.apiteachtoegther.models.UsuariosModulosEntity;
import com.proyecto.apiteachtoegther.models.UsuariosModulosEntityPK;
import org.springframework.data.jpa.repository.JpaRepository;

public interface IUsuariosModulosRepository extends JpaRepository<UsuariosModulosEntity, UsuariosModulosEntityPK> {
}
