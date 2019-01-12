using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Transform spot;
    private float startX;
    private float speed = 1f;
    private int  health= 1;
    
    private Animator anim;
    public Transform penguin;
    public GameObject fire;
    private Transform firePos;

    public Transform player;
    private int timer =0;

    // Start is called before the first frame update
    void Start()
    {
       spot = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        startX = spot.position.x;
        firePos = fire.GetComponent<Transform>();
      
    }

    // Update is called once per frame
    void Update()
    {
        timer++;
        float randY = Random.Range(-5, 5);
        spot.position -= new Vector3(speed / 100, randY / 1000);
        if (spot.position.x < player.position.x) spot.position = new Vector3(startX, 0);

        if (PlayerNear())
        {
            health -= 1;
            spot.position = new Vector3(startX, 0);
        }

        if (timer == 100)
        {
            //timer = 0;
            fire.SetActive(true);
            firePos.position = spot.position - new Vector3(speed / 100, 0);

        }

    }

    private bool PlayerNear()
    {
        bool xPos;
        bool yPos;
        xPos = Mathf.Abs(player.position.x - spot.position.x) <= 1;
        yPos = Mathf.Abs(player.position.y - spot.position.y) <= 1;

        return xPos && yPos;
    }
}
