using UnityEngine;
using System.Collections;

public class GreeseKill : MonoBehaviour 
{    
    //public GUIText gameOverText;
    bool isPlayerInWater;
    float damageTime;

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Player") 
        {
            if((PlayerStateListener.m_ePlayerState == EPLayerState.EMud)) 
            {   
                EventHandler.TriggerEvent(EEventID.EVENT_PLAYER_REDUCE_HEALTH, (float)1.0f);

                isPlayerInWater = true;
            }                            
        }
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        isPlayerInWater = false;
        

        
    }

   
	// Use this for initialization
	void Start () 
    {
        
	}
	
	// Update is called once per frame
    void Update()
    {
        if (isPlayerInWater)
        {
            damageTime += Time.deltaTime;
            if (damageTime > 2)
            {
                EventHandler.TriggerEvent(EEventID.EVENT_PLAYER_REDUCE_HEALTH, 1f);
                damageTime = 0;
            }
        }
    }
}
