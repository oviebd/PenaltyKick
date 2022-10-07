using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static GameManager shared;
    [SerializeField] private GameInstances _gameInstance;

    int kickPerGame = 5;

    public delegate void OnKickedCompleted(int Score, int kickNumber);
    public event OnKickedCompleted onKickCompleted;

    private void Awake()
    {
        if (shared == null)
        {
            shared = this;
        }
    }

    void Start()
    {
        GetGameInstances().uiManager.showStartGameUI();
       // StartNewGame();
    }

    public void StartNewGame()
    {
        GetGameInstances().levelManager.ResetLevel();

        GetGameInstances().uiManager.ShowRestartPanel(() => {
            GetGameInstances().levelManager.PrepareGame(kickPerGame);
            GetGameInstances().uiManager.showInGameUI();
            GetGameInstances().inGameUI.setUpIngameUI(kickPerGame);
            GetGameInstances().soundManager.PlayBackgroundSound();
        });

        
      
    }

    public void RestartGame()
    {
        StartNewGame();
    }

    public void GameOver()
    {
        GetGameInstances().soundManager.StopBackgroundSound();
        GetGameInstances().uiManager.showGameOverUI();
    }

    public GameInstances GetGameInstances()
    {
        return _gameInstance;
    }

    public void OnBallKicked(int score)
    {
       onKickCompleted?.Invoke(score, _gameInstance.levelManager.GetCurrentKickNumber());
    }


}
