using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Mario : MonoBehaviour
{
    //valores y controladores
    public int contador = 0;
    public int puntos = 0;
    public bool final;
    //textos a llenar
    public Text puntosText;
    public Text coinText;
    public GameObject winText;
    public GameObject perdioText;
    //Variables para controlar pausas y escenas
    public string sceneName;
    private bool isPause = false;

    // Start is called before the first frame update
    void Start()
    {
        perdioText.SetActive(false);
        winText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene(sceneName);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause) Continue();
            else PauseGame();
        }


    }

    public void Restart(string _newScene)
    {
        SceneManager.LoadScene(_newScene);
    }


    public void SetpuntosText()
    {
        //Se muestra la cantidad de monedas recolectadas
        puntosText.GetComponent<Text>().text = "000" + puntos;

    }

    public void SetcoinText()
    {
        //Se muestra la cantidad de monedas recolectadas
        coinText.GetComponent<Text>().text = "0" + contador;

    }

    public void SetFinal()
    {
        if (final == true){
            //Si gana
            winText.SetActive(true);
        }
        else
        {
            //Si pierde
            perdioText.SetActive(true);
        }
    }

    public void PauseGame()
    {
        //Se muestra el panel de pausa
        transform.Find("PauseMenu").gameObject.SetActive(true);
        //Se pausan todos los objetos de la escena
        Time.timeScale = 0.0f;
        isPause = true;
    }

    public void Continue()
    {
        //Se quita el menu de pause
        transform.Find("PauseMenu").gameObject.SetActive(false);
        //Se vuelven a mover todos los objetos
        Time.timeScale = 1.0f;
        isPause = false;
    }

     public void BackHome(string _newScene)
    {
        SceneManager.LoadScene(_newScene);

    }


}
