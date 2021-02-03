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


class Exercise : Fragment(), SensorEventListener {

    private var sensorManager: SensorManager? = null
    private var steps: TextView? = null
    private var running = false
    private var back: Button? = null
    private var sensor: Sensor? = null
    private var exerciseTimer: Long? = 1200000 //20 minutes
    private var exerciseHandler = Handler(Looper.getMainLooper())

    override fun onCreateView(inflater: LayoutInflater, container: ViewGroup?,
                              savedInstanceState: Bundle?): View? {
        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_exercise, container, false)

    }


    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        back = view.findViewById(R.id.backPet)
        steps = view.findViewById(R.id.stepsCount)
        sensorManager = activity?.getSystemService(Context.SENSOR_SERVICE) as SensorManager?

        back!!.setOnClickListener {

            findNavController().navigate(R.id.action_exercise_to_pet)


        }

    }

    override fun onResume(){
        super.onResume()

        running = true

        sensor = sensorManager?.getDefaultSensor(Sensor.TYPE_STEP_DETECTOR)

        if (sensor == null) {

            Toast.makeText(this.context, "No step sensor detected on the device", Toast.LENGTH_SHORT).show()

        } else {

            sensorManager?.registerListener(this, sensor, SensorManager.SENSOR_DELAY_UI)

        }


    }

    override fun onPause() {
        super.onPause()

        running = false

    }

    override fun onSensorChanged(event: SensorEvent?) {

        if (running) {

            steps?.text = stepsToKilometer(event!!.values[0]).toString()
            Log.d("Steps", steps.toString())

        }

    }

    override fun onAccuracyChanged(sensor: Sensor?, accuracy: Int) {

        //This function does nothing, but is need

    }

    //Converting steps to kilometers
    private fun stepsToKilometer(steps: Float): Int {

        val m = steps * 0.76f
        val km = (m * pow(10.toDouble(), 3.toDouble())).toInt()

        return km

    }

}

