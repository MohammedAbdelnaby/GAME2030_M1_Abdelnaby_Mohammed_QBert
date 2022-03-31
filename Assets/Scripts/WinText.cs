using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinText : MonoBehaviour
{
    [SerializeField]
    private float time = 0.0f;

    [SerializeField]
    private Text text;

    [SerializeField]
    private GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        text.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0.0f)
        {
            text.enabled = true;
        }
        if(time <= -0.5f)
        {
            text.enabled = false;
        }
        if (time <= -1.0f)
        {
            text.enabled = true;
        }
        if (time <= -1.5f)
        {
            text.enabled = false;
        }
        if (time <= -2.0f)
        {
            text.enabled = true;
        }
        if (time <= -2.5f)
        {
            button.SetActive(true);
        }
    }
}
