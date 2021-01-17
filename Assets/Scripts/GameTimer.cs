using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public static GameTimer sharedInstance;
    [Tooltip("Our Level timer is in seconds")]
    public float levelTime = 30;
    Slider slider;
    public float timeBeforeDiscount = 1f;

    private void Awake()
    {
        if (sharedInstance == null)
            sharedInstance = this;
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountDownRoutine());
        slider = GetComponent<Slider>();
        Debug.Log(slider.maxValue);
    }

    IEnumerator CountDownRoutine()
    {
        while (levelTime > 0)
        {
            yield return new WaitForSeconds(timeBeforeDiscount);
            levelTime--;

            slider.value = levelTime;
        }

        FindObjectOfType<GUIManager>().LevelTimerFinished();
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (levelTime > slider.maxValue)
        {
            slider.maxValue = levelTime;
        }
    }

    public float LevelTime
    {
        get { return levelTime; }
        set
        {
            levelTime = value;
        }
    }
}
