package com.proyecto.apiteachtoegther.services;

import com.proyecto.apiteachtoegther.models.MensajesEntity;
import com.proyecto.apiteachtoegther.repositories.IMensajesRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.Optional;

@Service
public class MensajesService {
    @Autowired
    IMensajesRepository mensajesRepository;
    public ArrayList<MensajesEntity> getMensajes(){
        return (ArrayList<MensajesEntity>) mensajesRepository.findAll();
    }
    public MensajesEntity saveMensaje(MensajesEntity mensaje) {
        return mensajesRepository.save(mensaje);
    }
    public Optional<MensajesEntity> getById(Integer id) {
        return mensajesRepository.findById(id);
    }
    public MensajesEntity updateById(MensajesEntity request, Integer id) {
        MensajesEntity mensaje = mensajesRepository.findById(id).get();
        mensaje.setIdMensaje(request.getIdMensaje());
        mensaje.setTexto(request.getTexto());
        mensaje.setFechaCreaccion(request.getFechaCreaccion());
        mensaje.setIdCreador(request.getIdCreador());
        mensajesRepository.save(mensaje);
        return mensaje;
    }

    public boolean deleteMensaje(Integer id) {
        if (mensajesRepository.existsById(id)) { // Verifica si el mensaje existe
            mensajesRepository.deleteById(id); // Elimina el mensaje
            return true; // Retorna true porque el mensaje existía y fue eliminado
        } else {
            return false; // Retorna false porque el mensaje no existía
        }
    }
}
