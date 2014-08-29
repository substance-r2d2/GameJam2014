using UnityEngine;
using System.Collections;

public class PlayerHealthHandler : MonoBehaviour {

	public  float  maxHealth;
	private float m_fRockHealth;
	private float m_fMudHealth;

	// Use this for initialization
	void Start () 
	{
		m_fRockHealth = 2;
		m_fMudHealth = 2;
		EventHandler.AddListener (EEventID.EVENT_PLAYER_REDUCE_HEALTH, OnTakeDamage);
		EventHandler.AddListener (EEventID.EVENT_PLAYER_HEAL_HEALTH, OnHealDamage);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTakeDamage(System.Object damage)
	{

	}

	public void OnHealDamage(System.Object heal)
	{

	}
}
