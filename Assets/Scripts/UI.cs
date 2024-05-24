using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text ScoreText;

    public Text TimeText;

    public GameTimer GameTimer;
    
    public CanvasGroup StartScreenCanvasGroup;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void HideStartScreen()
    {
        CanvasGroupDisplayer.Hide(StartScreenCanvasGroup);
    }

    // Update is called once per frame
    void Update()
    {
        ShowTime();
    }

    public void ShowTime()
    {
        TimeText.text = GameTimer.GetTimeAsString();
    }

    public void ShowScore()
    {
        ScoreText.text = "Score: " + ScoreKeeper.Get().ToString();
    }
}
