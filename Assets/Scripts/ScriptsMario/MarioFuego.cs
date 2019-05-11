using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioFuego : MonoBehaviour
{
    public Animator animator;
    private Rigidbody2D rb2d;
    public float speed = 4.5f;
    public float maxSpeed = 5f;
    public float jumpPower = 100f;
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

        if (Input.GetButtonDown("Jump"))
        {
            controlAudio.saltar = true;
            rb2d.AddForce(Vector2.up * jumpPower);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Enemigo")
        {
            controlAudio.gano = true;
            Destroy(collision.gameObject);
        }
    }
}
