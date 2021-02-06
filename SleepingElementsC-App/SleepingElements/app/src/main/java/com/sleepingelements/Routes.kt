package com.sleepingelements

import retrofit2.Call
import retrofit2.Response
import retrofit2.http.*

interface Routes {


    //@GET("getPet")

    //@POST("sendPetInfo")
    //fun updatePet(@Body userData: Pet): Call <Pet>

    @POST("pet/login")
    fun login(@Body userData: UserCredentials): Call<User>

}