using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {

    [SerializeField]
    float fadeTime;
    Image background;
    
	void Start ()
    {
        // problems
        // - CrossFadeAlpha works asynchronously but I need to change scene after the end
        // of the fading sequence
        // - need to stop game after opening last door and play fade in animation.
        // - change scene to credits
        // - on click or set time change to main menu again
        Debug.Log("prepare to lol");
        background = GetComponent<Image>();
        background.canvasRenderer.SetAlpha(0f);
        background.CrossFadeAlpha(1f, fadeTime, false);
        Debug.Log("loled");
	}
}
