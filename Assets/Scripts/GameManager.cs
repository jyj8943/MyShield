using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public Text timeTxt;
    public Text nowScore;
    
    public GameObject square;
    public GameObject endPanel;

    private float time = 0f;
    private bool isPlay = true;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        Time.timeScale = 1f;
        
        InvokeRepeating("MakingSquare", 0f, 1f);
    }
    
    void Update()
    {
        if (isPlay)
        {
            time += Time.deltaTime;
            timeTxt.text = time.ToString("N2");
        }
    }

    private void MakingSquare()
    {
        Instantiate(square);
    }

    public void GameOver()
    {
        isPlay = false;
        
        Time.timeScale = 0f;

        nowScore.text = time.ToString("N2");
        
        endPanel.SetActive(true);
    }
}
