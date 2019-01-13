using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public Text scoreText;
    public Text gameOverText;
    public Text gameOverText2;
    public bool gameOver = false;
    public float scrollSpeed = -1.5f;
    private int score = 0;
    public bool gameWon = false;
    public SpriteRenderer scorePenguins;
    public Sprite[] penguinsSaved;
    public bool speedUp = false;
    public bool birdScored = false;
    public Sprite genericPenguin;
    private float scoreSpotX;
    private float scoreSpotY;
    private int highScore;

    // Awake is called before the first frame update
    private void Awake()
    {
        highScore = PlayerPrefs.GetInt("highScore");
        if (instance==null){
            instance = this;
            //scoreText.text = "Score: 0";
            scoreText.enabled = false;
            gameOverText.enabled = false;
            gameOverText2.enabled = false;
        }

        else if (instance!=this){
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    private void Update(){
        //Debug.Log(scrollSpeed);
        //Leaderboard.instance.highScore = score;
        if (SceneManager.GetActiveScene().name == "game" && birdScored)
        {
            if (scrollSpeed>-5) scrollSpeed -= 0.02f;
            birdScored = false;
        } 

        //if (gameWon) SceneManager.LoadScene(4);
    }


    public void BirdScores(){
        if (gameOver) return;
        score++;
        birdScored = true;
        if (instance.score <6) {
            scorePenguins.sprite = penguinsSaved[score];
            scoreSpotX = scorePenguins.transform.position.x;
            scoreSpotY= scorePenguins.transform.position.y;
        } 
        if (instance.score>5)
        {
            scoreText.enabled = true;
            scorePenguins.sprite = genericPenguin;
            scoreText.text = instance.score.ToString();
            scorePenguins.transform.position = new Vector3(scoreSpotX - 0.5f,-4.2f);
        }
        if (score > highScore) PlayerPrefs.SetInt("highScore", score);

    }

    public void BirdDied(){
        gameOverText.enabled = true;
        gameOverText2.enabled = true;
        gameOverText2.text = "High Score: " + PlayerPrefs.GetInt("highScore");
        gameOver = true;
    }

    public int GetScore()
    {
        return score;
    }
}
