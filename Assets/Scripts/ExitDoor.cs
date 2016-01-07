using UnityEngine;
using System.Collections;

public class ExitDoor : Door
{

	protected override bool doorAction ()
	{
		// Fade screen to black and play door opening sound. Then show message and after 10 seconds go to main menu
		// If user clicks any button, go to main menu
		Debug.Log ("Opened exit door");
		return true;
	}
}

