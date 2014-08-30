using UnityEngine;
using System.Collections;

public class BouncyMaterial : MonoBehaviour {

  public float xCompForce = 0f;
  public float yCompForce = 600f;

  void OnCollisionEnter2D(Collision2D other)
  {
    if(other.gameObject.tag == "Player")
    {
      other.gameObject.rigidbody2D.velocity = new Vector2(0, 0);
      other.gameObject.rigidbody2D.AddForce(new Vector2(xCompForce, yCompForce));
    }
  }
}
