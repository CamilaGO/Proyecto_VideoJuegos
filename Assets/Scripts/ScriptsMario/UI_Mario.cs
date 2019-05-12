using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Mario : MonoBehaviour
{
    public int contador = 0;
    public int puntos = 0;
    public Text puntosText;
    public Text coinText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Replay(string _newScene)
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
}
