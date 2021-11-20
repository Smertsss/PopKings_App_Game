using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuControll : MonoBehaviour
{
    private int CurrentLevel;
    [SerializeField] private AudioMixerGroup Mixer;
    [SerializeField] private AudioSource music;
    private float musicVolume=1;
    void Awake()
    {
        musicVolume = PlayerPrefs.GetFloat("Sound");
        //CurrentLevel=PlayerPrefs.GetInt("level");
        if (PlayerPrefs.GetInt("level") == 0)
        {
            PlayerPrefs.SetInt("level",1);
        }
    }
    public void GoToLastSavedLevel()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("level"));
       
        //PlayerPrefs.Save();
    }
    public void ToggleSound(bool enabled)
    {
        if (enabled)
        {
            Mixer.audioMixer.SetFloat("Master", 0);
        }
        else
        {
            Mixer.audioMixer.SetFloat("Master", -80);
        }
    }
    public void ChangeVolume(float volume)
    {
        musicVolume = PlayerPrefs.GetFloat("Sound");
PlayerPrefs.SetFloat("Sound", volume);
        PlayerPrefs.Save();
    }
    public void DeleteLevelProgress()
    {  //PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("level", 1);
        PlayerPrefs.SetInt("sublevel", 1);
        CurrentLevel = PlayerPrefs.GetInt("level");
        Debug.Log(CurrentLevel);
    }
    public void GoDonate()
    {
        Application.OpenURL("https://www.donationalerts.com/r/killryusha");
        }
    public void GoFeedBack()
    {
        Application.OpenURL("https://docs.google.com/document/d/1AjWrWzvJrj47w5I_yiGdG7hFz5jtE6nAlxFg2NlPaHQ/edit?usp=sharing");
    }

        //1.1=1level,1sublevel//1.2=1level,2sublevel
        void Update()
    {
        music.volume = musicVolume;

       // musicVolume 
        
    }
}
