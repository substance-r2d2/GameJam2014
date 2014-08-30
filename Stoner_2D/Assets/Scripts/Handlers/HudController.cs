using UnityEngine;
using System.Collections;

public class HudController : MonoBehaviour {

	public GameObject[] RockHealthArray;
	public GameObject[] MudHealthArray;
	public float TimerLevelDelay;

	private GameObject m_ptrRockHealthBar;
	private GameObject m_ptrMudHealthBar;
	private GameObject m_ptrTimer;

	private float m_fRockHealth;
	private float m_fMudHealth;
	private float m_fTime;
	private float m_fMaxTime;
	private bool m_bTimerRunning;

	// Use this for initialization
	void Start () {

		m_fRockHealth = 2;
		m_fMudHealth = 2;
		m_ptrRockHealthBar = this.transform.FindChild ("Rock_Health_Meter").gameObject;
		m_ptrMudHealthBar = this.transform.FindChild  ("Mud_Health_Meter").gameObject;
		m_ptrTimer = this.transform.FindChild ("Timer").gameObject;
		EventHandler.AddListener (EEventID.EVENT_HUD_HEALTH_CHANGE, OnHealthChange);
		EventHandler.AddListener (EEventID.EVENT_PLAYER_CHANGE_STATE, OnPlayerStateChange);
		EventHandler.AddListener (EEventID.EVENT_ENABLE_TIMER, OnEnableTimer);
		this.RefereshMeters ();
		OnPlayerStateChange (EPLayerState.ERock);

	}
	
	// Update is called once per frame
	void Update () {
	
		if(m_bTimerRunning)
		{
			m_fTime += Time.deltaTime;
			m_ptrTimer.guiText.text = ConvertTimeToText(m_fMaxTime - m_fTime);
			if(m_fTime >= m_fMaxTime)
				m_bTimerRunning = false;
		}
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

	public void OnPlayerStateChange(System.Object data)
	{

		EPLayerState meter = (EPLayerState)data;

		if (meter == EPLayerState.ERock)
		{
			m_ptrRockHealthBar.animation.Play("rockBar_expand");
			m_ptrMudHealthBar.animation.Play("healtBar_shrink");
		}
		if (meter == EPLayerState.EMud) 
		{
			m_ptrRockHealthBar.animation.Play("rockBar_shrink");
			m_ptrMudHealthBar.animation.Play("healtBar_expand");
		}
	}

	public void OnEnableTimer(System.Object data)
	{
		m_fTime = Time.time;
		m_fMaxTime = m_fTime + TimerLevelDelay;
		m_ptrTimer.guiText.enabled = true;
		m_bTimerRunning = true;
	}

	private  string ConvertTimeToText(float TimeInSeconds)
	{
		int min = 0;
		int seconds = 0;
		string FormattedTime = "";
		
		
		if(TimeInSeconds > 60)
		{
			min = (Mathf.CeilToInt(TimeInSeconds)/60);
			if(min < 10)
				FormattedTime = "0";
			FormattedTime += min.ToString();
			seconds = Mathf.CeilToInt(TimeInSeconds) - ( 60 * min);
			FormattedTime += ":";
			if(seconds < 10)
				FormattedTime += "0";
			FormattedTime += seconds.ToString();
			return FormattedTime;
		}
		else
		{
			FormattedTime = "00:";
			FormattedTime += Mathf.CeilToInt(TimeInSeconds).ToString();
			return (FormattedTime);
		}
		
	}
}
