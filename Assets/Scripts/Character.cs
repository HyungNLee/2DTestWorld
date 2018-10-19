using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {

  // Movement speed of character
  // SerializeField lets the class be public but show up in editor.
  [SerializeField]
  protected float speed;

  // Direction of character.
  // 'Protected' means everything that inhertits from this script can access it.
  protected Vector2 direction;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
  // Made this 'virtual' so the script that inherits from this class can override this Update() method.
	protected virtual void Update () {
		Move();
	}

  // Moves the player according to input from GetInput().
  public void Move()
  {
    transform.Translate(direction * speed * Time.deltaTime);
  }
}
