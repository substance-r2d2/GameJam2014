using UnityEngine;
using System.Collections;

public class PlayOnCoinPickUp : MonoBehaviour {


  void OnTriggerEnter2D(Collider2D other)
  {
    if(other.gameObject.tag == "Player")
    {
      audio.Play();
      Destroy(this.gameObject, 0.18f);
    }
  }
}
