using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet18188 : MonoBehaviour
{
    float moveSpeed = 5;
    public GameObject n;
    Vector2 pos;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 offset = new Vector3(0, 0.4f,0);
        transform.position = n.GetComponent<Transform>().position + offset;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Sky"))
        {
            Destroy(gameObject);
        }
    }
}