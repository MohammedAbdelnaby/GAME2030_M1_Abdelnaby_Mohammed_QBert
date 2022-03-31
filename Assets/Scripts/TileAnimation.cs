using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileAnimation : MonoBehaviour
{
    [SerializeField]
    private float time = 0.0f;

    [SerializeField]
    private Sprite normal;

    [SerializeField]
    private Sprite change;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0.0f)
        {
            GetComponent<SpriteRenderer>().sprite = change;
        }
    }
}
