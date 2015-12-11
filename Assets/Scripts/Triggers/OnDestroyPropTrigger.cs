using UnityEngine;
using System.Collections;

public abstract class OnDestroyPropTrigger : MonoBehaviour {

	[SerializeField]
	protected GameObject triggersOwner;
	[SerializeField]
	protected GameObject prop;

	bool triggered = false;
	
	// Update is called once per frame
	protected void Update()
	{
		if (triggersOwner == null)
			if (!triggered)
			{
				TriggerAction();
				triggered = true;
			}
	}

	abstract public void TriggerAction();
}
