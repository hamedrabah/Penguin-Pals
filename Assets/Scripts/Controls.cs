using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public float upForce = 200f;
    private bool isDead = false;
    private Rigidbody2D rb2d;
    public AudioSource audioData;
    public AudioClip gameMusic;
    public AudioClip death;
    public AudioClip menuMusic;
    public Canvas gameOverMenu;
    public AudioClip victoryMusic;


    // Start is called before the first frame update
    void Awake()
    {
        if (audioData.clip != gameMusic) playAudio(gameMusic);
        if (audioData.clip == gameMusic) audioData.Play();
    }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        gameOverMenu.enabled = false;
        rb2d.AddForce(new Vector2(0, upForce));
    }


    // Update is called once per frame
    void Update()
    {
        if (isDead) gameOverMenu.enabled = true;

        if (isDead == false)
        {
            //if (GameControl.instance!=null && GameControl.instance.birdScored) audioData.pitch += 0.005f;

            if (Input.GetMouseButtonDown(0))
            {
                rb2d.isKinematic = false;
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
                if (rb2d.position.y >6) isDead = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            
            playAudio(menuMusic);
            rb2d.velocity = Vector2.zero;
            isDead = true;
            rb2d.isKinematic = true;
        GameControl.instance.BirdDied();

    }


    public void playAudio(AudioClip clipToPlay)
    {
        audioData.clip = clipToPlay;
        audioData.Play();
    }

    public void stopAudio()
    {
        audioData.Stop();
    }
}
