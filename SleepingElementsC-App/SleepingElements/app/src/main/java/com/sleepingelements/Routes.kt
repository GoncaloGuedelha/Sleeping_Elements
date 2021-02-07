package com.sleepingelements

import retrofit2.Call
import retrofit2.http.*

interface Routes {

    //Logging in POST Function
    @POST("/login")
    fun login(@Body userData: UserCredentials): Call<User>


    //Getting pet POST function
    @POST("/getPet")
    fun getPet(@Body user: User): Call<PetGet>

    //Updating pet POST function
    @POST("/sendPetInfo")
    fun updatePet(@Body pet: PetGet): Call <PetGet>


}