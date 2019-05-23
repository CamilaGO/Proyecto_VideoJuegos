using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barra : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(bool isRight)
    {
        Vector2 posicion = Vector2.zero;
        if (isRight == true)
        {
            //se coloca del lado derechoa
            posicion = new Vector2(PongManager.topDer.x, 0);
            posicion += Vector2.right * transform.localScale.x;
        } else
        {
            //se coloca del lado izquierdo
            posicion = new Vector2(PongManager.bottomIzq.x, 0);
            posicion += Vector2.right * transform.localScale.x;
        }

        transform.position = posicion;
    }
}
