using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIManager : MonoBehaviour
{
    public static GUIManager sharedInstance;
    [SerializeField] Text moveText, scoreText;
    private int moveCounter = 0;
    private int score = 0;
    private int movesToSpeedTime = 3;

    private void Awake()
    {
        if (sharedInstance == null)
            sharedInstance = this;
        else
        {
            Destroy(gameObject);
        }
    }

    //Esto se hace porque de lo contrario habria que dejar estas variables en un update, y para moviles esto no es lo mas optimo
    // En cambio asi se va modificando la variable con un geter y un seter que esto si es lo mas optimo.
    public int Score
    {
        get { return score; }
        set { score = value; scoreText.text = "Score: " + score.ToString(); }
    }

    public int MoveCounter
    {
        get { return moveCounter; }
        set 
        {
            moveCounter = value; 
            moveText.text = "Moves: " + moveCounter.ToString();

            if (moveCounter % movesToSpeedTime == 0)
            {
                GameTimer.sharedInstance.timeBeforeDiscount = GameTimer.sharedInstance.timeBeforeDiscount*0.9f;
            }
        }
    }

    public void LevelTimerFinished()
    {
        StartCoroutine(GameOverScene());
    }

    private IEnumerator GameOverScene()
    {
        yield return new WaitUntil(() => !BoardManager.sharedInstance.isShifting);
        yield return new WaitForSeconds(1f);
        PlayerPrefs.SetInt("Score", Score);
        SceneManager.LoadScene("GameOverScene");

    }

    // Start is called before the first frame update
    void Start()
    {
        moveText.text = "Moves: " + moveCounter.ToString();
        scoreText.text = "Score: " + score.ToString();
    }

    public void ScoreScene()
    {
        SceneManager.LoadScene("ScoreScene");
    }

    public void MainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
