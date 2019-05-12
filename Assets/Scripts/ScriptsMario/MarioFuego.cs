using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioFuego : MonoBehaviour
{
    public Animator animator;
    private Rigidbody2D rb2d;
    public float speed = 5f;
    public float maxSpeed = 7f;
    public float jumpPower = 125f;
    public AudioControllerMario controlAudio;
    public GameObject clasic;
    public UI_Mario uiController;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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

        if (Input.GetButtonDown("Jump"))
        {
            controlAudio.saltar = true;
            rb2d.AddForce(Vector2.up * jumpPower);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Si choca con el enemigo se destruye el enemigo
        if (collision.gameObject.name == "Enemigo")
        {
            controlAudio.enemyCol = true;
            Destroy(collision.gameObject);
        }

        //Si choca con la caparazon se cambia de personaje porque se pierde el PowerUp
        if (collision.gameObject.name == "Caparazon")
        {
            uiController.puntos = uiController.puntos + 100; 
            controlAudio.cap = true;
            Destroy(collision.gameObject);
            clasic.SetActive(true);
            gameObject.SetActive(false);

        }

        //Si choca con una moneda se suma a su contador
        if (collision.gameObject.tag == "Coin")
        {
            uiController.contador = uiController.contador + 1;
            uiController.SetcoinText();
            Destroy(collision.gameObject);
            controlAudio.gotCoin = true;
            Destroy(collision.gameObject);

        }

        //Si choca con la bandera gana 
        if (collision.gameObject.tag == "Flag")
        {
            controlAudio.gano = true;
        }
    }
}
