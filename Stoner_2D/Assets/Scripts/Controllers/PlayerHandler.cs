using UnityEngine;
using System.Collections;

public class PlayerHandler : MonoBehaviour {

	public EPLayerState m_eCharacterState;


	private GameObject m_ptrPlayer;
	private Animator m_IPlayerAnimator;



	void Start () 
	{
		EventHandler.AddListener (EEventID.EVENT_PLAYER_REDUCE_HEALTH, OnTakeDamage);
		m_ptrPlayer = GameObject.Find ("Player");
		m_eCharacterState = EPLayerState.ERock;
		m_IPlayerAnimator = m_ptrPlayer.GetComponent<Animator> ();


	}
	
	// Update is called once per frame
	void Update () 
	{
		switch (m_eCharacterState) 
		{
			case EPLayerState.ERock:
			{
				
			}
			break;
			case EPLayerState.EMud:
			{
				
			}
			break;
		}
	}

	public void OnTakeDamage(System.Object Damage)
	{
		Debug.Log ("PlayerHandler::OnTakeDamage called with data : " + (int)Damage);

	}
}
