using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    public static Leaderboard instance;
    public int highScore;
    public object GetCanvas;
    public Text score;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        highScore = PlayerPrefs.GetInt("highScore");
        if (highScore <2)
        {
            score.text = "Your high score is " + highScore + ", sad!";
        }
        else
        {
            score.text = "Your high score is " + highScore + " points, I think you can do better!";
        }
    }
}
