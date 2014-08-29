using UnityEngine;
using System.Collections;

public class parallax : MonoBehaviour 
{
    public float speed = 2f;
	public float xfactor = 0.0f;
	    
	// Update is called once per frame
	void Update () 
    {
        
        renderer.material.mainTextureOffset += new Vector2((Time.deltaTime * speed) * xfactor, 0f);

	}
}
