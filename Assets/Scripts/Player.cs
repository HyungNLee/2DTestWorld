using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

	// Use this for initialization
	void Start () 
  {
		speed = 5f;
	}
	
	// Update is called once per frame
  // Wrote 'override' so this class can override the Update() in the character script.
	protected override void Update () 
  {
		GetInput();

    // base means to access the script that this player script inherits from. In this case, the character script.
    base.Update();
	}

  private void GetInput()
  {
    direction = Vector2.zero;
    
    // Directional inputs.
    if (Input.GetKey(KeyCode.W)) {
      direction += Vector2.up;
    }
    if (Input.GetKey(KeyCode.A)) {
      direction += Vector2.left;
    }
    if (Input.GetKey(KeyCode.S)) {
      direction += Vector2.down;
    }
    if (Input.GetKey(KeyCode.D)) {
      direction += Vector2.right;
    }
    direction.Normalize();

    // Dash input.
    if (Input.GetKeyDown(KeyCode.Space))
    {
      base.StartDash();
    }
  }
}
