using UnityEngine;
using System.Collections;

public class mudbullet : MonoBehaviour {

	// Use this for initialization
	public float horizontalSpeed = 1f;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate (horizontalSpeed * Time.deltaTime, 0f , 0f);
	}
}
