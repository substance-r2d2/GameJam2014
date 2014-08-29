using UnityEngine;
using System.Collections;

public class PlayerStateListener : MonoBehaviour
{
		public PlayerStateController.playerStates currentState = PlayerStateController.playerStates.rock_idle;
		public static PlayerStateController.playerStates previousState = PlayerStateController.playerStates.rock_idle;
		public float playerWalkSpeed = 5f;
		public float maxSpeed = 5;
		public float moveForce = 365f;			// Amount of force added to move the player left and right.
		public float maxJumpForce = 100f;
		private Animator anim;
		private float time = 0;
		private parallax[] environments;

		[HideInInspector]
		public bool
				facingRight = true;			// For determining which way the player is currently facing.

		public static EPLayerState m_ePlayerState;
		public static string StateTag = "Rock";

		void Awake ()
		{
				anim = GetComponent<Animator> ();
				EventHandler.AddListener (EEventID.EVENT_PLAYER_CHANGE_STATE, OnPlayerChange);
				environments = GameObject.Find("Parallexed_Bg").GetComponentsInChildren<parallax> ();
		}

		void OnEnable ()
		{
				PlayerStateController.onStateChange += OnStateChange;
		}

		void OnDisable ()
		{
				PlayerStateController.onStateChange -= OnStateChange;
		}

		void OnStateCycle ()
		{
				switch (currentState) {
				case PlayerStateController.playerStates.rock_idle:
						break;

				case PlayerStateController.playerStates.rock_roll:
						break;

				case PlayerStateController.playerStates.rock_jump:
						break;

				case PlayerStateController.playerStates.mud_idle:
						{
							
						}
						break;

				case PlayerStateController.playerStates.mud_shoot:
						break;

				case PlayerStateController.playerStates.rock_move:
				case PlayerStateController.playerStates.mud_move:
				{
					MovePlayer ();
				}
				break;

			}
		}

		void OnStateChange (PlayerStateController.playerStates newState)
		{
				if (currentState == newState)
						return;

				if (!checkForValidStatePair (newState))
						return;

				switch (newState) {
				case PlayerStateController.playerStates.rock_idle:
						m_ePlayerState = EPLayerState.ERock;
						break;

				case PlayerStateController.playerStates.rock_left:
						m_ePlayerState = EPLayerState.ERock;
						break;

				case PlayerStateController.playerStates.rock_right:
						m_ePlayerState = EPLayerState.ERock;
						break;

				case PlayerStateController.playerStates.rock_roll:
						rigidbody2D.AddForce (new Vector2 (500, 0));
						break;

				case PlayerStateController.playerStates.rock_jump:
						m_ePlayerState = EPLayerState.ERock;
						rigidbody2D.AddForce (new Vector2 (0, 200));
						break;

				case PlayerStateController.playerStates.mud_idle:
						m_ePlayerState = EPLayerState.EMud;
						break;

				case PlayerStateController.playerStates.mud_left:
						m_ePlayerState = EPLayerState.EMud;
						break;

				case PlayerStateController.playerStates.mud_right:
						m_ePlayerState = EPLayerState.EMud;
						break;

				case PlayerStateController.playerStates.mud_shoot:
						m_ePlayerState = EPLayerState.EMud;
						break;
				}
				previousState = currentState;
				currentState = newState;
		}

		bool checkForValidStatePair (PlayerStateController.playerStates newState)
		{
				bool returnVal = true;

				switch (currentState) {
				case PlayerStateController.playerStates.rock_idle:
						break;

				case PlayerStateController.playerStates.rock_roll:
						break;

				case PlayerStateController.playerStates.rock_jump:
						break;

				case PlayerStateController.playerStates.mud_idle:
						break;

				case PlayerStateController.playerStates.mud_shoot:
						break;
				}
				if (returnVal == false)
						Debug.Log ("Cannot change from CurrentState: " + currentState + " to NewState: " + newState);
				return returnVal;
		}

		void FixedUpdate ()
		{
				OnStateCycle ();
				SetBgScrollRate ();
		}

		void Flip ()
		{
				// Switch the way the player is labelled as facing.
				facingRight = !facingRight;
		
				// Multiply the player's x local scale by -1.
				Vector3 theScale = transform.localScale;
				theScale.x *= -1;
				transform.localScale = theScale;
		}

		void MovePlayer ()
		{
				float h = Input.GetAxis ("Horizontal");

				anim.SetFloat ("Speed", Mathf.Abs (h));		

				// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
				if (h * rigidbody2D.velocity.x < maxSpeed)
			// ... add a force to the player.
						rigidbody2D.AddForce (Vector2.right * h * moveForce);
		
				// If the player's horizontal velocity is greater than the maxSpeed...
				if (Mathf.Abs (rigidbody2D.velocity.x) > maxSpeed)
			// ... set the player's velocity to the maxSpeed in the x axis.
						rigidbody2D.velocity = new Vector2 (Mathf.Sign (rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);
		
				// If the input is moving the player right and the player is facing left...
				if (h > 0 && !facingRight)
			// ... flip the player.
						Flip ();
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (h < 0 && facingRight)
				// ... flip the player.
							Flip ();
			
		}

		public void OnPlayerChange(System.Object newState)
		{
			if ((EPLayerState)newState == EPLayerState.ERock && PlayerStateListener.m_ePlayerState != EPLayerState.ERock) {
						m_ePlayerState = (EPLayerState)newState;
						anim.SetBool("is_rock", false);
						Debug.Log("changing from rock to mud");
				}
			if ((EPLayerState)newState == EPLayerState.EMud && PlayerStateListener.m_ePlayerState != EPLayerState.EMud) {
						m_ePlayerState = (EPLayerState)newState;
							anim.SetBool("is_rock", true);
						Debug.Log("Changing from mud to rock");
				}
		}

		public void SetBgScrollRate()
		{
			foreach (parallax pvar in environments)
				pvar.xfactor = rigidbody2D.velocity.x;
		}
}
