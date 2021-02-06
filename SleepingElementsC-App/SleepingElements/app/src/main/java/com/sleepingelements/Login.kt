package com.sleepingelements

import android.os.Bundle
import android.util.Log
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.TextView
import android.widget.Toast
import androidx.navigation.fragment.findNavController
import retrofit2.Call
import retrofit2.Response
import javax.security.auth.callback.Callback


class Login : Fragment() {

    var userInputs = mutableListOf<String>()

    //Variables to hold the comparable strings
    var defUser: String = "Leon"
    var defPass: String = "Leon"

    //Input variables
    var userInput: String? = null
    var passInput: String? = null

    //User fields
    var userField: TextView? = null
    var passField: TextView? = null

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)



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

        MainActivity().checkLogin(this.requireContext(), userCreds) {

            Log.d("Response from Server", it.toString())

            if(it?.user_id != null) {
                Log.d("Ok", "Ok")
            } else {
                Log.d("Error", "Error")
            }

        }

    }


}


