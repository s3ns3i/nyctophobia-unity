using UnityEngine;
using System.Collections;

public class FlickerTrigger : MonoBehaviour
{

	[SerializeField]
	GameObject flashlight;

	bool triggerActive;

	void OnTriggerEnter ()
	{
		// Start flickering flashlights light
		Debug.Log ("DarknessTrigger");
		triggerActive = true;
		StartCoroutine (flicker ());
	}

	void OnTriggerStay ()
	{
		
	}

	void OnTriggerExit ()
	{
		// Stop flickering.
		triggerActive = false;
		StopCoroutine (flicker ());
		flashlight.SetActive (true);
	}

	IEnumerator flicker ()
	{
		Debug.Log ("Flicker");
		float randomTime;
		while (triggerActive) {
			randomTime = ((float)Random.Range (200, 1000) / 1000f);
			yield return new WaitForSeconds (randomTime);
			if (flashlight.activeSelf) {
				flashlight.SetActive (false);
			} else {
				flashlight.SetActive (true);
			}
		}
	}
}
