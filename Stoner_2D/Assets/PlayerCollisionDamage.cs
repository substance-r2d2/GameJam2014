using UnityEngine;
using System.Collections;

public class PlayerCollisionDamage : MonoBehaviour
{
    
    void OnCollisionEnter2D(Collision2D other)
    {
      if((other.gameObject.tag == "Player"))
      {
        EventHandler.TriggerEvent(EEventID.EVENT_PLAYER_REDUCE_HEALTH, 1f);
      }
    }
}
