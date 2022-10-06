using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int _currenrScore = 0;

    private void OnEnable()
    {
        GameManager.shared.onKickCompleted += AddScore;
    }


    private void OnDestroy()
    {
        GameManager.shared.onKickCompleted -= AddScore;
    }

    public void AddScore(int score)
    {
        _currenrScore = score + _currenrScore;
        Debug.Log("U>> Current SCore " + _currenrScore);
        GameManager.shared.GetGameInstances().uiManager.UpdateScore(_currenrScore);
       
    }


    public void ResetAll()
    {
        _currenrScore = 0;
    }
}
