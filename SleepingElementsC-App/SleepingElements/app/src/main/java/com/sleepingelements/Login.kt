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


class Login : Fragment() {


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

        //Checking if they are equal to the defaults (needs to be changed to the database)
        if (userInput == defUser && passInput == defPass) {

            Log.d("Hey", userInput.toString() + " " + passInput.toString())
            Toast.makeText(this.context, "Welcome $userInput", Toast.LENGTH_SHORT).show()

            findNavController().navigate(R.id.action_login_to_mainscreen)

        } else {

            Toast.makeText(this.context, "Username / Password combination wrong", Toast.LENGTH_LONG).show()

        }

    }


}