using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    private Transform alvo;      //Quem a camera segue
    public float velocidade = 6f;  //Com qual velocidade a camera segue
    public GameObject flecha;
    public GameObject time1;
    public GameObject time2;

    private int lado;
    bool podeInteragir = false;
    bool Disparou = false;
    private string timeDaVez;

    public float minX = -9999;
    public float maxX = 9999;
    public float minY = -9999;
    public float maxY = 9999;

    void Start()
    {
        if (PlayerPrefs.GetInt("volume") == 1)
            habilitarSom();
        else
            desabilitarSom();
        lado = Random.Range(0, 10) + 1;
        Debug.Log("numero escolhido =" + lado);
        if (lado <= 5)
        {
            alvo = time1.transform;
            timeDaVez = "1";
        }
        if (lado > 5)
        {
            alvo = time2.transform;
            timeDaVez = "2";
        }
    }

    void FixedUpdate()
    {
       if(podeInteragir == true && Input.GetMouseButtonUp(0))
        {
            /*if (Disparou == true && flecha.activeSelf)
            {
                Debug.Log("esta em cena a flecha");
                alvo = flecha.transform;
                var destino = new Vector3(alvo.position.x, alvo.position.y, transform.position.z);
               transform.position = Vector3.Lerp(transform.position, destino, velocidade * Time.deltaTime);
                Disparou = false;
            }*/
            if (alvo == time1.transform )
            {

				//Camera.main.transform.position = new Vector3 (Camera.main.transform.position.x + 1, Camera.main.transform.position.y, Camera.main.transform.position.z);
                alvo = time2.transform;
                var destino = new Vector3(alvo.position.x, alvo.position.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, destino, velocidade * Time.deltaTime);
                podeInteragir = false;
                timeDaVez = "2";
            }
            else
            {
                //alvo = time1.transform;
                 var destino = new Vector3(alvo.position.x, alvo.position.y, transform.position.z);
                 transform.position = Vector3.Lerp(transform.position, destino, velocidade * Time.deltaTime);
                podeInteragir = false;
                timeDaVez = "1";
            }


        }
        if (alvo != null && podeInteragir == false)
        {
            var destino = new Vector3(alvo.position.x, alvo.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, destino, velocidade * Time.deltaTime);
        }

        //Limite
        var camera = GetComponent<Camera>();
        if (camera.orthographic)
        {
            var x = transform.position.x;
            var y = transform.position.y;
            var z = transform.position.z;

            var alcanceHorizontal = camera.orthographicSize * Screen.width / Screen.height;

            var realMinX = minX + alcanceHorizontal;
            var realMaxX = maxX - alcanceHorizontal;

            x = Mathf.Clamp(x, realMinX, realMaxX);
            y = Mathf.Clamp(y, minY, maxY);

            transform.position = new Vector3(x, y, z);
        }
    }

    public void habilitarSom()
    {
        AudioListener.volume = 1f;                      //Audio do jogo em 100%
        //GetComponent<AudioListener>().enabled = true; //Não funciona no Build, apenas no Editor
    }

    public void desabilitarSom()
    {
        AudioListener.volume = 0;                        //Audio do jogo em 0%
        //GetComponent<AudioListener>().enabled = false; //Não funciona no Build, apenas no Editor
    }
    void OnTriggerEnter2D(Collider2D flecha)//ativa os booleanos quando a flecha sai do arqueiro
    {
        podeInteragir = true;
        Disparou = true;
    }
    
    void OnGUI()
    {
        if (podeInteragir == true)
        {
            GUIStyle stylez = new GUIStyle();
            stylez.alignment = TextAnchor.MiddleCenter;
            GUI.skin.label.fontSize = 20;
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 50, 200, 30), "Time " + timeDaVez);
        }
    }

}

