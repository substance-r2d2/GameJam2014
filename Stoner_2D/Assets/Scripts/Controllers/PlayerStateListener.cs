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
		public float freeRunnerSpeed = 1;
        public int PickUp;
			public GameObject bulletPrefab;
        
		private Animator anim;
		private float time = 0;
		private parallax[] environments;
		private EControllerState m_eControllerState;

		[HideInInspector]
		public bool facingRight = true;			// For determining which way the player is currently facing.

		public static EPLayerState m_ePlayerState;
		public static string StateTag = "Rock";

		void Awake ()
		{
				anim = GetComponent<Animator> ();
				EventHandler.AddListener (EEventID.EVENT_PLAYER_CHANGE_STATE, OnPlayerChange);
				EventHandler.AddListener (EEventID.EVENT_CONTROLLER_STATE_CHANGE, OnControllerStateChange);
				environments = GameObject.Find("Parallexed_Bg").GetComponentsInChildren<parallax>();
				OnControllerStateChange( EControllerState.EPlatformer);
				DeactivateRoll ();
			
		}

		void OnEnable ()
		{
				PlayerStateController.onStateChange += OnStateChange;
				m_ePlayerState = EPLayerState.ERock;
				EventHandler.TriggerEvent (EEventID.EVENT_PLAYER_CHANGE_STATE, EPLayerState.ERock);
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
		
		void OnFreeRunnerCycle()
		{
			MovePlayerRunner ();
		}

		void OnStateChange (PlayerStateController.playerStates newState)
		{
				if (currentState == newState)
						return;

				if (!checkForValidStatePair (newState))
						return;

				switch (newState) {
				case PlayerStateController.playerStates.rock_idle:
//						if(m_eControllerState == EControllerState.EPlatformer)
//							
							//m_ePlayerState = EPLayerState.ERock;
						break;

				case PlayerStateController.playerStates.rock_left:
						//m_ePlayerState = EPLayerState.ERock;
						break;

				case PlayerStateController.playerStates.rock_right:
						//m_ePlayerState = EPLayerState.ERock;
						break;

				case PlayerStateController.playerStates.rock_roll:
						if(transform.localScale.x > 0)
							rigidbody2D.AddForce (new Vector2 (500, 0));
						if(transform.localScale.x < 0)
							rigidbody2D.AddForce (new Vector2 (-500, 0));
						ActivateRoll();
						break;

				case PlayerStateController.playerStates.rock_jump:
						//m_ePlayerState = EPLayerState.ERock;
						rigidbody2D.AddForce (new Vector2 (0, maxJumpForce));
						break;

				case PlayerStateController.playerStates.mud_idle:
//						if(m_eControllerState == EControllerState.EPlatformer)
						//m_ePlayerState = EPLayerState.EMud;
						break;

				case PlayerStateController.playerStates.mud_left:
						//m_ePlayerState = EPLayerState.EMud;
						break;

				case PlayerStateController.playerStates.mud_right:
						//m_ePlayerState = EPLayerState.EMud;
						break;

				case PlayerStateController.playerStates.mud_shoot:
				anim.SetTrigger("is_spitting");
				GameObject.Instantiate(bulletPrefab, transform.position, transform.rotation);
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
			if (m_eControllerState == EControllerState.EPlatformer)
						OnStateCycle ();
				else
						OnFreeRunnerCycle ();
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

		void MovePlayerRunner()
		{
			
			anim.SetFloat ("Speed", freeRunnerSpeed);
			if (freeRunnerSpeed * rigidbody2D.velocity.x < maxSpeed)
				// ... add a force to the player.
				rigidbody2D.AddForce (Vector2.right * freeRunnerSpeed * moveForce);
			
			// If the player's horizontal velocity is greater than the maxSpeed...
			if (Mathf.Abs (rigidbody2D.velocity.x) > maxSpeed)
				// ... set the player's velocity to the maxSpeed in the x axis.
				rigidbody2D.velocity = new Vector2 (Mathf.Sign (rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);
			
			// If the input is moving the player right and the player is facing left...
			if (freeRunnerSpeed > 0 && !facingRight)
				// ... flip the player.
				Flip ();
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (freeRunnerSpeed < 0 && facingRight)
				// ... flip the player.
				Flip ();
		}

		public void OnPlayerChange(System.Object newState)
		{
			Debug.Log ((EPLayerState)newState);
			if (((EPLayerState)newState == EPLayerState.ERock && PlayerStateListener.m_ePlayerState != EPLayerState.ERock) || m_ePlayerState == EPLayerState.ENone) {
						
					anim.SetBool("is_rock", true);
					transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
					gameObject.GetComponent<BoxCollider2D>().enabled = false;
					gameObject.GetComponent<CircleCollider2D>().enabled = true;
					//rigidbody2D.fixedAngle = true;
					Debug.Log("Changing from mud to rock");
					m_ePlayerState = (EPLayerState)newState;			

				}
		else
			if ((EPLayerState)newState == EPLayerState.EMud && PlayerStateListener.m_ePlayerState != EPLayerState.EMud) {
						
					anim.SetBool("is_rock", false);
					gameObject.GetComponent<BoxCollider2D>().enabled = true;
					gameObject.GetComponent<CircleCollider2D>().enabled = false;
					//rigidbody2D.fixedAngle = false;
					Debug.Log("changing from rock to mud");
					m_ePlayerState = (EPLayerState)newState;
				}
		}

		public void OnControllerStateChange(System.Object newState)
		{
			m_eControllerState = (EControllerState)newState;
            if (m_eControllerState == EControllerState.EFreeRunnerRight)
            {
              freeRunnerSpeed = 1f;
              maxSpeed += 2.5f;
            }
            else
              if (m_eControllerState == EControllerState.EFreeRunnerLeft)
              {
                freeRunnerSpeed = -1f;
                maxSpeed += 2.5f;
              }
		}

		public void SetBgScrollRate()
		{
			foreach (parallax pvar in environments)
				pvar.xfactor = rigidbody2D.velocity.x;
		}

		private void ActivateRoll()
		{
			ParticleSystem dustTrail = this.gameObject.GetComponentInChildren<ParticleSystem> ();
			TrailRenderer trail = this.gameObject.GetComponentInChildren<TrailRenderer> ();
			trail.enabled = true;
			dustTrail.enableEmission = true;
			if(transform.localScale.x > 0)
				anim.SetTrigger ("is_rolling");
			
			if(transform.localScale.x < 0)
				anim.SetTrigger ("is_rolling_right");
		}

		private void DeactivateRoll()
		{
			ParticleSystem dustTrail = this.gameObject.GetComponentInChildren<ParticleSystem> ();
			dustTrail.enableEmission = false;
			TrailRenderer trail = this.gameObject.GetComponentInChildren<TrailRenderer> ();
			trail.enabled = false;
		}


}
