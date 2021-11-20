using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelControll : MonoBehaviour
{
    private int CurrentLevel;
    void Awake()
    {
        CurrentLevel = PlayerPrefs.GetInt("LastSavedLevel");
        
        
        Debug.Log(CurrentLevel);
    }
    public void LevelCompleated()
    {   CurrentLevel++;
        PlayerPrefs.SetInt("LastSavedLevel", CurrentLevel);
        //CurrentLevel = PlayerPrefs.GetInt("LastSavedLevel");
        SceneManager.LoadScene(CurrentLevel);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
        // Start is called before the first frame update
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
