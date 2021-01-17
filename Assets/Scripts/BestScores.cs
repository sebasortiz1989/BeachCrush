using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScores : MonoBehaviour
{
    public List<int> scores = new List<int>();
    public List<int> savedScores = new List<int>();
    public Dropdown menu;

    private void Start()
    {
        for (int i = 0; i < savedScores.Count; i++)
        {
            PlayerPrefs.GetInt("Score" + i, savedScores[i]);
            scores.Add(savedScores[i]);
        }
    }

    public void AddScore()
    {
        scores.Add(GUIManager.sharedInstance.Score);

        for (int i = 0; i < scores.Count; i++)
        {
            PlayerPrefs.SetInt("Score" + i, scores[i]);
        }
    }





}
