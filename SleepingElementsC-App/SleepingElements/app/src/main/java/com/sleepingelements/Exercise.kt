package com.sleepingelements

import  android.content.Context
import android.hardware.Sensor
import android.hardware.SensorEvent
import android.hardware.SensorEventListener
import android.hardware.SensorManager
import android.os.Bundle
import android.os.Handler
import android.os.Looper
import android.util.Log
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.TextView
import android.widget.Toast
import androidx.core.content.getSystemService
import androidx.navigation.fragment.findNavController
import java.lang.Math.pow
import java.util.Arrays.toString
import kotlin.math.pow



class Exercise : Fragment(), SensorEventListener {

    //Step Counting variables
    private var sensorManager: SensorManager? = null
    private var steps: TextView? = null
    private var running = false
    private var sensor: Sensor? = null

    //List of Step Counter Events
    private var stepEventArray = mutableListOf<Int>()

    //Button Variables
    private var back: Button? = null

    //Timer variables
    private var exerciseTimer: Long? = 1200000 //20 minutes
    private var exerciseHandler = Handler(Looper.getMainLooper())



    override fun onCreateView(inflater: LayoutInflater, container: ViewGroup?,
                              savedInstanceState: Bundle?): View? {

        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_exercise, container, false)



    }


    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        sensorManager = activity?.getSystemService(Context.SENSOR_SERVICE) as SensorManager?

        back = view.findViewById(R.id.backPet)
        steps = view.findViewById(R.id.stepsCount)
        back!!.setOnClickListener {

            findNavController().navigate(R.id.action_exercise_to_pet)


        }

    }

    override fun onResume(){
        super.onResume()

        running = true

        sensor = sensorManager?.getDefaultSensor(Sensor.TYPE_STEP_COUNTER)

        if (sensor == null) {

            Toast.makeText(this.context, "No step sensor detected on the device", Toast.LENGTH_SHORT).show()

        } else {

            sensorManager?.registerListener(this, sensor, SensorManager.SENSOR_DELAY_UI)

        }


    }

    override fun onPause() {
        super.onPause()

        running = false
        sensorManager?.unregisterListener(this)

    }

    override fun onSensorChanged(event: SensorEvent?) {

        if (running) {

            stepEventArray.add(event!!.values[0].toInt())

            steps?.text = (event.values[0] - stepEventArray[0]).toString()
            Log.d("Event", steps?.text.toString())

        }

    }

    override fun onAccuracyChanged(sensor: Sensor?, accuracy: Int) {

        //This function does nothing, but is need

    }

    //Converting steps to kilometers
    private fun stepsToKilometer(steps: Float): Int {

        val m = steps * 0.76f
        return (m * 10.toDouble().pow(3.toDouble())).toInt()

    }

}

