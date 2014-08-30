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
      switch (PlayerStateListener.m_ePlayerState)
      {
        case EPLayerState.ERock:
          {
            Debug.Log("reduce");
            m_fRockHealth -= (float)damage;
            if (m_fRockHealth <= 0)
              m_fRockHealth = 0;
            Hashtable data = new Hashtable();
            data.Add("meter", EPLayerState.ERock);
            data.Add("value", (float)m_fRockHealth);
            audio.Play();
            EventHandler.TriggerEvent(EEventID.EVENT_HUD_HEALTH_CHANGE, (System.Object)data);
          }
          break;

        case EPLayerState.EMud:
          {
            m_fMudHealth -= (float)damage;
            if (m_fMudHealth <= 0)
              m_fMudHealth = 0;
            Hashtable data = new Hashtable();
            data.Add("meter", EPLayerState.EMud);
            data.Add("value", (float)m_fMudHealth);
            audio.Play();
            EventHandler.TriggerEvent(EEventID.EVENT_HUD_HEALTH_CHANGE, (System.Object)data);
          }
          break;
      }
	}

	public void OnHealDamage(System.Object heal)
	{

	}
}
