package com.proyecto.apiteachtoegther.repositories;

import com.proyecto.apiteachtoegther.models.RespuestasPreguntaAutoevaluacionEntity;
import org.springframework.data.jpa.repository.JpaRepository;

public interface IRespuestaPreguntasAutoevaluacion extends JpaRepository<RespuestasPreguntaAutoevaluacionEntity,Integer> {
}
