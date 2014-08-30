using UnityEngine;
using System.Collections;

public class DynamiteHazard : MonoBehaviour 
{
    private float timer;
    void OnTriggerEnter2D(Collider2D other)
    {
        if((other.gameObject.tag == "Player") && PlayerStateListener.m_ePlayerState == EPLayerState.ERock)
        {
            EventHandler.TriggerEvent(EEventID.EVENT_PLAYER_REDUCE_HEALTH, 1f);
            
        }
    }	
}
