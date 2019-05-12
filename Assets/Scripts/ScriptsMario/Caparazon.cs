using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caparazon : MonoBehaviour
{
    private Rigidbody2D myBody2D;
    private Transform WayPointOne;
    private Transform WayPointTwo;
    public float speed = 3f;
    Vector3 localScale;
    bool movingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        myBody2D = GetComponent<Rigidbody2D>();
        localScale = transform.localScale;
        WayPointOne = GameObject.Find("WayPointOne").GetComponent<Transform>();
        WayPointTwo = GameObject.Find("WayPointTwo").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > WayPointTwo.position.x)
            movingRight = false;
        if (transform.position.x < WayPointOne.position.x)
            movingRight = true;

        if (movingRight)
            moveRight();
        else
            moveLeft();

    }

    void moveRight()
    {
        movingRight = true;
        localScale.x = 12;
        transform.localScale = localScale;
        myBody2D.velocity = new Vector2(localScale.x * speed, myBody2D.velocity.y);
    }

    void moveLeft()
    {
        movingRight = false;
        localScale.x = -12;
        transform.localScale = localScale;
        myBody2D.velocity = new Vector2(localScale.x * speed, myBody2D.velocity.y);
    }
}
