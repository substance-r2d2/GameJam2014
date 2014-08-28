using UnityEngine;
using System.Collections;

public class BulletDamage : MonoBehaviour {

  public float HealthDamage = 5f;

  void OnCollisionEnter2D(Collision2D other)
  {
    if(other.gameObject.tag == "Player")
    {
      Destroy(gameObject);
      EventHandler.TriggerEvent(EEventID.EVENT_PLAYER_REDUCE_HEALTH, HealthDamage);
    }
  }

}
