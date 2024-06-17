package es.ua.eps.teachtogether.services

import es.ua.eps.teachtogether.models.autoevaluacionUsuario.AutoevaluacionUsuarioPUTRequest
import es.ua.eps.teachtogether.models.autoevaluacionUsuario.AutoevaluacionUsuarioResponse
import es.ua.eps.teachtogether.models.autoevaluacionUsuarioModulo.AutoevaluacionUsuarioModuloResponse
import es.ua.eps.teachtogether.models.autoevaluaciones.AutoevaluacionesResponse
import es.ua.eps.teachtogether.models.login.LoginRequest
import es.ua.eps.teachtogether.models.login.LoginResponse
import es.ua.eps.teachtogether.models.mensajes.MensajeRequest
import es.ua.eps.teachtogether.models.perfil.PerfilPUTRequest
import es.ua.eps.teachtogether.models.perfil.PerfilRequest
import es.ua.eps.teachtogether.models.perfil.PerfilResponse
import es.ua.eps.teachtogether.models.registro.RegistroRequest
import es.ua.eps.teachtogether.models.registro.RegistroResponse
import es.ua.eps.teachtogether.models.usuario.UsuarioPUTRequest
import es.ua.eps.teachtogether.models.usuario.UsuarioResponse
import es.ua.eps.teachtogether.models.mensajes.MensajesResponse
import es.ua.eps.teachtogether.models.modulos.ModulosResponse
import es.ua.eps.teachtogether.models.preguntas.PreguntasResponse
import es.ua.eps.teachtogether.models.respuestas.RespuestaRequest
import es.ua.eps.teachtogether.models.respuestas.RespuestaResponse
import es.ua.eps.teachtogether.models.usuarioModulo.usuarioModuloRequest
import es.ua.eps.teachtogether.models.usuarioModulo.UsuarioModuloResponse
import retrofit2.Call
import retrofit2.http.Body
import retrofit2.http.DELETE
import retrofit2.http.GET
import retrofit2.http.POST
import retrofit2.http.PUT
import retrofit2.http.Path

interface ApiService {
    //LOGIN
    @POST("login")
    fun login(@Body loginRequest: LoginRequest): Call<LoginResponse>
    //REGISTRO USUARIO
    @POST("registro")
    fun registro(@Body registroRequest: RegistroRequest):Call<RegistroResponse>
    // POST PERFIL
    @POST("perfil")
    fun postPerfil(@Body perfilRequest: PerfilRequest):Call<Void>
    // GET PERFIL BY USUARIO ID
    @GET("perfil/usuario/{idUsuario}")
    fun getPerfil(@Path("idUsuario") idUsuario: Int): Call<PerfilResponse>
    //PUT PERFIL
    @PUT("perfil")
    fun putPerfil(@Body perfilPUTRequest: PerfilPUTRequest):Call<PerfilResponse>
    //PUT USUARIO (cambiar contraseña)
    @PUT("usuario")
    fun putUsuario(@Body usuarioPUTRequest: UsuarioPUTRequest):Call<Void>
    //GET Usuario por ID
    @GET("usuario/{id}")
    fun getUsuarioByID(@Path("id") id: Int): Call<UsuarioResponse>
    //Get Mensajes
    @GET("mensaje")
    fun getMensajes():Call <List<MensajesResponse>>
    //GET Perfil por ID de Usuario
    @GET("perfil/usuario/{idUsuario}")
    fun getPerfilByUsuarioID(@Path("idUsuario")idUsuario: Int):Call<PerfilResponse>
    //DELETE MENSAJE BY ID
    @DELETE("mensaje/{id}")
    fun deleteMensajeByID(@Path("id")id: Int):Call<Void>
    //POST Mensaje
    @POST("mensaje")
    fun postMensaje(@Body mensajeRequest: MensajeRequest):Call<Void>
    //GET usuarios
    @GET("usuario")
    fun getUsuarios():Call<List<UsuarioResponse>>
    //GET perfiles
    @GET("perfil")
    fun getPerfiles():Call<List<PerfilResponse>>
    //GET Modulos
    @GET("modulo")
    fun getModulos():Call<List<ModulosResponse>>
    //POST UsuarioModulo
    @POST("usuarioModulo")
    fun postUsuarioModulo(@Body usuarioModuloRequest: usuarioModuloRequest):Call<Void>
    //GET UsuarioModulo By Usuario
    @GET("usuarioModulo/{idUsuario}/{idModulo}")
    fun getUsuariosModulos(@Path("idUsuario") idUsuario: Int,
                           @Path("idModulo")idModulo:Int):Call<UsuarioModuloResponse>
    // GET Todos Usuarios Modulos
    @GET("usuarioModulo")
    fun getAllUsuariosModulos():Call<List<UsuarioModuloResponse>>
    //DELETE UsuarioModulo
    @DELETE("usuarioModulo/{idAlumno}/{idModulo}")
    fun deleteUsuarioModulo(@Path ("idAlumno")idAlumno:Int,@Path("idModulo")idModulo:Int):Call<Void>
    // GET Todos AutoevaluacionesUsuarios
    @GET("autoevaluacionUsuario")
    fun getAllAutoevaluacionesUsuarios():Call<List<AutoevaluacionUsuarioResponse>>
    //GET Autoevaluaciones BY Modulo ID
    @GET("modulo/modAuto/{idMod}")
    fun getAllAutoevaluacionesByModuloID(@Path("idMod")idMod:Int):Call<List<AutoevaluacionUsuarioModuloResponse>>
    //GET ALL Autoevaluaciones
    @GET ("autoevaluacion")
    fun getAutoevaluaciones():Call<List<AutoevaluacionesResponse>>
    //GET ALL PreguntasAutoevaluacion
    @GET("pregunta")
    //GET ALL RespuestasPreguntasAutoevaluacion
    fun getAllPreguntas():Call<List<PreguntasResponse>>
    @GET("respuestaAutoevaluacion")
    fun getAllRespuestas():Call<List<RespuestaResponse>>
    //POST Respuesta
    @POST("respuestaAutoevaluacion")
    fun postRespuesta(@Body respuestaRequest:RespuestaRequest):Call<Void>
    //UPDATE AutoevaluacionUsuario (Realizar autoevaluación)
    @PUT("autoevaluacionUsuario")
    fun putAutoevaluacionUsuario(@Body autoevaluacionUsuarioPUTRequest: AutoevaluacionUsuarioPUTRequest):Call<Void>
    // GET AutoevaluacionUsuario BY IDAutoevaluacion AND IDUsuario
    @GET("autoevaluacionUsuario({idAu}/{idUsu}")
    fun getAutoevUsuaByIDS(@Path("idAu") idAu: Int,@Path("idUsu") idUsu:Int):Call<AutoevaluacionUsuarioResponse>
}