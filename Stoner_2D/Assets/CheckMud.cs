using UnityEngine;
using System.Collections;

public class CheckMud : MonoBehaviour 
{
  public float reversePush;
    void OnTriggerEnter2D(Collider2D other)
    {
      if((other.gameObject.tag == "Player") && PlayerStateListener.m_ePlayerState == EPLayerState.ERock)
      {        
        other.rigidbody2D.AddForce(new Vector2(reversePush * -2, 0f));
      }
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
