using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody2D))]
public class Disparo2 : MonoBehaviour
{
    public bool olhandoParaEsquerda = true; //lado que o player ta olhando
    // PosicaoDaFlecha ira receber um gameobject que indicara o local de onde a flecha sera instanciada
    [SerializeField]
    public GameObject PosicaoDaFlecha;
    //FlechaArq ira receber o gameobject da flecha
    [SerializeField]
    public GameObject FlechaArq;
    public GameObject indicador;
    public float forcaLancamento = 6f;
    public float distanciaMaxima = 3f;
    Vector2 posicaoMouse;
    GameObject instanciaTemporaria;
    bool instanciado = false;
    bool podeInteragir = false;//saber se é a vez dele de jogar

    //verifica o chao
    public Transform GroundCheck;
    public bool pisando;
    public LayerMask oqueEChao;// saber o que é solido

    // Use this for initialization
    void Update()
    {
        pisando = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, oqueEChao);
        posicaoMouse = Camera.main.ScreenPointToRay(Input.mousePosition).GetPoint(0);
        //localDoMouse pega a posicao que o mouse ta no eixo x
        float localDoMouse = posicaoMouse.x;
        if (Input.GetMouseButton(0) && podeInteragir == true)
        {
            if (instanciado == false)
            {
                instanciado = true;
                instanciaTemporaria = Instantiate(indicador, posicaoMouse, transform.rotation) as GameObject;
                instanciaTemporaria.GetComponent<Rigidbody2D>().isKinematic = true;

            }
            instanciaTemporaria.transform.position = posicaoMouse;
        }

        if (Input.GetMouseButtonUp(0) && instanciado == true)
        {
            AcaoAtirar();
            if (localDoMouse < 0 && !olhandoParaEsquerda)
            {
                Flip();
            }
            if (localDoMouse > 0 && olhandoParaEsquerda)
            {
                Flip();
            }
            instanciado = false;
            podeInteragir = false;
            Destroy(instanciaTemporaria);
        }
    }
    void OnTriggerEnter2D(Collider2D Camera)
    {
        podeInteragir = true;
    }
    void OnTriggerExit2D(Collider2D Camera)
    {
        podeInteragir = false;
    }


    //AcaoAtirar funcao que joga a flecha pra ambos os lados seja direita ou esquerda
    private void AcaoAtirar()
    {

        GameObject tmpFlecha = (GameObject)(Instantiate(FlechaArq, PosicaoDaFlecha.transform.position, Quaternion.identity));
        if (olhandoParaEsquerda)
        {
            Vector2 direcaoForca = transform.position - instanciaTemporaria.transform.position;
            tmpFlecha.GetComponent<Rigidbody2D>().AddForce(direcaoForca * forcaLancamento, ForceMode2D.Impulse);
        }
        else
        {
            Vector2 direcaoForca = transform.position - instanciaTemporaria.transform.position;
            tmpFlecha.GetComponent<Rigidbody2D>().AddForce(direcaoForca * forcaLancamento, ForceMode2D.Impulse);
        }
    }
    //funcao que muda o lado do sprite do personagem 
    void Flip()
    {
        olhandoParaEsquerda = !olhandoParaEsquerda;
        Vector3 AEscala = transform.localScale;
        AEscala.x *= -1;
        transform.localScale = AEscala;
    }

}
