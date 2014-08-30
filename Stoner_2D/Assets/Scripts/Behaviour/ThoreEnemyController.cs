using UnityEngine;
using System.Collections;

public class ThoreEnemyController : MonoBehaviour {

	// Use this for initialization
	bool isPlayerInside = false;
	bool isHitting = false;
	int hitCount = 0;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (isPlayerInside )
						hit ();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			isPlayerInside = true;
			hit ();
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		isHitting = false;
		if (other.gameObject.tag == "Player") {
			isPlayerInside = false;
				}
	}

	private void hit()
	{

		isHitting = true;
		Animator anim = gameObject.GetComponent<Animator>();
		anim.SetTrigger("hammer");
	}

	public void OnAnimationOver()
	{
		hitCount++;
		if (hitCount > 3) {
			Debug.Log("Hitting once");
						EventHandler.TriggerEvent (EEventID.EVENT_PLAYER_REDUCE_HEALTH, 1f);
			hitCount = 0;
				}
	}
}
