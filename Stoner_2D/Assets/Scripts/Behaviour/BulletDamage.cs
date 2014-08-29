using UnityEngine;
using System.Collections;

public class BulletDamage : MonoBehaviour {

  public int HealthDamage = 5;

  void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.tag == "Player")
    {
      switch (PlayerStateListener.m_ePlayerState)
      {
        case EPLayerState.ERock:
		{
          Debug.Log("Damage of 5");
          Destroy(gameObject);
		}
        break;

		case EPLayerState.EMud:
          foreach (var contact in other.contacts)
          {
            var normal = contact.normal;
            rigidbody2D.velocity = new Vector2(2, 3);
            Invoke("destroyBullet", 1.5f);
          }
          break;
      }
    }
  }

  void destroyBullet()
  {
    Destroy(gameObject);
  }
}
