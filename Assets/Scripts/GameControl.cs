using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public GameObject gameOverText;
    //public Text scoreText;
    public Text gameOverText2;
    public bool gameOver = false;
    public float scrollSpeed = -1.5f;
    private int score = 0;
    public bool gameWon = false;
    public SpriteRenderer scorePenguins;
    public Sprite[] penguinsSaved;
    public bool speedUp = false;
    public bool birdScored = false;


    // Awake is called before the first frame update
    private void Awake()
    {
        if (instance==null){
            instance = this;
            //scoreText.text = "Score: 0";

        }
        else if (instance!=this){
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    private void Update(){
        //Debug.Log(scrollSpeed);
        if (SceneManager.GetActiveScene().name == "game" && birdScored)
        {
            scrollSpeed -= 0.3f;
            birdScored = false;
        } 
        if (gameOver==true && Input.GetMouseButtonDown(0)){
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene(3);
        }

        if (gameWon) SceneManager.LoadScene(0);
    }


    public void BirdScores(){
        if (gameOver) return;
        score++;
        birdScored = true;
        scorePenguins.sprite = penguinsSaved[score];
        //scoreText.text = "Score: " + score.ToString(); 
    }

    public void BirdDied(){
        gameOverText.SetActive(true);
        gameOver = true;
    }

    public int GetScore()
    {
        return score;
    }
}
