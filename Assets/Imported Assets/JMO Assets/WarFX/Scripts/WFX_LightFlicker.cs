using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices.WindowsRuntime;

/**
 *	Rapidly sets a light on/off.
 *	
 *	(c) 2015, Jean Moreno
**/

[RequireComponent(typeof(Light))]
public class WFX_LightFlicker : MonoBehaviour
{

	void Start ()
	{
		StartCoroutine("Flicker");
	}
	
	IEnumerator Flicker()
	{
		while(true)
		{
			GetComponent<Light>().enabled = true;
			yield return new WaitForSeconds(0.0175f);
			GetComponent<Light>().enabled = false;
			yield return new WaitForSeconds(1f);
		
			
		}
	}
}
