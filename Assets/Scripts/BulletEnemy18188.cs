using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy18188 : MonoBehaviour
{
    float moveSpeed = -3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
    }
}
