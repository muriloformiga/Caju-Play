using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour {

	//Variaveis
	string nomePersonagem, nomeAtqEspecial, classePersonagem;
	int danoAtqConvencional, vidaPersonagem; 

	//Metodos GET e SET
	public string nomePersonagem{
		get { return nomePersonagem; }
		set { nomePersonagem = value; }
	}

	public string nomeAtqEspecial{
		get { return nomeAtqEspecial; }
		set { nomeAtqEspecial = value; }
	}

	public string classePersonagem {
		get { return classePersonagem; }
		set { classePersonagem = value; }
	}
		
	public int danoAtqConvencional{
		get { return danoAtqConvencional; }
		set { classePersonagem = value; }
	}

	public int vidaPersonagem{
		get { return vidaPersonagem; }
		set{ vidaPersonagem = value; } 
	}

}
