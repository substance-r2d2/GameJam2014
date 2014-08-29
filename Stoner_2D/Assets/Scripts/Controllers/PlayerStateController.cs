using UnityEngine;
using System.Collections;

public class PlayerStateController : MonoBehaviour
{

  public enum playerStates
  {
    rock_move,
    mud_move,
    mud_idle,
    mud_left,
    mud_right,
    mud_shoot,
    rock_idle,
    rock_left,
    rock_right,
    rock_roll,
    rock_jump,
  };
  public delegate void playerStateHandler(PlayerStateController.playerStates newState);
  public static event playerStateHandler onStateChange;
  public GameObject groundCheck;
  bool grounded = true;
  float groundRad = 0.5f;
  Animator anim;


  void Awake()
  {
    anim = GetComponent<Animator>();
  }

  void Update()
  {
    float horizontal = Input.GetAxis("Horizontal");
    if (horizontal != 0.0f)
    {
      switch (PlayerStateListener.m_ePlayerState)
      {
        case EPLayerState.ERock:
          if (onStateChange != null)
            onStateChange(playerStates.rock_move);
          break;

        case EPLayerState.EMud:
          if (onStateChange != null)
            onStateChange(playerStates.mud_move);
          break;
      }
    }
    else
    {
      switch (PlayerStateListener.m_ePlayerState)
      {
        case EPLayerState.ERock:
          if (onStateChange != null)
            onStateChange(PlayerStateController.playerStates.rock_idle);
          break;

        case EPLayerState.EMud:
          if (onStateChange != null)
            onStateChange(PlayerStateController.playerStates.mud_idle);
          break;
      }
    }

    //float jump = Input.GetKeyDown(KeyCode.Joystick1Button0);
    if ((Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Space)) && grounded)
    {
      grounded = false;
      if (onStateChange != null)
        onStateChange(PlayerStateController.playerStates.rock_jump);
    }
    if (Input.GetKeyDown(KeyCode.Joystick1Button2) && grounded)
    {
      if (onStateChange != null)
        onStateChange(PlayerStateController.playerStates.rock_roll);
    }

    if (Input.GetKeyDown(KeyCode.Joystick1Button4) || Input.GetKeyDown(KeyCode.LeftAlt))
    {
      switch (PlayerStateListener.m_ePlayerState)
      {
        case EPLayerState.ERock:
			{
	          if (onStateChange != null)
	            EventHandler.TriggerEvent(EEventID.EVENT_PLAYER_CHANGE_STATE, EPLayerState.EMud);

			}
          break;
      }
    }
    if (Input.GetKeyDown(KeyCode.Joystick1Button5) || Input.GetKeyDown(KeyCode.RightAlt))
    {
      switch (PlayerStateListener.m_ePlayerState)
      {
        case EPLayerState.EMud:
          if (onStateChange != null)
            EventHandler.TriggerEvent(EEventID.EVENT_PLAYER_CHANGE_STATE, EPLayerState.ERock);

          break;
      }
    }
  }


  void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.tag == "Platform")
    {
      foreach (var contact in other.contacts)
      {
        var normal = contact.normal;
        if (normal.x != 0 || normal.y < 0)
          return;
      }
      grounded = true;
    }
  }
}

