using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform CameraTransform;
	public float maxStayOnYLimit;
	public Vector2 offset;

	private float t = 0.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 temp = new Vector3 ();
		temp.x = CameraTransform.position.x;
		temp.y = CameraTransform.position.y;
//		if (Mathf.Abs (CameraTransform.position.y - this.transform.position.y) > maxStayOnYLimit) {
//						temp.y = Mathf.Lerp (temp.y, CameraTransform.position.y + offset.y, t);
//						t += 0.016f;
//				} else
//						t = 0.0f;
		this.transform.position = temp;
		this.transform.position = new Vector3(transform.position.x + offset.x,transform.position.y + offset.y, -10f);

	}
}
