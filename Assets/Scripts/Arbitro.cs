using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arbitro : MonoBehaviour {

	public GameObject time1;
	public GameObject time2;
	GameObject timeDaVez;

	// Use this for initialization
	void Start () {

		SortearTimeInicial ();
		FocarCamera (timeDaVez);
	}
	
	// Update is called once per frame
	void Update () {

	}

	// Sorteia qual dos times inicia a partida
	//
	void SortearTimeInicial () {
		/* Random.value sorteia um valor entre 0.0 e 1.0.
		 * Se o valor sorteado estiver na primeira metade do intervalo
		 * o time1 começa o jogo, caso contrário, o time2.
		 */
		if (Random.value <= 0.5f) {
			timeDaVez = time1;
		} else {
			timeDaVez = time1;
		}
	}

	// Atribui à câmera a mesma posição do objeto escolhido
	//
	void FocarCamera (GameObject objeto) {
		
		Camera.main.transform.position = new Vector3 (objeto.transform.position.x, objeto.transform.position.y, -10);
	}
}
