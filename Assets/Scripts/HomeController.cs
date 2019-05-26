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
    public GameObject pong;

    // Start is called before the first frame update
    void Start()
    {
        contador = 0;
        principal.SetActive(true);
        mario.SetActive(false);
        mole.SetActive(false);
        naves.SetActive(false);
        pong.SetActive(false);
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
                //Se muestra mario 
                naves.SetActive(false);
                mario.SetActive(true);
                mole.SetActive(false);
                naves.SetActive(false);
                pong.SetActive(false);
                contador += 1;
                break;

            case 1:
                //se muestra Mole
                principal.SetActive(false);
                mario.SetActive(false);
                naves.SetActive(false);
                mole.SetActive(true);
                pong.SetActive(false);
                contador += 1;
                break;

            case 2:
                //Se muestran naves
                mole.SetActive(false);
                principal.SetActive(false);
                mario.SetActive(false);
                naves.SetActive(true);
                pong.SetActive(false);
                contador += 1;
                break;

            case 3:
                //se muestra pong
                naves.SetActive(false);
                principal.SetActive(false);
                mario.SetActive(false);
                mole.SetActive(false);
                pong.SetActive(true);
                contador += 1;
                break;

            case 4:
                //se muestra home otra vez
                pong.SetActive(false);
                principal.SetActive(true);
                mario.SetActive(false);
                naves.SetActive(false);
                mole.SetActive(false);
                contador = 0;
                break;
        }
    }

    public void OpenScene(string _newScene)
    {
        SceneManager.LoadScene(_newScene);
    }

    public void ExitGame()
    {
        Debug.Log("sale");
        Application.Quit();
    }
}
