using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject square;

    void Start()
    {
        InvokeRepeating("MakingSquare", 0f, 1f);
    }
    
    void Update()
    {
        
    }

    private void MakingSquare()
    {
        Instantiate(square);
    }
}
