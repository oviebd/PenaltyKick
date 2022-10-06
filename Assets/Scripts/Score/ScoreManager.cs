using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int _currenrScore = 0;


    public void AddScore(int score)
    {
        _currenrScore = score + _currenrScore;
        Debug.Log("U>> Current SCore " + _currenrScore);
    }


    public void ResetAll()
    {
        _currenrScore = 0;
    }
}
