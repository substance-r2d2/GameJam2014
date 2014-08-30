using UnityEngine;
using System.Collections;

public class ChangeToFreeRunner : MonoBehaviour {

  void OnTriggerExit2D(Collider2D other)
  {
    if(other.gameObject.tag == "Player")
    {
      audio.Play();
      EventHandler.TriggerEvent(EEventID.EVENT_CONTROLLER_STATE_CHANGE, EControllerState.EFreeRunnerRight);
    }
  }
}
