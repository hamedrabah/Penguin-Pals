using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    private GameObject[] columns;
    public int columnPoolSize = 5;
    public GameObject columnPrefab;
    private Vector2 objectPoolPosition = new Vector2(-10f, -15f);
    private float timeSinceSpawn;
    public float spawnRate = 5f;
    public float colmin = -1f;
    public float colmax = 3.5f;
    private float spawnX = 10f;
    private int currentCol = 0;
    public bool isColumn;
    // Start is called before the first frame update
    void Start()
    {
        columns = new GameObject[columnPoolSize];
        for (int i = 0; i < columnPoolSize; i++)
        {
            columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {
        timeSinceSpawn += Time.deltaTime;
        if (isColumn && GameControl.instance.birdScored)
        {
            colmin += 0.2f;
            colmax -= 0.2f;
            spawnX -= 1f;
        }
        if (GameControl.instance.gameOver==false && timeSinceSpawn>=spawnRate){
            timeSinceSpawn = 0;
            float spawnY= Random.Range(colmin, colmax);
            columns[currentCol].transform.position = new Vector2(spawnX, spawnY);
            if (isColumn && GameControl.instance.GetScore() > 1) HardMode();
            currentCol++;
            if (currentCol >= columnPoolSize) currentCol = 0;
        }
    }

    void HardMode()
    {
        bool Boolean = (Random.value > 0.4* GameControl.instance.GetScore());
        columns[currentCol].GetComponent<Rigidbody2D>().isKinematic = Boolean;
        //if true its easier, more false the moroe hard 
    }
}
