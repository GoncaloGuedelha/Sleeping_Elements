package com.sleepingelements

import android.content.Context
import android.content.pm.PackageManager
import android.hardware.Sensor
import android.hardware.SensorEvent
import android.hardware.SensorManager
import android.os.Build
import android.os.Bundle
import android.util.Log
import androidx.appcompat.app.AppCompatActivity
import android.view.Menu
import android.widget.Toast
import androidx.annotation.RequiresApi
import androidx.core.app.ActivityCompat
import java.util.jar.Manifest
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response



public class MainActivity : AppCompatActivity() {

    //DB communication
    private val retrofitClient = Client.getRetrofitInstance("https://10.0.0.2:3000/")
    private val endpoint = retrofitClient.create(Routes::class.java)

    //@RequiresApi(Build.VERSION_CODES.Q)

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
        setSupportActionBar(findViewById(R.id.toolbar))
        supportActionBar?.hide()

    }

    override fun onCreateOptionsMenu(menu: Menu): Boolean {
        // Inflate the menu; this adds items to the action bar if it is present.
        menuInflater.inflate(R.menu.menu_main, menu)
        return true
    }


    fun checkLogin(cont: Context, userCred: UserCredentials, onResult: (User?) -> Unit) {

        endpoint.login(userCred).enqueue(
                object :  retrofit2.Callback<User> {

                    override fun onFailure(call: Call<User>, t:Throwable) {

                        onResult(null)
                        Log.d("failure", t.message.toString())
                        Toast.makeText(cont, "Connection Failed", Toast.LENGTH_SHORT).show()

                    }

                    override fun onResponse(call: Call<User>, response: Response<User>) {

                        val loggedUser = response.body()
                        onResult(loggedUser)

                        if(!response.isSuccessful){

                            Log.d("Response Failed", response.code().toString())
                            return

                        }


                    }

                }


        )

    }


}