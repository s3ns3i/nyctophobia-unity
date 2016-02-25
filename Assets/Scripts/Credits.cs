using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {

    [SerializeField] float timeToWait;

	// Use this for initialization
	void Start () {
        StartCoroutine(GoBackToMenu());
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(0);
        }
	}

    IEnumerator GoBackToMenu()
    {
        yield return new WaitForSeconds(timeToWait);
        SceneManager.LoadScene(0);
    }
}
