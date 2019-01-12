using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    public GameObject drone;
    public GameObject penguin;
    public RuntimeAnimatorController damaged0;
    public RuntimeAnimatorController damaged1;
    public RuntimeAnimatorController damaged2;
    public RuntimeAnimatorController landingPenguin;

    private Transform enemy;
    private Animator drone2Penguin;
    private Transform player;



    private float speed = 1f;
    private float randY;
    private bool droneDefeated;
    private int health = 1;
    private int startHealth;
    private float droneStart;

    private bool timer = false;
    private int count = 0;
    private int limit = 500;





    // Start is called before the first frame update
    void Start()
    {
        //drone
        enemy = drone.GetComponent<Transform>();
        drone2Penguin = drone.GetComponent<Animator>();
        droneStart = enemy.position.x;

        //player
        player = penguin.GetComponent<Transform>();

        //misc
        startHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer)
        {
            if (count < limit)
            {
                if (count==1) GameControl.instance.BirdScores();
                count++;
                if (count == limit)
                {
                    count = 0;
                    health = startHealth;
                    timer = false;
                    droneDefeated = false;
                    drone2Penguin.runtimeAnimatorController = damaged0;


                }

            }
        }

        if (!droneDefeated)
        {
            randY = Random.Range(-5, 5);
            enemy.position -= new Vector3(speed / 100, randY / 1000);
            if (enemy.position.x < player.position.x) enemy.position = new Vector3(droneStart, 0);

        }
        if (droneDefeated)
        {
            drone2Penguin.runtimeAnimatorController = landingPenguin;
            if (enemy.position.y>-2) enemy.position -= new Vector3(0, speed / 100);
            else
            {
                enemy.position = player.position + new Vector3(10, 0);
            } 
            timer = true;
        }

        if (PlayerNear())
        {
            health -= 1;
            if (health == 2 || health == 1)
            {
                enemy.position += new Vector3(player.position.x+5f, 0);
                if (health==2) drone2Penguin.runtimeAnimatorController = damaged1;

                if (health == 1) drone2Penguin.runtimeAnimatorController = damaged2;


            }
            if (health == 0)
            {
                droneDefeated = true;
            }

           
        }

        if (GameControl.instance.gameOver == true) enemy.position= new Vector3(droneStart, 0);
    }

    private bool PlayerNear()
    {
        bool xPos;
        bool yPos;
        xPos = Mathf.Abs(player.position.x - enemy.position.x)<= 1;
        yPos = Mathf.Abs(player.position.y - enemy.position.y) <= 1;

        return xPos && yPos;
    }
}
