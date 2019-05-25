using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota : MonoBehaviour
{
    Rigidbody2D rb;
    public ScorePong controladorPuntos;
    public PongManager controladorBarras;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Pausa()); //Se esperan 2.5s segundos antes de comenzar a moverse

    }

    // Update is called once per frame
    void Update()
    {
        //Se revisa si salio de pantalla la pelota
        if(transform.position.x < -25f)
        {
            //si sale por izquierda, todo se regresa a la posicion inicial y se incrementa score de oponente
            controladorPuntos.ganoRight();
            transform.position = Vector2.zero;
            controladorBarras.regresarBarras();
            //espera un poco antes de moverse otra vez
            rb.velocity = Vector2.zero;
            StartCoroutine(Pausa());

        }
        if (transform.position.x > 25f)
        {
            // si sale por derecha, todo se regresa a la posicion inicial y se incrementa score de oponente
            controladorPuntos.ganoLeft();
            transform.position = Vector2.zero;
            controladorBarras.regresarBarras();
            //espera un poco antes de moverse otra vez
            rb.velocity = Vector2.zero;
            StartCoroutine(Pausa());
        }
    }

    IEnumerator Pausa()
    {
        yield return new WaitForSeconds(2f);
        Movimiento();  //Despues de esperar inicia a moverse la esfera
    }

    void Movimiento()
    {
        //Determinar hacia que direccion irse a la izquierda o derecha
        int xDireccion = Random.Range(0, 2);
        int yDireccion = Random.Range(0, 3);
        Vector2 launchDirec = new Vector2();
        if (xDireccion == 0)
        {
            launchDirec.x = -8f;
        }
        if (xDireccion == 1)
        {
            launchDirec.x = 8f;
        }
        if (yDireccion == 0)
        {
            launchDirec.y = -8f;
        }
        if (yDireccion == 1)
        {
            launchDirec.y = 8f;
        }
        if (yDireccion == 2)
        {
            launchDirec.y = 0f;
        }
        //Se le da la la velocidad y direccion a la esfera
        rb.velocity = launchDirec;

    }

    // Acciones que toma si choca con las barras o los limites 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Si choca con los limites de la pantalla
        if (collision.gameObject.tag == "Limite")
        {
            float direccionX = 0f;

            if (rb.velocity.x > 0f)
                direccionX = 8f;

            if (rb.velocity.x < 0f)
                direccionX = -8f;
            //Cambia de direccion opuesta vertical
            if (collision.gameObject.name == "TopLimit")
            {
                rb.velocity = new Vector2(direccionX, -8f);
            }
            if (collision.gameObject.name == "BottomLimit")
            {
                rb.velocity = new Vector2(direccionX, 8f);
            }
        }

        //Si choca con las barras
        if (collision.gameObject.name == "BarraIzq")
        {
            rb.velocity = new Vector2(13f, 0f);

            //Si choca en el inferior de la barra izquierda
            if(transform.position.y - collision.gameObject.transform.position.y < -1)
            {   //Se va a la derecha y abajo
                rb.velocity = new Vector2(8f, -8f);
            }
            //Si choca en la parte de arriba de la barra izquierda
            if (transform.position.y - collision.gameObject.transform.position.y > 1)
            {   //Se va a la derecha y arriba
                rb.velocity = new Vector2(8f, 8f);
            }

        }

        if (collision.gameObject.name == "BarraDer")
        {
            rb.velocity = new Vector2(-13f, 0f);

            //Si choca en el inferior de la barra derecga
            if (transform.position.y - collision.gameObject.transform.position.y < -1)
            {   //Se va a la izquierda y abajo
                rb.velocity = new Vector2(-8f, -8f);
            }
            //Si choca en la parte de arriba de la barra derecha
            if (transform.position.y - collision.gameObject.transform.position.y > 1)
            {   //Se va a la izquierda y arriba
                rb.velocity = new Vector2(-8f, 8f);
            }
        }
        
    }
}
