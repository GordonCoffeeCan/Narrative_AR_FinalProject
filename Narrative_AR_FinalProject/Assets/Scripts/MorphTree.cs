using UnityEngine;
using System.Collections;

public class MorphTree: MonoBehaviour
{
	
	Animation anim;

    [Range(0, 1)]
    public float currentGrowth;
    public float addedValue;
    public float morphTime;
    public float pointsGained;
	
	void Start ()
	{
		
		//transform.GetComponent<Animation> ().Play ("init");
		
	}

	void Awake ()
	{
		anim = GetComponent<Animation> ();
	}


	
	void Update ()
	{
        anim["grow"].normalizedTime = currentGrowth;
			
			transform.GetComponent<Animation> ().Play ("grow");
	}

    public void buttonPress ()
    {
        pointsGained = EnergyManager.instance.nutrientsPoint;
    }

    IEnumerator PointUpdate ()
    {
        addedValue = pointsGained * .1f;
        yield return new WaitForSeconds(1f);

        Mathf.Lerp(currentGrowth,currentGrowth + addedValue, morphTime);
    }
}