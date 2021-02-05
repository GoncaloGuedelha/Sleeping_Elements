package com.sleepingelements

import android.app.AlertDialog
import android.content.DialogInterface
import android.graphics.Color
import android.os.*
import android.util.Log
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.ProgressBar
import androidx.navigation.fragment.findNavController




//Progress Bars variables
var healthProgress : ProgressBar? = null
var happinessProgress : ProgressBar? = null
var hygieneProgress : ProgressBar? = null
var hungerProgress : ProgressBar? = null

//Actions on cool down
var recentlyWashed: Boolean? = false
var recentlyFed: Boolean? = false
var recentlyPat: Boolean? = false

//Handlers for the loop and random sickness
val loopHandler = Handler(Looper.getMainLooper())
val sicknessHandler = Handler(Looper.getMainLooper())

//Sickness variables
var isSick: Boolean? = false
var sicknessName: Array<String>? = null
var sicknessDialog: Boolean? = false

//Timer variables and looper handlers
// Timers are in millis
var feedTimer: Long? = 300000 //5 minutes
var fedHandler = Handler(Looper.getMainLooper())
var petTimer: Long? = 900000 //15 minutes
var petHandler = Handler(Looper.getMainLooper())
var washTimer: Long? = 900000 //15minutes
var washHandler = Handler(Looper.getMainLooper())

class Pet() : Fragment() {


    override fun onCreateView(
            inflater: LayoutInflater, container: ViewGroup?,
            savedInstanceState: Bundle?
    ): View? {
        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_pet, container, false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)



        healthProgress = view.findViewById<ProgressBar>(R.id.healthProgress)
        happinessProgress = view.findViewById<ProgressBar>(R.id.happinessProgress)
        hygieneProgress = view.findViewById<ProgressBar>(R.id.hygieneProgress)
        hungerProgress = view.findViewById<ProgressBar>(R.id.hungerProgress)

        sicknessName = arrayOf("Fever", "Flu", "Diarrhea", "Covid-19")

        //Going back to the main screen
        view.findViewById<Button>(R.id.pet_back).setOnClickListener {
            findNavController().navigate(R.id.action_pet_to_mainscreen)
        }

        //Petting the pet
        view.findViewById<Button>(R.id.petButton).setOnClickListener {

            pettingTime()

            petHandler.postDelayed( Runnable {

                //Enabling the button
                view.findViewById<Button>(R.id.petButton)?.isEnabled = true
                view.findViewById<Button>(R.id.petButton)?.setTextColor(Color.WHITE)
                view.findViewById<Button>(R.id.petButton)?.setBackgroundColor(Color.rgb(85, 107, 246))

                //Action off cool down
                recentlyPat = false

            }, petTimer!!)

        }

        //Washing the pet
        view.findViewById<Button>(R.id.washButton).setOnClickListener {

            washingTime()

            washHandler.postDelayed(Runnable {

                //Enabling the button
                view.findViewById<Button>(R.id.washButton)?.isEnabled = true
                view.findViewById<Button>(R.id.washButton)?.setTextColor(Color.WHITE)
                view.findViewById<Button>(R.id.washButton)?.setBackgroundColor(Color.rgb(85, 107, 246))

                //Action off cool down
                recentlyWashed = false

            }, washTimer!!)

        }

        //Feeding the pet
        view.findViewById<Button>(R.id.feedButton).setOnClickListener {

            feedingTime()

            fedHandler.postDelayed( Runnable {

                //Enabling the button
                view.findViewById<Button>(R.id.feedButton)?.isEnabled = true
                view.findViewById<Button>(R.id.feedButton)?.setTextColor(Color.WHITE)
                view.findViewById<Button>(R.id.feedButton)?.setBackgroundColor(Color.rgb(85, 107, 246))

                //Action off cool down
                recentlyFed = false

            }, feedTimer!!)

        }

        //Giving medicine to the pet
        view.findViewById<Button>(R.id.medicineButton).setOnClickListener{

            val alertBuilder = AlertDialog.Builder(this.context)

            alertBuilder.setMessage("You have cured your pet!")
            alertBuilder.setPositiveButton("Ok", DialogInterface.OnClickListener{dialog, id -> dialog.cancel()})

            val curedAlert = alertBuilder.create()
            curedAlert.setTitle("Medicine Used")
            curedAlert.show()

            //Giving medicine reduces Hunger by 5% and increases Happiness by 10%
            hungerProgress!!.progress -= (hungerProgress!!.progress * 0.05f).toInt()
            happinessProgress!!.progress += (happinessProgress!!.progress * 0.10f).toInt()

            isSick = false
            sicknessDialog = false

            view.findViewById<Button>(R.id.medicineButton)?.isEnabled = false
            view.findViewById<Button>(R.id.medicineButton)?.setTextColor(Color.DKGRAY)
            view.findViewById<Button>(R.id.medicineButton)?.setBackgroundColor(Color.GRAY)

        }


        //Button to change to the exercise screen
        view.findViewById<Button>(R.id.exerciseButton).setOnClickListener {

            findNavController().navigate(R.id.action_pet_to_exercise)

        }

        // Looper functions for sickness and progress reduction

