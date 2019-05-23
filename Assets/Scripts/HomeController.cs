using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        switch (contador)
        {
            case 0:
                principal.SetActive(false);
                mario.SetActive(true);
                mole.SetActive(false);
                naves.SetActive(false);
                contador += 1;
                break;

            case 1:
                principal.SetActive(false);
                mario.SetActive(false);
                naves.SetActive(false);
                mole.SetActive(true);
                contador += 1;
                break;

            case 2:
                mole.SetActive(false);
                principal.SetActive(false);
                mario.SetActive(false);
                naves.SetActive(true);
                contador = 0;
                break;
        }
        /*if(contador == 0)
        {
            principal.SetActive(false);
            mario.SetActive(true);
            mole.SetActive(false);
            naves.SetActive(false);
            contador += 1;
        }
        else if (contador == 1)
        {
            principal.SetActive(false);
            mario.SetActive(false);
            naves.SetActive(false);
            mole.SetActive(true);
            contador += 1;
        }
        else if (contador == 2)
        {
            mole.SetActive(false);
            principal.SetActive(false);
            mario.SetActive(false);
            naves.SetActive(true);
            contador = 0;
        }*/
    }

    public void OpenScene(string _newScene)
    {
        SceneManager.LoadScene(_newScene);
    }
}
