using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript18188 : MonoBehaviour
{
    public GameObject prefabBulletEnemy;
    private Vector3 offset;
    bool empezar = true;
    public AudioSource hit;
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0,-0.4f,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (empezar)
        {
            StartCoroutine("WaitUnhide");
        }
        
    }

    IEnumerator WaitUnhide()
    {
        empezar = false;
        int numero = (int)Random.Range(2, 10);
        yield return new WaitForSeconds(numero);
        Instantiate(prefabBulletEnemy, GetComponent<Transform>().position + offset, Quaternion.identity);
        empezar = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hit.Play();
    }
}
