using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ManagerSI18188 : MonoBehaviour
{
    public Text score;
    public int contador = 0;
    public GameObject prefabBullet;
    public GameObject[] lista;
    // Start is called before the first frame update
    void Start()
    {
        score.text = "Score: 0";
        for (int i = 0; i < 15; i++)
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
        score.text = "Score: " + contador;
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
}
