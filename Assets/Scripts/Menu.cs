using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    public Button startStory;
    public Button startGame;
    public Button sartScores;
    //public int scene;
    // Start is called before the first frame update

    //    public void OnStartGame()
    //{
    //    Debug.Log("hello");
    //}
    //void Start()
    //{
    //    startStory.onClick.AddListener(TaskOnClick);

    //}

    public void TaskOnClick(int scene)
    {
        //Output this to console when Button1 or Button3 is clicked
        SceneManager.LoadScene(scene);
    }

    public void TaskOnClick(string name)
    {
        //Output this to console when Button1 or Button3 is clicked
        SceneManager.LoadScene(name);
    }
}
