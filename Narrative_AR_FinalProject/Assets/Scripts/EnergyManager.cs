using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyManager : MonoBehaviour {

    [SerializeField] private Text totalEnergyNumber;

    [SerializeField] private Text sleepHourNumber;
    [SerializeField] private Text caloriesNumber;
    [SerializeField] private Text exercisedNumber;

    [SerializeField] private Slider sleepSlider;
    [SerializeField] private Slider caloriesSlider;
    [SerializeField] private Slider exercisedSlider;

    [SerializeField] private Toggle smokedYes;
    [SerializeField] private Toggle smokedNo;

    [SerializeField] private Toggle drinkedYes;
    [SerializeField] private Toggle drinkedNo;

    [SerializeField] private Button confirmButton;

    [HideInInspector] public int energyPoints;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        totalEnergyNumber.text = energyPoints.ToString();
	}

    public void changeSleepHours() {
        sleepHourNumber.text = sleepSlider.value.ToString() + " Hours";
    }

    public void changeCaloriesInput() {
        caloriesNumber.text = caloriesSlider.value.ToString() + " Cal";
    }

    public void changeExerciseTime() {
        exercisedNumber.text = exercisedSlider.value.ToString() + " Minutes";
    }

    public void changeSmokeYesToggle() {
        smokedNo.isOn = !smokedYes.isOn;
    }

    public void changeSmokeNoToggle() {
        smokedYes.isOn = !smokedNo.isOn;
    }

    public void changeDrinkYesToggle() {
        drinkedNo.isOn = !drinkedYes.isOn;
    }

    public void changeDrinkNoToggle() {
        drinkedYes.isOn = !drinkedNo.isOn;
    }
}
