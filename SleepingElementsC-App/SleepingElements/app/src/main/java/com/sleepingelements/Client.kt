package com.sleepingelements

import com.google.gson.Gson
import okhttp3.OkHttpClient
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory

class Client {


    companion object {

        //Returns a Retrofit Client Instance
        fun getRetrofitInstance(path: String): Retrofit {

            return Retrofit.Builder()
                    .baseUrl(path)
                    .addConverterFactory(GsonConverterFactory.create()) //Retrofit client can now convert to JSON
                    .build()

        }

    }

}