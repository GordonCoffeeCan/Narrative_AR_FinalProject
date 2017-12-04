using UnityEngine;
using System.Collections;

public class MorphTree: MonoBehaviour
{
	
	Animation anim;

    [Range(0, 1)]
    public float currentGrowth;
    public float addedValue;
	
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
}