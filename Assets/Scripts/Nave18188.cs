using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave18188 : MonoBehaviour
{
    // Start is called before the first frame update
    float moveSpeed = 3;
    public GameObject prefab;
    Vector3 offset = new Vector3(0, 1.2f, 0);
    public int life = 100;
    bool isAlive = true;
    float timeScale = 1.0f;
    public AudioSource end;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.GetComponent<AudioSource>().Play();
            Instantiate(prefab, GetComponent<Transform>().position + offset, Quaternion.identity);
        }
            
        if (life == 0)
        {
            
            isAlive = false;
            if (timeScale >= 0.01f)
            {
                timeScale = timeScale - 0.01f;
                Time.timeScale = Mathf.Abs(timeScale);
            }   
            if (timeScale == 0)
            {
                Time.timeScale = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BalaEnemiga") && isAlive)
        {
            end.Play();
            life = life - 10;
            Destroy(collision.gameObject);

        }
    }

    public void takeHit()
    {
        life = life - 10;
    }
}
