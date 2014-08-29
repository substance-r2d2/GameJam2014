using UnityEngine;
using System.Collections;

public class HudController : MonoBehaviour {

	public GameObject[] RockHealthArray;
	public GameObject[] MudHealthArray;


	private GameObject m_ptrRockHealthBar;
	private GameObject m_ptrMudHealthBar;

	private float m_fRockHealth;
	private float m_fMudHealth;

	// Use this for initialization
	void Start () {

		m_fRockHealth = 2;
		m_fMudHealth = 2;
		m_ptrRockHealthBar = this.transform.FindChild ("Rock_Health_Meter").gameObject;
		m_ptrMudHealthBar = this.transform.FindChild  ("Mud_Health_Meter").gameObject;
		EventHandler.AddListener (EEventID.EVENT_HUD_HEALTH_CHANGE, OnHealthChange);
		this.RefereshMeters ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnHealthChange(System.Object data)
	{
		Hashtable healthData = (Hashtable)data;
		if((EPLayerState)healthData["meter"] == EPLayerState.ERock)
		{
			m_fRockHealth = (float)healthData["value"];
		}
		else
			if((EPLayerState)healthData["meter"] == EPLayerState.EMud)
		{
			m_fMudHealth = (float)healthData["value"];
		}
		RefereshMeters ();
	}

	void RefereshMeters()
	{
		foreach (GameObject obj in RockHealthArray)
						obj.GetComponent<SpriteRenderer> ().enabled = false;
		foreach (GameObject obj in MudHealthArray)
					obj.GetComponent<SpriteRenderer> ().enabled = false;


		for (int i = 0; i < m_fRockHealth; i++)
						RockHealthArray [i].GetComponent<SpriteRenderer> ().enabled = true;
		for (int i = 0; i < m_fMudHealth; i++)
						MudHealthArray [i].GetComponent<SpriteRenderer> ().enabled = true;
	}
}
