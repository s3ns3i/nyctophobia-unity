using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class StaminaBar : MonoBehaviour
{
	[SerializeField]
	GameObject staminaBar;
	[SerializeField]
	GameObject staminaCurrentBar;
	[SerializeField]
	GameObject player;

	FirstPersonControllerModified playerController;

	// Use this for initialization
	void Start ()
	{
//		player.GetComponent<Transform> ().localRotation = new Quaternion (0f, 1f, 0f, 0f);
		playerController = player.GetComponent<FirstPersonControllerModified> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	void OnGUI ()
	{
		float barHeight = staminaBar.GetComponent<RectTransform> ().sizeDelta.y;
		float barWidth = staminaBar.GetComponent<RectTransform> ().sizeDelta.x;
		float currentBarWidth = (playerController.Stamina * barWidth) /
		                        playerController.MaxStamina;
		Vector2 barSize = new Vector2 (currentBarWidth, barHeight);
		staminaCurrentBar.GetComponent<RectTransform> ().sizeDelta = barSize;
	}
}