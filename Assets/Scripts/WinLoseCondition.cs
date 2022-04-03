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

}
