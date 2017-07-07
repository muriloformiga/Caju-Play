using UnityEngine;
using System.Collections;

public class Disparo : MonoBehaviour {

	public GameObject indicador;
	public GameObject projetil;

	public float forcaLancamento = 15f;
	public float distanciaMaxima = 3f;

	Vector2 posicaoMouse;
	GameObject instanciaTemporaria;
	bool instanciado = false;

	void Update () {

		if (Input.GetMouseButton (0)) {
			posicaoMouse = Camera.main.ScreenPointToRay (Input.mousePosition).GetPoint(0);
			if (instanciado == false) {
				instanciado = true;
				instanciaTemporaria = Instantiate (indicador, posicaoMouse, transform.rotation) as GameObject;
				instanciaTemporaria.GetComponent<Rigidbody2D> ().isKinematic = true;
			}
			instanciaTemporaria.transform.position = posicaoMouse;
		}

		if (Input.GetMouseButtonUp (0) && instanciado == true) {
			Vector2 direcaoForca = transform.position - instanciaTemporaria.transform.position;
			//instanciaTemporaria.GetComponent<Rigidbody2D> ().isKinematic = false;
			projetil.GetComponent<Rigidbody2D> ().isKinematic = false;
			projetil.GetComponent<Rigidbody2D> ().AddForce (direcaoForca * forcaLancamento, ForceMode2D.Impulse);
			instanciado = false;
			Destroy (instanciaTemporaria);
		}
	}
}
