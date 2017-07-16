using UnityEngine;
using System.Collections;

public  class Disparo : MonoBehaviour {
    
	public GameObject projetil;
	public GameObject indicador;

	Vector2 posicaoMouse;
	GameObject indicadorTemporario;
	bool indicadorInstanciado = false;

	// Use this for initialization
	void Start () {


	}

	// Update is called once per frame
	void FixedUpdate () {
		posicaoMouse = Camera.main.ScreenPointToRay(Input.mousePosition).GetPoint(0);
		if (Input.GetMouseButton (0)) {
			if (indicadorInstanciado == false) {
				indicadorInstanciado = true;
				indicadorTemporario = Instantiate (indicador, posicaoMouse, transform.rotation) as GameObject;
				//indicadorTemporario.GetComponent<Rigidbody2D> ().isKinematic = true;
			}
			indicadorTemporario.transform.position = posicaoMouse;
		}

		if (Input.GetMouseButtonUp (0)) {
			Destroy(indicadorTemporario);
			indicadorInstanciado = false;
			Atirar ();
		}
	}

	void Atirar () {

		GameObject projetilTemporario = Instantiate (projetil) as GameObject;
		Vector2 direcaoForca = this.transform.position - indicadorTemporario.transform.position;
		projetilTemporario.GetComponent<Rigidbody2D>().AddForce(direcaoForca * 5/*forcaLancamento*/, ForceMode2D.Impulse);
	}
}