        //Looping for the stat reduction
        loopHandler.post(object: Runnable {

            override fun run() {

                progressReduction()
                loopHandler.postDelayed(this, 3000)

            }

        })

        //Looping for random illness
        sicknessHandler.post(object: Runnable {

            override fun run() {

                randomSickness()
                sicknessHandler.postDelayed(this, 3000)

            }

        })

    }


    // Sickness Functions //

    //Function to give a random illness it's name
    private fun randomSickness() {

        val randomize: Int = (0..100).random()
        //val randomIllness: Int = (0..4).random()
        //var randomSicknessName: String? = null

        if (isSick == true) {

            sicknessAlert()
            sicknessDialog = true

            //Enabling the medicine button
            view?.findViewById<Button>(R.id.medicineButton)?.isEnabled = true
            view?.findViewById<Button>(R.id.medicineButton)?.setTextColor(Color.WHITE)
            view?.findViewById<Button>(R.id.medicineButton)?.setBackgroundColor(Color.rgb(85, 107, 246))

        } else if (isSick == false) {

            if (healthProgress!!.progress >= 75 && randomize > 90) {

                 isSick = true

            } else if (healthProgress!!.progress >= 50 && healthProgress!!.progress < 75 && randomize > 70) {

                isSick = true


            } else if (healthProgress!!.progress < 50 && randomize > 50) {

                isSick = true

            }

        }



    }

    //Function to make an alert dialog to inform the player that it's pet is sick
    private fun sicknessAlert() {

        if (sicknessDialog == false) {

            val alertBuilder = AlertDialog.Builder(this.context)

            alertBuilder.setMessage("Your pet has contracted an illness")
            alertBuilder.setPositiveButton("Oh no!", DialogInterface.OnClickListener { dialog, id -> dialog.cancel() })

            val curedAlert = alertBuilder.create()
            curedAlert.setTitle("Your pet is ill!")
            curedAlert.show()

        }

    }


    // Controlling stats Functions //

    //Function to control the petting button
    private fun pettingTime() {

        //Checking progress and updating it
        if (happinessProgress!!.progress != 100) {

            happinessProgress!!.progress += 20
            healthProgress!!.progress = healthCalculator(hygieneProgress!!.progress, hungerProgress!!.progress, happinessProgress!!.progress)

        }

        //Disabling the button
        view?.findViewById<Button>(R.id.petButton)?.isEnabled = false
        view?.findViewById<Button>(R.id.petButton)?.setTextColor(Color.DKGRAY)
        view?.findViewById<Button>(R.id.petButton)?.setBackgroundColor(Color.GRAY)

        //Action on cool down
        recentlyPat = true

    }

    //Function to control the washing button
    private fun washingTime() {

        //Checking the progress and updating it
        if (hygieneProgress!!.progress != 100) {

            hygieneProgress!!.progress += 20
            healthProgress!!.progress = healthCalculator(hygieneProgress!!.progress, hungerProgress!!.progress, happinessProgress!!.progress)

        }

        //Disabling the button
        view?.findViewById<Button>(R.id.washButton)?.isEnabled = false
        view?.findViewById<Button>(R.id.washButton)?.setTextColor(Color.DKGRAY)
        view?.findViewById<Button>(R.id.washButton)?.setBackgroundColor(Color.GRAY)

        //Action on cool down
        recentlyWashed = true

    }

    //Function to control the feeding button
    private fun feedingTime() {

        //Checking the progress and updating it
        if (hungerProgress!!.progress != 100) {

            hungerProgress!!.progress += 20
            healthProgress!!.progress = healthCalculator(hygieneProgress!!.progress, hungerProgress!!.progress, happinessProgress!!.progress)

        }

        //Disabling the button
        view?.findViewById<Button>(R.id.feedButton)?.isEnabled = false
        view?.findViewById<Button>(R.id.feedButton)?.setTextColor(Color.DKGRAY)
        view?.findViewById<Button>(R.id.feedButton)?.setBackgroundColor(Color.GRAY)

        //Action on cool down
        recentlyFed = true

    }

    //Function to calculate the health
    private fun healthCalculator(hygiene: Int, hunger: Int, happiness: Int): Int {

        //Health = 20% of Hygiene + 30% of Hunger + 50% of Happiness
        val total = (hygiene * 0.2 + hunger * 0.3 + happiness * 0.5).toInt()

        return total as Int

    }

    //Function to control the stat reduction
    private fun progressReduction() {

        //If actions were done recently, that bar will not go down
        //It always goes down by 10% after every hour
        if (recentlyFed == false) {

            hungerProgress!!.progress -= (hungerProgress!!.progress * 0.1).toInt()

        }

        if (recentlyWashed == false ) {

            hygieneProgress!!.progress -= (hygieneProgress!!.progress * 0.1).toInt()

        }

        if (recentlyPat == false) {

                happinessProgress!!.progress -= (happinessProgress!!.progress * 0.1).toInt()

        }

        //If the pet is sick, it's happiness will go down 10% more than it would normally go
        if (isSick == true) {

            happinessProgress!!.progress -= (happinessProgress!!.progress * 0.1).toInt()

        }

        //Calculating the health every loop
        healthProgress!!.progress = healthCalculator(hygieneProgress!!.progress, hungerProgress!!.progress, happinessProgress!!.progress)

    }



}




