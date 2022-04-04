using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoardText : MonoBehaviour
{
    [SerializeField]
    private Text text;

    private int[] Top10 = new int[10];
    // Start is called before the first frame update
    void Start()
    {
        Top10[0] = PlayerPrefs.GetInt("Top1");
        Top10[1] = PlayerPrefs.GetInt("Top2");
        Top10[2] = PlayerPrefs.GetInt("Top3");
        Top10[3] = PlayerPrefs.GetInt("Top4");
        Top10[4] = PlayerPrefs.GetInt("Top5");
        Top10[5] = PlayerPrefs.GetInt("Top6");
        Top10[6] = PlayerPrefs.GetInt("Top7");
        Top10[7] = PlayerPrefs.GetInt("Top8");
        Top10[8] = PlayerPrefs.GetInt("Top9");
        Top10[9] = PlayerPrefs.GetInt("Top10");
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "1" + " " + Top10[0] + "\n" +
                    "2" + " " + Top10[1] + "\n" +
                    "3" + " " + Top10[2] + "\n" +
                    "4" + " " + Top10[3] + "\n" +
                    "5" + " " + Top10[4] + "\n" +
                    "6" + " " + Top10[5] + "\n" +
                    "7" + " " + Top10[6] + "\n" +
                    "8" + " " + Top10[7] + "\n" +
                    "9" + " " + Top10[8] + "\n" +
                   "10" + " " + Top10[9] + "\n";
    }
}