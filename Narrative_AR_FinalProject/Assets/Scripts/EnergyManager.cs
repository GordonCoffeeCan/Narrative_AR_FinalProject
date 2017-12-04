using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyManager : MonoBehaviour {

    public static EnergyManager instance;

    [SerializeField] private Text totalEnergyNumber;

    [SerializeField] private Image MenuPanel;

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

    [HideInInspector] public int nutrientsPoint;

    // Use this for initialization
    void Start () {
        instance = this;

    }
	
	// Update is called once per frame
	void Update () {
        
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

    public void OnConfirm() {
        if (sleepSlider.value < 8 || sleepSlider.value > 10) {
            nutrientsPoint -= 1;
        }else if (sleepSlider.value >= 8 || sleepSlider.value <= 10) {
            nutrientsPoint += 2;
        }

        if (caloriesSlider.value < 1200 || caloriesSlider.value > 1600) {
            nutrientsPoint -= 1;
        }else if (caloriesSlider.value >= 1200 || caloriesSlider.value <= 1600) {
            nutrientsPoint += 2;
        }

        if (exercisedSlider. value < 30 || exercisedSlider.value > 60) {
            nutrientsPoint -= 1;
        } else if (exercisedSlider.value >= 30 || exercisedSlider.value <= 60) {
            nutrientsPoint += 2;
        }

        if (smokedYes.isOn) {
            nutrientsPoint -= 2;
        } else {
            nutrientsPoint += 2;
        }

        if (drinkedYes.isOn) {
            nutrientsPoint -= 2;
        } else {
            nutrientsPoint += 2;
        }

        totalEnergyNumber.text = nutrientsPoint.ToString();
        MenuPanel.gameObject.SetActive(false);
    }
}
