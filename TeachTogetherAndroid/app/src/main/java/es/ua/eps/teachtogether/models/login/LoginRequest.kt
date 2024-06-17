package es.ua.eps.teachtogether.models.login

data class LoginRequest(val usuario: String, val password: String, val rol: String)
