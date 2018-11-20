using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellProjectile : MonoBehaviour {

  public float speed;
  public float lifeSpan;
  public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb.velocity = transform.right * speed;
    Destroy(gameObject, lifeSpan);
	}

  private void OnTriggerEnter2D(Collider2D otherCol)
  {
    if (otherCol.gameObject.CompareTag("Boundary"))
    {
      Destroy(gameObject);
    }
  }
}
