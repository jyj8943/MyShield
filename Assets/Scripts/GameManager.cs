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
    public Text bestScore;
    
    public GameObject square;
    public GameObject endPanel;

    private float time = 0f;
    private bool isPlay = true;
    private string key = "bestScore";
    
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
        
        // 최고 점수가 있다면
        if (PlayerPrefs.HasKey(key))
        {
            float best = PlayerPrefs.GetFloat(key);
            // 최고 점수 < 현재 점수
            if (best < time)
            {
                // 현재 점수를 최고 점수에 저장한다.
                PlayerPrefs.SetFloat(key, time);
                bestScore.text = time.ToString("N2");
            }
            else
            {
                bestScore.text = best.ToString("N2");
            }
        }
        // 최고 점수가 없다면
        else
        {
            // 현재 점수를 저장한다
            PlayerPrefs.SetFloat(key, time);
            bestScore.text = time.ToString("N2");
        }
        
        endPanel.SetActive(true);
    }
}
