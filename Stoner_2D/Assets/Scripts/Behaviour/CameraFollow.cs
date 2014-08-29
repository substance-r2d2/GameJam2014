using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform CameraTransform;
	public Vector2 offset;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = CameraTransform.position;
		this.transform.position = new Vector3(transform.position.x + offset.x,transform.position.y + offset.y, -10f);

	}
}
