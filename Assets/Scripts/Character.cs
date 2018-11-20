using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {

  // Movement speed of character
  // SerializeField lets the class be public but show up in editor.
  [SerializeField]
  protected float speed;
  [SerializeField]
  protected Rigidbody2D rb;

  // State controller/
  protected enum CharacterState {Ready, Dashing, Action};
  protected CharacterState currentState;

  // Direction of character.
  // 'Protected' means everything that inhertits from this script can access it.
  protected Vector2 direction;

  // Dashing variables.
  public float dashSpeed;
  protected float dashTime;
  public float startDashTime;
    // Use dashDirection so user can't change dash direction mid-dash.
  private Vector2 dashDirection;

  // Spell variables
  public GameObject projectileLaunchPoint;
  public GameObject spellOneProjectile;

  // ************************************** 

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
    currentState = CharacterState.Ready;

    // Dash time
    dashTime = startDashTime;
	}
	
	// Update is called once per frame
  // Made this 'virtual' so the script that inherits from this class can override this Update() method.
	protected virtual void Update () {
    // For some reason the Start() fails to grab rigidbody component at times.
    if (rb == null)
    {
      rb = GetComponent<Rigidbody2D>();
    }

    // Let's player control movement when in ready state;
    if (currentState == CharacterState.Ready)
    {
      Move();
    }

    // Dashing loop
    if (currentState == CharacterState.Dashing)
    {
      Dash();
    }
	}

  // Moves the player according to input from GetInput().
  public void Move()
  {
    rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
  }

  public void StartDash()
  {
    if (currentState == CharacterState.Ready)
    {
      currentState = CharacterState.Dashing;
      dashDirection = direction;
    }
  }

  // Dashes the character in the direction the character is moving.
  // * Will probably need to rewrite this dash function to take into account the character's rotation instead of Vector2.direction.
  public void Dash()
  {
    if (dashTime <= 0)
    {
      currentState = CharacterState.Ready;
      dashTime = startDashTime;
      rb.velocity = Vector2.zero;
    }
    else
    {
      dashTime -= Time.deltaTime;
      rb.velocity = dashDirection * dashSpeed;
    }
  }

  // Spell one cast
  // ** For spells, maybe instead of hardcoding spells here. Have a separate script of all spells and use variables to store which spells the characters have and call those variables here.
  public void SpellOne()
  {
    if (currentState == CharacterState.Ready)
    {
      // Need to change rotation based on mouse rotation instead of character rotation.
      currentState = CharacterState.Action;
      GameObject spell = Instantiate(spellOneProjectile, projectileLaunchPoint.transform.position, projectileLaunchPoint.transform.rotation);

      // Need way to set currentState back to ready after casting animation.
      currentState = CharacterState.Ready;
    }
  }
}
