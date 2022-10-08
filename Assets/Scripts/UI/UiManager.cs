using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    [SerializeField] private PanelBase inGameUI;
    [SerializeField] private PanelBase startGameUI;
    [SerializeField] private PanelBase gameOverUI;
    [SerializeField] private PanelBase tutorialUI;
    [SerializeField] private PanelBase restartPanel;

    [SerializeField] private TMP_Text gameOverScore;

    PanelBase _currentPanel;
    PanelBase _prevPanel;

    public void ShowInGameUI()
    {
        _prevPanel = _currentPanel;
        _currentPanel = inGameUI;

        ShowAppearAnimation();
    }

    public void ShowStartGameUI()
    {
        _prevPanel = startGameUI;
        _currentPanel = startGameUI;

        ShowAppearAnimation();
    }

    public void ShowGameOverUI()
    {
        _prevPanel = _currentPanel;
        _currentPanel = gameOverUI;

        gameOverScore.text = "Score - " + GameManager.shared.GetGameInstances().scoreManager.GetScore() ;

        ShowAppearAnimation();
    }

    public void ShowTutorialUI()
    {
        _prevPanel = _currentPanel;
        _currentPanel = tutorialUI;

        ShowAppearAnimation();
    }

    public void HideTutorialPanel()
    {
        _currentPanel = _prevPanel;
        _prevPanel = tutorialUI;

        ShowAppearAnimation();
    }

    public void ShowRestartPanel(Action action)
    {
        _prevPanel?.Hide();
        restartPanel.Show();

        restartPanel.PlaySlideAnimation(() => {
            restartPanel.Hide();
            action.Invoke();

        });
    }

    private void ShowAppearAnimation()
    {
        _prevPanel?.Hide();
        _currentPanel?.Show();

        _currentPanel.PlayAppearingAnimation(() => { });
        //if (_prevPanel == _currentPanel)
        //{
        //    _currentPanel.PlayAppearingAnimation(() => { });
        //}
        //else
        //{
        //    _prevPanel.PlayDisAppearingAnimation(() => {
        //        _prevPanel.Hide();
        //        _currentPanel.PlayAppearingAnimation(() => { });

        //    });
        //    //_currentPanel.PlayAppearingAnimation(() => { });
        //}
    }

    public void StartButtonClicked()
    {
        GameManager.shared.StartNewGame();
    }

    public void RestartButtonClicked()
    {
        GameManager.shared.RestartGame();
    }

    public void TutorialButtonClicked()
    {
        ShowTutorialUI();
    }

}
