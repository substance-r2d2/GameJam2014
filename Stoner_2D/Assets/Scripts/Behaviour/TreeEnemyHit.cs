using UnityEngine;
using System.Collections;

public class TreeEnemyHit : MonoBehaviour {

  GameObject bullet;
  public float BulletSpawnTime = 2f;

  public float BulletXComponent = 150f;
  public float BulletYComponent = 100f;

  void Start()
  {
    bullet = GameObject.Find("Bullet");
    bullet.SetActive(false);
  }

  void OnCollisionEnter2D(Collision2D other)
  {
    if(other.gameObject.tag == "Player")
    {
      /*switch(PlayerStateListener.m_ePlayerState)
      {
        case EPLayerState.ERock:
          if (PlayerStateListener.previousState == PlayerStateController.playerStates.rock_roll)
          {
            Destroy(gameObject);
          }
          else
            Debug.Log("damage" +" "+ PlayerStateListener.previousState);
          break;

        case EPLayerState.EMud:
          Debug.Log("Damage 5 pts");
          break;
      }*/
    }
  }

  void Update()
  {
    BulletSpawnTime += Time.deltaTime;
    if(BulletSpawnTime > 2f)
    {
      MakeBullet();
      BulletSpawnTime = 0;
    }
  }

  void MakeBullet()
  {
    var obj = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
    obj.SetActive(true);
    obj.rigidbody2D.AddForce(new Vector2(BulletXComponent, BulletYComponent));
  }
}
