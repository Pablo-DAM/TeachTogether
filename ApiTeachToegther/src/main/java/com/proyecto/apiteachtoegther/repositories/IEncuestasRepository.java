package com.proyecto.apiteachtoegther.repositories;

import com.proyecto.apiteachtoegther.models.EncuestasEntity;
import org.springframework.data.jpa.repository.JpaRepository;

public interface IEncuestasRepository extends JpaRepository<EncuestasEntity,Integer> {
}
