using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = "Score: " + GUIManager.sharedInstance.Score;
    }

    public void MoveToScoreScene()
    {
        GUIManager.sharedInstance.ScoreScene();
    }

    public void RePlay()
    {
        GUIManager.sharedInstance.MainScene();
    }
}
