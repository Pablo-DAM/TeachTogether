package com.proyecto.apiteachtoegther.repositories;

import com.proyecto.apiteachtoegther.models.AutoevaluacionesUsuariosEntity;
import com.proyecto.apiteachtoegther.models.AutoevaluacionesUsuariosEntityPK;
import org.springframework.data.jpa.repository.JpaRepository;

public interface IAutoevaluacionesUsuariosRepository extends JpaRepository<AutoevaluacionesUsuariosEntity, AutoevaluacionesUsuariosEntityPK> {
}
