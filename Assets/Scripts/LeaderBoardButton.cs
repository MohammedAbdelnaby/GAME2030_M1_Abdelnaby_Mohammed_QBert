using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LeaderBoardButton : MonoBehaviour
{
    public void changeScene()
    {
        SceneManager.LoadScene("Main");
    }
}