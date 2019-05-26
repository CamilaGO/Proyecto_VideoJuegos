using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet18188 : MonoBehaviour
{
    float moveSpeed = 5;
    //public GameObject n;
    Vector2 pos;
    public GameObject manager;
    GameObject[] lista;
    public AudioSource hit;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 offset = new Vector3(0, 1.2f,0);
        //transform.position = n.GetComponent<Transform>().position + offset;
        manager = GameObject.Find("Manager");
        lista = manager.GetComponent<ManagerSI18188>().lista;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            hit.Play();
            Destroy(gameObject);
            manager.GetComponent<ManagerSI18188>().sumaPuntos();
            bool sigue = true;
            while (sigue)
            {

                int x = (int)Random.Range(-7, 7);
                int y = (int)Random.Range(0, 4);
                Vector3 pos = new Vector3(x, y, 0);
                if (!estaOcupada(pos))
                {
                    collision.gameObject.transform
                        .position = pos;
                    sigue = false;
                }
            }
        }
    }

    private bool estaOcupada(Vector3 p)
    {
        for (int i = 0; i < lista.Length; i++)
        {
            if (lista[i].transform.position.Equals(p))
            {
                return true;
            }
        }
        return false;
    }
}