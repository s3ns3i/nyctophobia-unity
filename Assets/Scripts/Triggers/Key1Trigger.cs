using UnityEngine;

public class Key1Trigger : MonoBehaviour
{

    [SerializeField]
    GameObject victim;
    [SerializeField]
    GameObject prop;

    void OnDestroy()
    {
        if (victim != null && prop != null)
        {
            Vector3 relativePosition = victim.transform.position - prop.transform.position;
            relativePosition.y = 0f;
            // Rotate prop so it will face player.
            prop.transform.rotation = Quaternion.LookRotation(relativePosition, Vector3.up);
            //play sound
            prop.gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
