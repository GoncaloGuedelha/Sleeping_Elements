package com.sleepingelements

import com.google.gson.annotations.SerializedName

data class PetGet(

    @SerializedName("PetName")
    val petName: String,
    @SerializedName("petHealthProgress")
    val petHP: Int,
    @SerializedName("petHappinessProgress")
    val petHappy: Int,
    @SerializedName("petHungerProgress")
    val petHungry: Int,
    @SerializedName("petHygieneProgress")
    val petHygiene: Int,

)