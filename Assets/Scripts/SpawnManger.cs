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

    [SerializeField]
    private GameObject Player;

    public float RedballSpawn = 2.5f;

    public float GreenballSpawn = 3.0f;

    public int numEnemySpawn = 0;

    private float TimeWait = 1.0f;
    // Update is called once per frame
    void Update()
    {
        if (Player.GetComponent<PlayerMovement>().DeathTime == 0.0f && Player != null)
        {
            RedballSpawn -= Time.deltaTime;
            GreenballSpawn -= Time.deltaTime;
            TimeWait -= Time.deltaTime;
            if (GameObject.FindGameObjectWithTag("Coily") == null && numEnemySpawn == 3 && TimeWait <= 0.0f)
            {
                SpawnCoily();
                numEnemySpawn = 0;
                TimeWait = 1.0f;
            }
            if (RedballSpawn <= 0.0f && TimeWait <= 0.0f)
            {
                SpawnRedBall();
                RedballSpawn = 3.0f;
                if (GameObject.FindGameObjectWithTag("Coily") == null)
                {
                    numEnemySpawn++;
                }
                TimeWait = 1.0f;
            }
            else if (GreenballSpawn <= 0.0f && TimeWait <= 0.0f)
            {
                SpawnGreenBall();
                GreenballSpawn = 5.0f;
                if (GameObject.FindGameObjectWithTag("Coily") == null)
                {
                    numEnemySpawn++;
                }
                TimeWait = 1.0f;
            }
        }
    }

    private void SpawnRedBall()
    {
        if (Random.value >= 0.5f)
        {
            Instantiate(RedBall, new Vector3(-1.5f, 5.5f, -10.02f), Quaternion.identity);
        }
        else
        {
            Instantiate(RedBall, new Vector3(-0.5f, 5.5f, -10.02f), Quaternion.identity);
        }
    }
    private void SpawnGreenBall()
    {
        if (Random.value >= 0.5f)
        {
            Instantiate(GreenBall, new Vector3(-1.5f, 5.5f, -10.02f), Quaternion.identity);
        }
        else
        {
            Instantiate(GreenBall, new Vector3(-0.5f, 5.5f, -10.02f), Quaternion.identity);
        }
    }
    private void SpawnCoily()
    {
        if (Random.value >= 0.5f)
        {
            Instantiate(Coily, new Vector3(-1.5f, 5.5f, -10.02f), Quaternion.identity);
        }
        else
        {
            Instantiate(Coily, new Vector3(-0.5f, 5.5f, -10.02f), Quaternion.identity);
        }
    }
}
