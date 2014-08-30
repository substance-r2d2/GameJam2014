using UnityEngine;
using System.Collections;

public class JumpPlayer : MonoBehaviour {

  public float maxJumpForce = 300f;

  //Remeber to tag the player as "Player"
  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.tag == "Player")
    {
     
      other.gameObject.rigidbody2D.AddForce(new Vector2(0, maxJumpForce * 2));
    }
  }
}
