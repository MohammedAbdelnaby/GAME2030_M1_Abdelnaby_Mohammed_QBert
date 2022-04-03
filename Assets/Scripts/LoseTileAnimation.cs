using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseTileAnimation : MonoBehaviour
{
    [SerializeField]
    private float time = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time -= Time.fixedDeltaTime * 2.0f;
        if (time <= 0.0f)
        {
            GetComponent<Rigidbody2D>().gravityScale = 1.0f;
        }
    }
}
