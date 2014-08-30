using UnityEngine;
using System.Collections;

public class OnBlast : MonoBehaviour {

  void OnTriggerEnter2D(Collider2D other)
  {
    if(other.gameObject.tag == "Player")
    {
      EventHandler.TriggerEvent(EEventID.EVENT_PLAYER_REDUCE_HEALTH, 1f);
      audio.Play();
      Destroy(this.gameObject, 0.60f);
    }
  }
}
