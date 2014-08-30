using UnityEngine;
using System.Collections;

public class changedir : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

  void OnTriggerEnter2D(Collider2D other)
    {
      EventHandler.TriggerEvent(EEventID.EVENT_CONTROLLER_STATE_CHANGE, EControllerState.EPlatformer);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
