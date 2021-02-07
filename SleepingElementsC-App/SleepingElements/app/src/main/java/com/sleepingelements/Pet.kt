package com.sleepingelements

import android.app.AlertDialog
import android.content.Context
import android.content.DialogInterface
import android.content.SharedPreferences
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
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response



//Pet
var userPet: PetGet? = null
var userGot: User? = null

//DB Variables
var endpoint : Routes? = null
var grabbedPet: PetGet? = null //Pet grabber
var newPet: PetGet? = null //Pet Send Info

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
var petHandler = Handler(Looper.getMainLooper())
var washHandler = Handler(Looper.getMainLooper())
val updateClientHandler = Handler(Looper.myLooper()!!)

//Sickness variables
var isSick: Boolean? = false
var sicknessName: Array<String>? = null
var sicknessDialog: Boolean? = false

//Timer variables
// Timers are in millis
var feedTimer: Long? = 5000 //5 minutes 300000
var fedHandler = Handler(Looper.getMainLooper())
var petTimer: Long? = 5000 //15 minutes 900000
var washTimer: Long? = 5000 //15minutes 900000


private var prefs: SharedPreferences? = null


class Pet() : Fragment() {


    override fun onCreateView(
            inflater: LayoutInflater, container: ViewGroup?,
            savedInstanceState: Bundle?
    ): View? {



        endpoint = MainActivity().endpoint

        prefs = activity?.getPreferences(Context.MODE_PRIVATE)!!
        userGot = User(prefs!!.getInt("userID", 1))

        Log.d("PET USER", userGot.toString())

        petGrabber(userGot!!) {

            if (it?.petHP != null) {

                Log.d("[PetGrabbing Success]", "ok")


            } else {

                Log.d("[PetGrabbing Error]", "Grabbed Null")
                Log.d("[PetGrabbed Received]", it.toString())

            }

        }


        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_pet, container, false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        sicknessName = arrayOf("Fever", "Flu", "Diarrhea", "Covid-19")

        healthProgress = view?.findViewById<ProgressBar>(R.id.healthProgress)
        happinessProgress = view?.findViewById<ProgressBar>(R.id.happinessProgress)
        hygieneProgress = view?.findViewById<ProgressBar>(R.id.hygieneProgress)
        hungerProgress = view?.findViewById<ProgressBar>(R.id.hungerProgress)


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
            grabbedPet!!.petHungry -= (grabbedPet!!.petHungry * 0.05f).toInt()
            grabbedPet!!.petHappy += (grabbedPet!!.petHappy * 0.10f).toInt()

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
                sicknessHandler.postDelayed(this, 15000)

            }

        })

        //Looping the updating
        updateClientHandler.post(object : Runnable {

            override fun run() {


                sendInfo(grabbedPet!!)

                updateClientHandler.postDelayed(this, 10000)

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

            if (grabbedPet!!.petHP >= 75 && randomize > 90) {

                 isSick = true

            } else if (grabbedPet!!.petHP >= 50 && grabbedPet!!.petHP < 75 && randomize > 70) {

                isSick = true


            } else if (grabbedPet!!.petHP < 50 && randomize > 50) {

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
        if (grabbedPet!!.petHappy != 100) {

            grabbedPet!!.petHappy += 20
            grabbedPet!!.petHP = healthCalculator(grabbedPet!!.petHygiene, grabbedPet!!.petHungry, grabbedPet!!.petHappy)

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
        if (grabbedPet!!.petHygiene != 100) {

            grabbedPet!!.petHygiene += 20
            grabbedPet!!.petHP = healthCalculator(grabbedPet!!.petHygiene, grabbedPet!!.petHungry, grabbedPet!!.petHappy)

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
        if (grabbedPet!!.petHungry != 100) {

            grabbedPet!!.petHungry += 20
            grabbedPet!!.petHP = healthCalculator(grabbedPet!!.petHygiene, grabbedPet!!.petHungry, grabbedPet!!.petHappy)

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

        return  total as Int

    }

    //Function to control the stat reduction
    private fun progressReduction() {

        //If actions were done recently, that bar will not go down
        //It always goes down by 10% after every hour
        if (recentlyFed == false) {

            grabbedPet!!.petHungry -= (grabbedPet!!.petHungry * 0.1).toInt()

        }

        if (recentlyWashed == false ) {

            grabbedPet!!.petHygiene -= (grabbedPet!!.petHygiene * 0.1).toInt()

        }

        if (recentlyPat == false) {

                grabbedPet!!.petHappy -= (grabbedPet!!.petHappy * 0.1).toInt()

        }

        //If the pet is sick, it's happiness will go down 10% more than it would normally go
        if (isSick == true) {

            grabbedPet!!.petHappy -= (grabbedPet!!.petHappy * 0.1).toInt()

        }

        //Calculating the health every loop
        grabbedPet!!.petHP = healthCalculator(grabbedPet!!.petHygiene, grabbedPet!!.petHungry, grabbedPet!!.petHappy)
        grabbedPet!!.petHP = healthCalculator(grabbedPet!!.petHygiene, grabbedPet!!.petHungry, grabbedPet!!.petHappy)

    }



    //Database Related Functions
    private fun sendInfo(pet: PetGet) {

        petSender(pet) {

            if (it?.petHP != null) {

                Log.d("[Pet Sending Success]", "ok")

            } else {

                Log.d("[Pet Sending Error]", "Grabbed Null")
                Log.d("[Pet Sending Received]", it.toString())

            }

        }

        healthProgress!!.progress = grabbedPet!!.petHP
        hungerProgress!!.progress = grabbedPet!!.petHungry
        happinessProgress!!.progress = grabbedPet!!.petHappy
        hygieneProgress!!.progress = grabbedPet!!.petHygiene

    }

    private fun petGrabber(user: User, onResult: (PetGet?) -> Unit) {

        endpoint!!.getPet(user).enqueue(

                object : Callback<PetGet> {

                    override fun onFailure(call: Call<PetGet>, t: Throwable) {

                        onResult(null)
                        Log.d("[Failed Pet Grabbing]", t.message.toString())

                    }

                    override fun onResponse(call: Call<PetGet>, response: Response<PetGet>) {

                        grabbedPet = response.body()
                        onResult(grabbedPet)

                        Log.d("[PetGrabber] Received", response.body().toString())
                        MainActivity().userPet = grabbedPet

                        if(!response.isSuccessful) {

                            Log.d("[PetGrabber] Res Failed", response.body().toString())
                            return

                        }

                    }

                }

        )

    }

    private fun petSender(petGet: PetGet, onResult: (PetGet?) -> Unit) {

        endpoint!!.updatePet(petGet).enqueue(

                object : Callback<PetGet> {

                    override fun onFailure(call: Call<PetGet>, t: Throwable) {

                        onResult(null)

                        Log.d("[PetSender]", t.message.toString())


                    }

                    override fun onResponse(call: Call<PetGet>, response: Response<PetGet>) {

                        val result = response.body()
                        onResult(result)

                        Log.d("[PetSender] Sent", response.body().toString())

                        grabbedPet = response.body()

                        if(!response.isSuccessful) {

                            Log.d("[PetSender] Res Failed", response.body().toString())
                            return

                        }

                    }

                }

        )

    }

}




