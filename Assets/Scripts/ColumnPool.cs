using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    private GameObject[] columns;
    public int columnPoolSize = 5;
    public GameObject columnPrefab;
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
    private float timeSinceSpawn;
    public float spawnRate = 4f;
    public float colmin = -1f;
    public float colmax = 3.5f;
    private float spawnX = 10f;
    private int currentCol = 0;
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
        if (GameControl.instance.birdScored)
        {
            colmin += 0.2f;
            colmax -= 0.2f;
            spawnX -= 1f;
        }
        if (GameControl.instance.gameOver==false && timeSinceSpawn>=spawnRate){
            timeSinceSpawn = 0;
            float spawnY= Random.Range(colmin, colmax);
            columns[currentCol].transform.position = new Vector2(spawnX, spawnY);
            currentCol++;
            if (currentCol >= columnPoolSize) currentCol = 0;
        }
    }
}
