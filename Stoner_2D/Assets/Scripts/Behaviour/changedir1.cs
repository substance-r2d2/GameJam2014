using UnityEngine;
using System.Collections;

public class changedir1 : MonoBehaviour
{

  // Use this for initialization
  void Start()
  {

  }

  void OnTriggerEnter2D(Collider2D other)
  {
    EventHandler.TriggerEvent(EEventID.EVENT_CONTROLLER_STATE_CHANGE, EControllerState.EFreeRunnerLeft);
  }

  // Update is called once per frame
  void Update()
  {

  }
}
