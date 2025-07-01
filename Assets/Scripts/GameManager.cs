using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text timeTxt;
    
    public GameObject square;

    private float time = 0f;
    
    void Start()
    {
        InvokeRepeating("MakingSquare", 0f, 1f);
    }
    
    void Update()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");
    }

    private void MakingSquare()
    {
        Instantiate(square);
    }
}
