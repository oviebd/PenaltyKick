using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static GameManager shared;
    [SerializeField] private GameInstances _gameInstance;
   

    private void Awake()
    {
        if (shared == null)
        {
            shared = this;
        }
    }

    void Start()
    {
        _gameInstance.levelManager.PrepareGame();
    }

    public GameInstances GetGameInstances()
    {
        return _gameInstance;
    }

    public void OnBallKicked()
    {
        _gameInstance.levelManager.OnKickCompleted();
    }


}
