using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario : MonoBehaviour
{
    public Animator animator;
    private Rigidbody2D rb2d;
    public float speed = 5f;
    public float maxSpeed = 7f;
    public float jumpPower = 125f;
    public GameObject fuego;
    public AudioControllerMario controlAudio;
    public UI_Mario uiController;
    public GameObject banderaAnimada;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        banderaAnimada.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
    }


    private void FixedUpdate()
    {
        //en direccion -1 si es izquierda o 1 si es derecha
        float h = Input.GetAxis("Horizontal");
        rb2d.AddForce(Vector2.right * speed * h);
        float limiteSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
        rb2d.velocity = new Vector2(limiteSpeed, rb2d.velocity.y);
        
        //Si precio la space bar para saltar
        if (Input.GetButtonDown("Jump"))
        {
            controlAudio.saltar = true;
            rb2d.AddForce(Vector2.up * jumpPower);
        }
    }

 
    private void OnCollisionEnter2D(Collision2D collision)
    {
      
        //Si choca con la caparazon se suman puntos
        if (collision.gameObject.name == "Caparazon")
        {
            uiController.puntos = uiController.puntos + 100;
            uiController.SetpuntosText();
            controlAudio.cap = true;
            Destroy(collision.gameObject);

        }

        if (collision.gameObject.tag == "Cubo")
        {
            Debug.Log(collision.gameObject.tag);
            controlAudio.rompeCube = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si choca con la flor se cambia de personaje por el PowerUp
        if (collision.gameObject.name == "Flor")
        {
            controlAudio.mejorar = true;
            Destroy(collision.gameObject);
            fuego.SetActive(true);
            gameObject.SetActive(false); 
        }

        //Si choca con la bandera gana 
        if (collision.gameObject.tag == "Flag")
        {
            controlAudio.gano = true;
            collision.gameObject.SetActive(false);
            banderaAnimada.SetActive(true);  //Se baja la bandera y mario ya no se puede mover
            speed = 0f;
            uiController.final = true;
            uiController.SetFinal();
        }

        //Si choca con una moneda se suma a su contador
        if (collision.gameObject.tag == "Coin")
        {
            uiController.contador = uiController.contador + 1;
            uiController.SetcoinText();
            controlAudio.gotCoin = true;
            Destroy(collision.gameObject);

        }

        //Si choca con el enemigo se muere mario
        if (collision.gameObject.tag == "Enemy")
        {
            controlAudio.fin = true;
            gameObject.SetActive(false);
            uiController.final = false;
            uiController.SetFinal();

        }


        if (collision.gameObject.tag == "Tuberia")
        {
            controlAudio.tuberia = true;
            gameObject.transform.position = new Vector2(159f, gameObject.transform.position.y);

        }

        if (collision.gameObject.name == "Hongo")
        {
            uiController.puntos = uiController.puntos + 200;
            controlAudio.tuberia = true;
            Destroy(collision.gameObject);
            controlAudio.gotCoin = true;

        }

        if(collision.gameObject.name == "Princesa")
        {
            controlAudio.gano = true;
            speed = 0f;
            uiController.final = true;
            uiController.SetFinal();
        }


    }

}
