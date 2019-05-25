using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongManager : MonoBehaviour
{
    //Barra Izquierda: Se controla con W/S
    //Barra Derecha: Se controla con flechas arriba/abajo
    public GameObject barraIzq;
    public GameObject barraDer;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()

    {   //La barra izquierda no se mueve hasta que presionen las teclas
        barraIzq.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        
        //Si presiona W la barra izquierda sube
        if (Input.GetKey(KeyCode.W))
        {
            barraIzq.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 9f);
        }
        //Si presiona S la barra izquierda baja
        else if (Input.GetKey(KeyCode.S))
        {
            barraIzq.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -9f);
        }

        //La barra derecha no se mueve hasta que presionen las teclas
        barraDer.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);

        //Si presiona W la barra derecha  sube
        if (Input.GetKey(KeyCode.UpArrow))
        {
            barraDer.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 9f);
        }
        //Si presiona S la barra derecha baja
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            barraDer.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -9f);
        }
        
    }

    public void regresarBarras()
    {
        barraDer.transform.position = new Vector3(21f, 0f, 0.1437345f);
        barraIzq.transform.position = new Vector3(-21f, 0f, 0.1437345f);
    }
}
