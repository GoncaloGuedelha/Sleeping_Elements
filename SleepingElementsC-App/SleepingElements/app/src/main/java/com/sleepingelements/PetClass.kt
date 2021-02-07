package com.sleepingelements

import com.google.gson.annotations.SerializedName

data class PetGet(

    @SerializedName("Petname")
    var petName: String,
    @SerializedName("petHealthProgress")
    var petHP: Int,
    @SerializedName("petHappinessProgress")
    var petHappy: Int,
    @SerializedName("petHungerProgress")
    var petHungry: Int,
    @SerializedName("petHygieneProgress")
    var petHygiene: Int,
    @SerializedName("pet_ID")
    var petID: Int,

)