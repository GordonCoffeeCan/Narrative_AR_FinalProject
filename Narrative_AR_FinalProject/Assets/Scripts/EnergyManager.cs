using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyManager : MonoBehaviour {

    public static EnergyManager instance;

    [SerializeField] private MorphTree treeGrowth;
    [SerializeField] private Transform Ground;
    [SerializeField] private Transform treeParticle;

    [SerializeField] private Text totalEnergyNumber;

    [SerializeField] private Image MenuPanel;

    [SerializeField] private Text sleepHourNumber;
    [SerializeField] private Text caloriesNumber;
    [SerializeField] private Text exercisedNumber;

    [SerializeField] private Slider sleepSlider;
    [SerializeField] private Slider caloriesSlider;
    [SerializeField] private Slider exercisedSlider;

    [SerializeField] private Toggle smokedYes;

    [SerializeField] private Toggle drinkedYes;

    [SerializeField] private Button newDayButton;

    [HideInInspector] public int nutrientsPoint;

    [HideInInspector] public bool targetFound = false;

    private float targetAmount = 0;

    // Use this for initialization
    void Start () {
        instance = this;
    }
	
	// Update is called once per frame
	void Update () {
        if(nutrientsPoint != 0 && targetFound) {
            treeGrowth.currentGrowth = Mathf.MoveTowards(treeGrowth.currentGrowth, targetAmount, 0.002f);
            Ground.localScale = new Vector3(1 + treeGrowth.currentGrowth * 4, 1 + treeGrowth.currentGrowth * 0.5f, 1 + treeGrowth.currentGrowth * 4);
            treeParticle.localPosition = new Vector3(0, 0.5f + treeGrowth.currentGrowth * 5.5f, 0);
            treeParticle.localScale = new Vector3(1 + treeGrowth.currentGrowth * 9, 1 + treeGrowth.currentGrowth * 9, 1 + treeGrowth.currentGrowth * 9);
            Debug.Log(treeGrowth.currentGrowth);
        }
    }

    public void ChangeSleepHours() {
        sleepHourNumber.text = sleepSlider.value.ToString() + " HOURS";
    }

    public void ChangeCaloriesInput() {
        caloriesNumber.text = caloriesSlider.value.ToString() + " CAL";
    }

    public void ChangeExerciseTime() {
        exercisedNumber.text = exercisedSlider.value.ToString() + " MINUTES";
    }

    public void OnNewDay() {
        sleepSlider.value = 0;
        caloriesSlider.value = 0;
        exercisedSlider.value = 0;
        smokedYes.isOn = false;
        drinkedYes.isOn = false;
        nutrientsPoint = 0;
        totalEnergyNumber.text = nutrientsPoint.ToString() + " POINT";
        newDayButton.gameObject.SetActive(false);
        MenuPanel.gameObject.SetActive(true);
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

        if (exercisedSlider.value < 30 || exercisedSlider.value > 60) {
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

        totalEnergyNumber.text = nutrientsPoint.ToString() + " POINT";
        MenuPanel.gameObject.SetActive(false);
        newDayButton.gameObject.SetActive(true);

        targetAmount = treeGrowth.currentGrowth + (float)nutrientsPoint / 100;
    }
}
