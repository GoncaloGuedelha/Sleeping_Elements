package com.sleepingelements

import com.google.gson.annotations.SerializedName
import retrofit2.http.POST

data class User (

    @SerializedName("Username")
    val username: String,
    @SerializedName("User_ID")
    val user_id: Int,

)

data class UserCredentials (

    @SerializedName ("Username")
    val username: String,
    @SerializedName ("Password")
    val password: String,

)