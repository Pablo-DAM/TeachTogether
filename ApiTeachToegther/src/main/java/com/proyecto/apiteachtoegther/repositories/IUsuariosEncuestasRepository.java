package com.proyecto.apiteachtoegther.repositories;

import com.proyecto.apiteachtoegther.models.UsuariosEncuestasEntity;
import com.proyecto.apiteachtoegther.models.UsuariosEncuestasEntityPK;
import org.springframework.data.jpa.repository.JpaRepository;

public interface IUsuariosEncuestasRepository extends JpaRepository<UsuariosEncuestasEntity, UsuariosEncuestasEntityPK> {
}
