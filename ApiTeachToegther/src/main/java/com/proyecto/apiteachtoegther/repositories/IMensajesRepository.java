package com.proyecto.apiteachtoegther.repositories;

import com.proyecto.apiteachtoegther.models.MensajesEntity;
import org.springframework.data.jpa.repository.JpaRepository;

public interface IMensajesRepository extends JpaRepository<MensajesEntity,Integer> {
}
