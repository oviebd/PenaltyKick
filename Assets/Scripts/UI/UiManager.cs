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
    [SerializeField] private TMP_Text tutorialText;

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

        string data = new DataManager(new LocalDataFetcher()).GetTutorial();
        tutorialText.text = data;

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

        ShowRestartGameAlertDialog();
       // GameManager.shared.RestartGame();
    }

    public void TutorialButtonClicked()
    {
        ShowTutorialUI();
    }


    private void ShowRestartGameAlertDialog()
    {
        DialogClass actionDialogClass = new DialogBuilder().
                           Title("Restart Game !!").
                           Message(" Are you sure to restart this game. This will remove your current score.").
                           PositiveButtonText("OK").
                           NegativeButtonText("Cancel").

                           PositiveButtonAction((IDialog dialog) =>
                           {
                               GameManager.shared.RestartGame();
                               //Debug.Log("Action Dialog posituve Button clicked ");
                               dialog.HideDialog();
                           }).

                           NegativeButtonAction((IDialog dialog) =>
                           {
                               //Debug.Log("Action Dialog Negative Button clicked  ");
                               dialog.HideDialog();
                           }).

                           build();

        DialogManager.instance.SpawnDialogBasedOnDialogType(DialogTypeEnum.DialogType.ActionDialog, actionDialogClass);
    }

}
