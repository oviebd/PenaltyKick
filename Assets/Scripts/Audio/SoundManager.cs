using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyUtility;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioPlayerControler _kickSound;
    [SerializeField] private AudioPlayerControler _bgSound;

    [SerializeField] private Image _soundSettingButton;
    [SerializeField] private Sprite _spriteSoundOn;
    [SerializeField] private Sprite _spriteSoundOff;

    public void PlayKickSound()
    {
        _kickSound.PlaySound();
    }

    public void PlayBackgroundSound()
    {
        _bgSound.PlaySound();
    }

    private void Awake()
    {
        AudioManager.onAudioStateChange += onSOundStateChange;
    }

    private void OnDestroy()
    {
        AudioManager.onAudioStateChange -= onSOundStateChange;
    }

    private void Start()
    {
        SetSoundButtonGraphics();
    }
    public void OnSoundButtonClicked()
    {
        AudioManager.instance.ChangeGameAudioStatus();
        SetSoundButtonGraphics();
    }



    void onSOundStateChange(bool isSoundOn)
    {
        SetSoundButtonGraphics();
    }
    private void SetSoundButtonGraphics()
    {
        bool isAudioOn = AudioManager.instance.IsGameAudioOn();
        if (isAudioOn)
            _soundSettingButton.sprite = _spriteSoundOn;
        else
            _soundSettingButton.sprite = _spriteSoundOff;
    }

}
