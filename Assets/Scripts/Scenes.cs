using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public int scene;
    public bool movieToGame;
    private float period = 0.1f;
    private float nextActionTime = 10.5f;
    private float time;

    private void Start()
    {

    }


    void Update()
    {
        time = Time.timeSinceLevelLoad;
        if (scene!=3 && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(scene);
        }

        if (movieToGame && time > nextActionTime) Timer();

    }

    private void Timer()
    {
        nextActionTime += Time.time + period;
        // execute block of code here
        SceneManager.LoadScene(3);
    }
} 