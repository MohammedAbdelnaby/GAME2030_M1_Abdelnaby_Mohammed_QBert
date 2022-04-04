using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseCondition : MonoBehaviour
{
    public List<GameObject> Tiles;
    public int count = 0;
    [SerializeField]
    private Sprite TileSprite;

    [SerializeField]
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Tiles.Count; i++)
        {
            if (Tiles[i].GetComponent<SpriteRenderer>().sprite == TileSprite)
            {
                Tiles.Remove(Tiles[i]);
                count++;
            }
        }
 
        if (count == 28)
        {
            HighScore();
            if (player.GetComponent<PlayerMovement>().GetLeftElevator())
            {
                player.GetComponent<PlayerMovement>().SetScore(100);
            }
            if (player.GetComponent<PlayerMovement>().GetRightElevator())
            {
                player.GetComponent<PlayerMovement>().SetScore(100);
            }
            player.GetComponent<PlayerMovement>().SetScore(1000);
            SceneManager.LoadScene(3);
        }
    }

    private void HighScore()
    {
        if (PlayerPrefs.GetInt("Top1") <= player.GetComponent<PlayerMovement>().GetScore())
        {
            Debug.Log(player.GetComponent<PlayerMovement>().GetScore());
            PlayerPrefs.SetInt("Top1", player.GetComponent<PlayerMovement>().GetScore());
        }
        else if (PlayerPrefs.GetInt("Top2") <= player.GetComponent<PlayerMovement>().GetScore())
        {
            PlayerPrefs.SetInt("Top2", player.GetComponent<PlayerMovement>().GetScore());
        }
        else if (PlayerPrefs.GetInt("Top3") <= player.GetComponent<PlayerMovement>().GetScore())
        {
            PlayerPrefs.SetInt("Top3", player.GetComponent<PlayerMovement>().GetScore());
        }
        else if (PlayerPrefs.GetInt("Top4") <= player.GetComponent<PlayerMovement>().GetScore())
        {
            PlayerPrefs.SetInt("Top4", player.GetComponent<PlayerMovement>().GetScore());
        }
        else if (PlayerPrefs.GetInt("Top5") <= player.GetComponent<PlayerMovement>().GetScore())
        {
            PlayerPrefs.SetInt("Top5", player.GetComponent<PlayerMovement>().GetScore());
        }
        else if (PlayerPrefs.GetInt("Top6") <= player.GetComponent<PlayerMovement>().GetScore())
        {
            PlayerPrefs.SetInt("Top6", player.GetComponent<PlayerMovement>().GetScore());
        }
        else if (PlayerPrefs.GetInt("Top7") <= player.GetComponent<PlayerMovement>().GetScore())
        {
            PlayerPrefs.SetInt("Top7", player.GetComponent<PlayerMovement>().GetScore());
        }
        else if (PlayerPrefs.GetInt("Top8") <= player.GetComponent<PlayerMovement>().GetScore())
        {
            PlayerPrefs.SetInt("Top8", player.GetComponent<PlayerMovement>().GetScore());
        }
        else if (PlayerPrefs.GetInt("Top9") <= player.GetComponent<PlayerMovement>().GetScore())
        {
            PlayerPrefs.SetInt("Top9", player.GetComponent<PlayerMovement>().GetScore());
        }
        else if (PlayerPrefs.GetInt("Top10") <= player.GetComponent<PlayerMovement>().GetScore())
        {
            PlayerPrefs.SetInt("Top10", player.GetComponent<PlayerMovement>().GetScore());
        }
    }
}
