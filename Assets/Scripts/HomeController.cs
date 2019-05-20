using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeController : MonoBehaviour
{
    int contador;
    public GameObject principal;
    public GameObject mario;
    public GameObject mole;
    public GameObject naves;

    // Start is called before the first frame update
    void Start()
    {
        contador = 0;
        principal.SetActive(true);
        mario.SetActive(false);
        mole.SetActive(false);
        naves.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clickNext()
    {
        if(contador == 0)
        {
            principal.SetActive(false);
            mario.SetActive(true);
            mole.SetActive(false);
            naves.SetActive(false);
            contador += 1;
        }
        if (contador == 1)
        {
            principal.SetActive(false);
            mario.SetActive(false);
            naves.SetActive(false);
            mole.SetActive(true);
            contador += 1;
        }
        if (contador == 2)
        {
            mole.SetActive(false);
            principal.SetActive(false);
            mario.SetActive(false);
            naves.SetActive(true);
            contador = 0;
        }
    }
}
