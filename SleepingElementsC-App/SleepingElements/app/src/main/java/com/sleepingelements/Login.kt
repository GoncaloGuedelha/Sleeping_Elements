package com.sleepingelements

import android.content.Context
import android.content.SharedPreferences
import android.os.Bundle
import android.util.Log
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.TextView
import android.widget.Toast
import androidx.fragment.app.FragmentManager
import androidx.navigation.fragment.findNavController
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response


class Login : Fragment() {

    var endpoint: Routes? = null

    //Input variables
    var userInput: String? = null
    var passInput: String? = null

    //User fields
    var userField: TextView? = null
    var passField: TextView? = null

    //Post Variables
    var loggedUser: User? = null

    //Shared Preferences
    private lateinit var prefs: SharedPreferences


    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        endpoint = MainActivity().endpoint

        prefs = activity?.getPreferences(Context.MODE_PRIVATE)!!

    }

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_login, container, false)

    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        //Defining the inputs as variables
        userField = view.findViewById<TextView>(R.id.userInput)
        passField = view.findViewById<TextView>(R.id.passInput)

        //Login Button pressed
        view.findViewById<Button>(R.id.loginButton).setOnClickListener {

            buttonPressed()

        }

    }

    private fun buttonPressed() {

        //Getting the user inputs for username and password
        userInput = userField?.text.toString()
        passInput = passField?.text.toString()

        val userCreds = UserCredentials(userInput.toString(), passInput.toString())

        Log.d("Info Sent:", UserCredentials(userInput.toString(), passInput.toString()).toString())

        CheckLogin(userCreds) {

            if(it?.user_id != null) {

                Log.d("[Login Success]", "Ok")

                findNavController().navigate(R.id.action_login_to_mainscreen)




            } else {
                Log.d("Error", "Connection Established, Null Received")
                Log.d("[USER RECEIVED]", it.toString())
            }

        }

    }

    private fun CheckLogin(userCred: UserCredentials, onResult: (User?) -> Unit) {

        endpoint!!.login(userCred).enqueue(
            object :  Callback<User> {

                override fun onFailure(call: Call<User>, t:Throwable) {

                    onResult(null)
                    Log.d("Can't Login", t.message.toString())
                    Log.d("[LOGIN RECEIVED]", onResult.toString())
                    Toast.makeText(context, "Connection Failed", Toast.LENGTH_SHORT).show()


                }

                override fun onResponse(call: Call<User>, response: Response<User>) {

                    loggedUser = response.body()
                    onResult(loggedUser)

                    prefs.edit().putInt("userID", response.body()!!.user_id)
                    prefs.edit().apply()


                    Log.d("[RECEIVED]", response.body().toString())

                    MainActivity().userGot = loggedUser

                    if(!response.isSuccessful){

                        Log.d("Response Failed", response.code().toString())
                        return

                    }

                }

            }


        )

    }




}


