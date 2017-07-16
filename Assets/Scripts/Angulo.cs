using UnityEngine;
using System.Collections;

public class Angulo : MonoBehaviour {
    
    public Sprite angular0;
	public Sprite angular15;
	public Sprite angular30;
	public Sprite angular45;
	public Sprite angular60;
	public Sprite angular75;

	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		
		spriteRenderer = this.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		AjustarAngulo ();
    }
    

    void OnMouseOver() {
		if(Input.GetMouseButton(0)) {
			spriteRenderer.GetComponent<Animator> ().enabled = false;
		}
	}

	void AjustarAngulo () {

		//Vector2 posicaoToque = Input.mousePosition;

		//get the vector representing the mouse's position relative to the point...
		Vector2 v = Input.mousePosition - this.transform.position;

		//use atan2 to get the angle; Atan2 returns radians
		float angleRadians = Mathf.Atan2(v.y, v.x);

		//convert to degrees
		float angleDegrees = angleRadians * Mathf.Rad2Deg;

		//if (angleDegrees<0) 
		//	angleDegrees+=360;

		//print (angleDegrees);

		if (angleDegrees > 0 && angleDegrees <= 15) {
			spriteRenderer.sprite = angular0;

		} else if (angleDegrees > 15 && angleDegrees <= 30) {
			spriteRenderer.sprite = angular15;
			//this.transform.GetChild (0).rotation = Quaternion.AngleAxis (30, Vector3.back);
			//particulas.transform.Rotate (Vector3.back * 45);
		} else if (angleDegrees > 30 && angleDegrees <= 45) {
			spriteRenderer.sprite = angular30;
			//this.transform.GetChild (0).rotation = Quaternion.AngleAxis (0, Vector3.back);
		} else if (angleDegrees > 45 && angleDegrees <= 60) {
			spriteRenderer.sprite = angular45;
			//this.transform.GetChild (0).rotation = Quaternion.AngleAxis (8, Vector3.back);
		} else if (angleDegrees > 60 && angleDegrees <= 75) {
			spriteRenderer.sprite = angular60;
			//this.transform.GetChild (0).rotation = Quaternion.AngleAxis (16, Vector3.back);
		} else if (angleDegrees > 75 && angleDegrees <= 90) {
			spriteRenderer.sprite = angular75;
			//this.transform.GetChild (0).rotation = Quaternion.AngleAxis (-75, Vector3.back);
		}
	}
}
