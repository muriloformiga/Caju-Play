using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour {

	// Use this for initialization
	void Start () {

		Physics2D.IgnoreCollision (this.GetComponent<Collider2D>(),
			this.transform.parent.gameObject.GetComponent<Collider2D>());
	}

}
