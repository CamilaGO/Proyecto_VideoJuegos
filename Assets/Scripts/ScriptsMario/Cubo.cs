using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubo : MonoBehaviour
{
    public GameObject prop;
    public GameObject chocada;
    // Start is called before the first frame update
    void Start()
    {
        prop.SetActive(false);
        chocada.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Player")
        {
            prop.SetActive(true);
            gameObject.SetActive(false);
            chocada.SetActive(true);
            
        }
    }
}
