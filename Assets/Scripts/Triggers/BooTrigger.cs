using UnityEngine;

public class BooTrigger : MonoBehaviour {

    [SerializeField]
    protected GameObject propObject;
    [SerializeField]
    protected string parameterName;
    protected Animator ghostAnimator;

    protected void Start()
    {
        ghostAnimator = propObject.GetComponent<Animator>();
    }

    // Use this for initialization
    protected void OnTriggerEnter()
    {
        propObject.SetActive(true);
        ghostAnimator.SetBool(parameterName, true);
    }
}
