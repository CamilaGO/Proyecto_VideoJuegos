using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave18188 : MonoBehaviour
{
    // Start is called before the first frame update
    float moveSpeed = 3;
    public GameObject prefab;
    Vector3 offset = new Vector3(0, 1.2f, 0);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
            Instantiate(prefab, GetComponent<Transform>().position + offset, Quaternion.identity);

    }
}
