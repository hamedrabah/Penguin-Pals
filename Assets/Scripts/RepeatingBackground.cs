using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{

    private BoxCollider2D groundCollider;
    private float groundX;
    // Start is called before the first frame update
    void Start()
    {
        groundCollider = GetComponent<BoxCollider2D>();
        groundX = groundCollider.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -groundX) moveBackground();

    }

    private void moveBackground(){
        Vector2 groundOffset = new Vector2(groundX * 2f, 0);
        transform.position = (Vector2)transform.position + groundOffset;
    }
}
