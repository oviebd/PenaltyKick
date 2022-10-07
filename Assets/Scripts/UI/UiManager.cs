using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private PanelBase inGameUI;
    [SerializeField] private PanelBase startGameUI;
    [SerializeField] private PanelBase gameOverUI;
    [SerializeField] private PanelBase tutorialUI;
    [SerializeField] private PanelBase restartPanel;


    PanelBase _currentPanel;
    PanelBase _prevPanel;

    public void showInGameUI()
    {
        _prevPanel = _currentPanel;
        _currentPanel = inGameUI;

        ShowAppearAnimation();
    }

    public void showStartGameUI()
    {

        _prevPanel = startGameUI;
        _currentPanel = startGameUI;

        ShowAppearAnimation();
    }

    public void showGameOverUI()
    {
        _prevPanel = _currentPanel;
        _currentPanel = gameOverUI;

        ShowAppearAnimation();
    }

    public void showTutorialUI()
    {

        _prevPanel = _currentPanel;
        _currentPanel = tutorialUI;

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

    //private void HideAll()
    //{
    //    inGameUI.Hide();
    //    startGameUI.Hide();
    //    gameOverUI.Hide();
    //    tutorialUI.Hide();
    //}

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
       // GameManager.shared.t();
    }

}
