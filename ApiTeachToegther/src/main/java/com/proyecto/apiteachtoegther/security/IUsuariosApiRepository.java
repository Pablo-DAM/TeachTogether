package com.proyecto.apiteachtoegther.security;

import com.proyecto.apiteachtoegther.models.UsuariosEntity;
import org.springframework.data.jpa.repository.JpaRepository;

public interface IUsuariosApiRepository extends JpaRepository<UsuariosEntity,String> {
UsuariosEntity findByUsuario(String usuario);
}
