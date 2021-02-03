package com.sleepingelements

import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.navigation.fragment.findNavController
import java.util.Timer
import kotlin.concurrent.schedule

/**
 * A simple [Fragment] subclass as the default destination in the navigation.
 */
class SplashScreen : Fragment() {

    var splashTimer: Float = 1f


    override fun onCreateView(
            inflater: LayoutInflater, container: ViewGroup?,
            savedInstanceState: Bundle?
    ): View? {
        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_splashscreen, container, false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        Timer("Navigate", false).schedule(2000) {

            findNavController().navigate(R.id.action_splash_to_login)

        }

    }
}