using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManger : MonoBehaviour
{
    [SerializeField]
    private GameObject RedBall;
    [SerializeField]
    private GameObject GreenBall;
    [SerializeField]
    private GameObject Coily;

    public float RedballSpawn = 0.5f;

    public float GreenballSpawn = 1.5f;

    private int numEnemySpawn = 0;

    private float TimeWait = 1.0f;
    // Update is called once per frame
    void Update()
    {
        RedballSpawn -= Time.deltaTime;
        GreenballSpawn -= Time.deltaTime;
        TimeWait -= Time.deltaTime;
        if (RedballSpawn <= 0.0f && TimeWait <= 0.0f)
        {
            SpawnRedBall();
            RedballSpawn = 3.0f;
            numEnemySpawn++;
            TimeWait = 1.0f;
        }
        else if (GreenballSpawn <= 0.0f && TimeWait <= 0.0f)
        {
            SpawnGreenBall();
            GreenballSpawn = 5.0f;
            numEnemySpawn++;
            TimeWait = 1.0f;
        }
        else if (GameObject.FindGameObjectWithTag("Coily") == null && numEnemySpawn == 3 && TimeWait <= 0.0f)
        {
            SpawnCoily();
            numEnemySpawn = 0;
            TimeWait = 1.0f;
        }
    }

    private void SpawnRedBall()
    {
        if (Random.value >= 0.5f)
        {
            Instantiate(RedBall, new Vector3(-1.5f, 5.5f, 0), Quaternion.identity);
        }
        else
        {
            Instantiate(RedBall, new Vector3(-0.5f, 5.5f, 0), Quaternion.identity);
        }
    }
    private void SpawnGreenBall()
    {
        if (Random.value >= 0.5f)
        {
            Instantiate(GreenBall, new Vector3(-1.5f, 5.5f, 0), Quaternion.identity);
        }
        else
        {
            Instantiate(GreenBall, new Vector3(-0.5f, 5.5f, 0), Quaternion.identity);
        }
    }
    private void SpawnCoily()
    {
        if (Random.value >= 0.5f)
        {
            Instantiate(Coily, new Vector3(-1.5f, 5.5f, 0), Quaternion.identity);
        }
        else
        {
            Instantiate(Coily, new Vector3(-0.5f, 5.5f, 0), Quaternion.identity);
        }
    }
}
