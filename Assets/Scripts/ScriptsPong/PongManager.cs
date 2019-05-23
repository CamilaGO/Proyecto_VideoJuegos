using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongManager : MonoBehaviour
{
    public Pelota pelota;
    public Barra barra;

    public static Vector2 bottomIzq;
    public static Vector2 topDer;

    // Start is called before the first frame update
    void Start()
    {
        bottomIzq = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        topDer = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        
        //Se crean 2 barras y 1 pelota al iniciar el juego
        Instantiate(pelota);
        Barra barra1 = Instantiate(barra) as Barra;
        Barra barra2 = Instantiate(barra) as Barra;
        barra1.Init(true);  //barra derecha
        barra1.Init(false);   //barra izquierda

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
