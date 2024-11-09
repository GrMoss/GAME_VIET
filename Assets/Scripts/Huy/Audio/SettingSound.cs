using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingSound : MonoBehaviour
{   
    [SerializeField] private string soundTheme;
    [SerializeField] private string soundButton;
    [SerializeField] private string soundSelect;

    public void SelectSound()
    {
        FindObjectOfType<AudioManager>().Play(soundSelect);
    }
    public void ButtonSound()
    {
        FindObjectOfType<AudioManager>().Play(soundButton);
    }

      public void SoundFx(string nameSound)
    {
        FindObjectOfType<AudioManager>().Play(nameSound);
    }

    public void PlaySound(string nameSound)
    {
        FindObjectOfType<AudioManager>().Play(nameSound);
    }
}
