package com.sleepingelements

import retrofit2.Call
import retrofit2.http.*

interface Routes {


    @POST("getPet")
    fun getPet(@Body userData: User): Call<List<User>>

    @Headers("Content-Type: application/json")
    @POST("sendPetInfo")
    fun updatePet(@Body userData: Pet): Call <Pet>

    @POST("players/login")
    fun login(@Body userData: UserCredentials)

}