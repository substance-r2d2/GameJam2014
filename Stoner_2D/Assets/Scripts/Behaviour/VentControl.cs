using UnityEngine;
using System.Collections;

public class VentControl : MonoBehaviour 
{
    
    public float airSpeed = 2f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" && PlayerStateListener.m_ePlayerState == EPLayerState.EMud)
        {
            other.rigidbody2D.AddForce(new Vector2(0f, airSpeed * 2f));
        }
    }
    
}
