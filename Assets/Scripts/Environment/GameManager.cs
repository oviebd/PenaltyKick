using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static GameManager shared;
    [SerializeField] private GameInstances _gameInstance;

    int kickPerGame = 5;

    private void Awake()
    {
        if (shared == null)
        {
            shared = this;
        }
    }

    void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        _gameInstance.levelManager.PrepareGame(kickPerGame);
        _gameInstance.uiManager.SetInitialGameUI(kickPerGame);
    }

    public GameInstances GetGameInstances()
    {
        return _gameInstance;
    }

    public void OnBallKicked(bool isScoredByThisBall)
    {
        _gameInstance.levelManager.OnKickCompleted(isScoredByThisBall);
    }


}
