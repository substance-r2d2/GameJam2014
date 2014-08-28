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
