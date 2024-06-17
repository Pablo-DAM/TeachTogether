package es.ua.eps.teachtogether.models.login



data class LoginResponse(
    val id: Int,
    val token: Token
)

data class Token(
    val token: String,
    val tokenType: String
)