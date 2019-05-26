using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ManagerSI18188 : MonoBehaviour
{
    public Text score;
    public Text life;
    public int contador = 0;
    public GameObject prefabBullet;
    public GameObject prefabEnemy;
    public GameObject[] lista;
    public Text youLost;
    public Button tryAgain;
    public Button mainMenu;
    int vida;
    // Start is called before the first frame update
    void Start()
    {
        score.text = "Score: 0";
        for (int i = 0; i < lista.Length; i++)
        {
            int y = (int)Random.Range(0 , 4);
            int x = (int)Random.Range(-7, 7);
            Vector3 pos = new Vector3(x,y,0);
            if (!estaOcupada(pos))
            {
                lista[i].transform.position = pos;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        vida = GameObject.Find("ship").GetComponent<Nave18188>().life;
        score.text = "Score: " + contador;
        life.text = "Life: " + vida;
        if (vida == 0)
        {
            youLost.gameObject.SetActive(true);
            tryAgain.gameObject.SetActive(true);
            mainMenu.gameObject.SetActive(true);
        }
    }

    public void sumaPuntos()
    {
        contador++;     
    }

    private bool estaOcupada(Vector3 p)
    {
        for (int i = 0; i < lista.Length ; i++)
        {
            if (lista[i].transform.position.Equals(p))
            {
                return true;
            }
        }
        return false;
    }


    public void agregarEnemigo()
    {
        bool sigue = true;
        while (sigue)
        {
            int y = (int)Random.Range(0, 4);
            int x = (int)Random.Range(-7, 7);
            Vector3 pos = new Vector3(x, y, 0);
            if (!estaOcupada(pos))
            {
                sigue = false;
                Instantiate(prefabEnemy, pos, Quaternion.identity);
            }
        }
    }

    public void newScene(string name)
    {
        SceneManager.LoadScene(name);
        Time.timeScale = 1.0f;
    }
}
