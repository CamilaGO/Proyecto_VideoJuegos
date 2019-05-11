using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario : MonoBehaviour
{
    public Animator animator;
    private Rigidbody2D rb2d;
    public float speed = 5f;
    public float maxSpeed = 7f;
    public float jumpPower = 100f;
    public GameObject fuego;
    public AudioControllerMario controlAudio;

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
        
        //Si precio la space bar para saltar
        if (Input.GetButtonDown("Jump"))
        {
            controlAudio.saltar = true;
            rb2d.AddForce(Vector2.up * jumpPower);
        }
    }

    //Si choca con la flor se cambia de personaje por el PowerUp
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Flor")
        {
            controlAudio.mejorar = true;
            Destroy(collision.gameObject);
            fuego.SetActive(true);
            gameObject.SetActive(false);
        }

        if (collision.gameObject.name == "Enemigo")
        {
            controlAudio.fin = true;
            Destroy(gameObject);
            
        }
    }
   
}
