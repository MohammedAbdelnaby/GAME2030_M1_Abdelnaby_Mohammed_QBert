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
            SceneManager.LoadScene(3);
        }
    }

}
