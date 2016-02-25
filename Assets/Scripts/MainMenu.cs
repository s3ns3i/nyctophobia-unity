using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField]
    protected GameObject continueButton;
    //	[SerializeField]
    //	Button newGameButton;
    //	[SerializeField]
    //	Button optionsButton;
    [SerializeField]
	Slider soundSlider;
	//	[SerializeField]
	//	Text resolutionLabel;
	[SerializeField]
	Dropdown resolutionDropdown;
	[SerializeField]
	Dropdown qualityDropdown;
	[SerializeField]
	GameObject mainMenuGroup;
	[SerializeField]
	GameObject optionsGroup;

	Resolution[] resolutions;

	//	float margin = 10f;
	// Because on the two first settings "Fastest", and "Fast", game is not playable.
	int qualityMinimum = 2;

	// Use this for initialization
	protected void Start ()
	{
        continueButton.GetComponent<Text>().text = "New Game";
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        mainMenuGroup.SetActive (true);
		optionsGroup.SetActive (false);
		resolutions = Screen.resolutions;
		// if it's web, don't include Quit button.
#if UNITY_WEBGL
		quitButton.gameObject.SetActive (false);
		Vector3 buttonPosition = newGameButton.GetComponent<RectTransform> ().position;
		float y = buttonPosition.y - newGameButton.GetComponent<RectTransform> ().sizeDelta.y;
		newGameButton.GetComponent<RectTransform> ().position = new Vector3 (buttonPosition.x, y, buttonPosition.z);
		buttonPosition = optionsButton.GetComponent<RectTransform> ().position;
		y = buttonPosition.y - optionsButton.GetComponent<RectTransform> ().sizeDelta.y;
		optionsButton.GetComponent<RectTransform> ().position = new Vector3 (buttonPosition.x, y, buttonPosition.z);
		resolutionLabel.enabled = false;
		resolutionDropdown.enabled = false;
#endif
		// if it's mobile, make buttons bigger.

		// Populate dropdown lists and adjust sliders.
		List<string> qualityNames = new List<string> ();
		for (int i = qualityMinimum; i < QualitySettings.names.Length; i++)
			qualityNames.Add (QualitySettings.names [i]);
		qualityDropdown.AddOptions (qualityNames);
		qualityDropdown.value = QualitySettings.GetQualityLevel ();
		List<string> resolutionNames = new List<string> ();
		int currentResolution = 0;
		for (int i = 0; i < resolutions.Length; i++) {
			resolutionNames.Add (resolutions [i].width + "x" + resolutions [i].height);
			if (resolutions [i].width == Screen.currentResolution.width && resolutions [i].height == Screen.currentResolution.height)
				currentResolution = i;
		}
		resolutionDropdown.AddOptions (resolutionNames);
		resolutionDropdown.value = currentResolution;
		soundSlider.value = AudioListener.volume;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void NewGame ()
	{
		SceneManager.LoadScene (1);
	}

	public void Options ()
	{
		// Disable MainMenu group
		mainMenuGroup.SetActive (false);
		// Enable Options group
		optionsGroup.SetActive (true);
	}

	public void QuitGame ()
	{
		Application.Quit ();
	}

	public void Back ()
	{
		// Disable Options group
		optionsGroup.SetActive (false);
		// Enable Main Menu group
		mainMenuGroup.SetActive (true);
	}

	public void OnQualityChanged ()
	{
		QualitySettings.SetQualityLevel (qualityDropdown.value + qualityMinimum);
	}

	public void OnResolutionChanged ()
	{
		Debug.Log ("OnResolutionChanged() invoked");
		Screen.SetResolution (resolutions [resolutionDropdown.value].width, resolutions [resolutionDropdown.value].height, Screen.fullScreen);
	}

	public void OnSoundChanged ()
	{
		AudioListener.volume = soundSlider.value;
	}
}
