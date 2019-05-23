using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    int direccion = -1;
    public float der;
    public float izq;
    private Rigidbody2D myBody2D;
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        myBody2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (direccion == -1)
        {
            //se va a la izquierda
            if(transform.position.x > izq)
            {
                myBody2D.velocity = new Vector2(-speed, myBody2D.velocity.y);
            }
            else
            {
                direccion = 1;
            }
        }
        else
        {   //se va a la derecha
            if (transform.position.x < der)
            {
                myBody2D.velocity = new Vector2(speed, myBody2D.velocity.y);
            }
            else
            {
                direccion = -1;
            }
        }
        
        
    }
    
}
