using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject ballSpwanerParent;
    [SerializeField] private GameObject ballPrefab;

    private int _maxKick = 5; // Kick number of a single Level
    private int _currentKickNumber = 0; 
    private bool _isGameOver = false;

    public void PrepareGame(int kickNumber)
    {
        _maxKick = kickNumber;
        _currentKickNumber = 1;
        _isGameOver = false;
        PrepareForKick();
    }

    private void PrepareForKick()
    {
        SpawnBall();
        SetTargets();
    }

  
    private void SpawnBall()
    {
        GameObject ball = Instantiate(ballPrefab);
        ball.transform.parent = ballSpwanerParent.transform;
    }

    private void SetTargets()
    {

    }

    private void ResetLevel()
    {

    }

    public void OnKickCompleted(bool isScored)
    {

        if (isScored)
        {
            GameManager.shared.GetGameInstances().uiManager.UpdateKickCountUi(_currentKickNumber - 1, KickCountUiItem.ITEM_TYPE.RIGHT);
        }
        else
        {
            GameManager.shared.GetGameInstances().uiManager.UpdateKickCountUi(_currentKickNumber - 1 , KickCountUiItem.ITEM_TYPE.MISS);
        }

        _currentKickNumber += 1;
        if (_currentKickNumber > _maxKick)
        {
            _isGameOver = true;
            Debug.Log("Game Over ...");
        }
        else
        {
            PrepareForKick();
        }

    }
}
