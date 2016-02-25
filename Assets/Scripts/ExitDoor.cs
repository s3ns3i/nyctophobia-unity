using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ExitDoor : Door
{
    
    [SerializeField]
    float timeBeforeSceneChange;
    [SerializeField]
    GameObject screenFader;

	protected override bool doorAction ()
	{
        // Fade screen to black and play door opening sound. Then show message and after 10 seconds go to main menu
        // If user clicks any button, go to main menu
        StartCoroutine(OpenDoor());
		return true;
	}

    IEnumerator OpenDoor()
    {
        Debug.Log("Opened exit door");
        // Block player controls

        GetComponent<Sounds>().PlaySound(0, 1f);
        // Activate fade
        screenFader.SetActive(true);
        yield return new WaitForSeconds(timeBeforeSceneChange);
        SceneManager.LoadScene("Credits");
        yield return null;
    }
}

