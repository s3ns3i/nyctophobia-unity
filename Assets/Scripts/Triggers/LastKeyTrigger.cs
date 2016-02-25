using UnityEngine;

public class LastKeyTrigger : UnityEngine.MonoBehaviour
{

    [SerializeField]
    GameObject boulders;

    // Object will be destroyed, so this will get fired.
    public void OnDestroy()
    {
        if (boulders != null)
        {
            boulders.SetActive(true);
            boulders.GetComponent<AudioSource>().Play();
        }
    }
}
