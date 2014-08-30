using UnityEngine;
using System.Collections;

public class HeatEmitterControl : MonoBehaviour 
{
    

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" && PlayerStateListener.m_ePlayerState == EPLayerState.EMud)
        {
            EventHandler.TriggerEvent(EEventID.EVENT_PLAYER_REDUCE_HEALTH, 1f);
        }
    }

	
}
