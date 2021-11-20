using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject level;
    [SerializeField] private GameObject customizeCell;
    [SerializeField] private GameObject continueButton;
    [SerializeField] private GameObject[] Skins;
    [SerializeField] private Text Stars;
    [SerializeField] private Text StarsLvl;
    public int stars = 0;
    bool stop = false;
    [SerializeField] private GameObject[] levels;

    private void Awake()
    {
       // stars = 0;
       
       
        PlayerPrefs.SetInt("maxlevel", levels.Length);

        //if (PlayerPrefs.GetInt("level") == PlayerPrefs.GetInt("maxlevel") && PlayerPrefs.GetInt("maxsublevel") == 6)
        //{
        //    continueButton.SetActive(false);
        //}
        
        
        level.SetActive(false);
        customizeCell.SetActive(false);

        if (PlayerPrefs.GetInt("first") == 0)
        {
            ResetPlayerPrefs();
        }
    }void Update()
    {
        if (stop == false)
        {
            for (int i = 1; i < levels.Length + 1; i++)
            {
                stars += PlayerPrefs.GetInt("LvlStars" + i);
                if (i == levels.Length )
                {
                    stop = true;
                }
            }
        }
        Stars.text = "";
        Stars.text = stars.ToString();
        StarsLvl.text = "";
        StarsLvl.text = stars.ToString();
    }
    public void Continue()
    {
        PlayerPrefs.SetInt("sublevel", 1);
        PlayerPrefs.SetInt("hp", 0);
        SceneManager.LoadScene(PlayerPrefs.GetInt("level"));
    }

    public void Back()
    {
        level.SetActive(false);
       
    }

    public void Level()
    {
        //menu.SetActive(false);
        level.SetActive(true);

        for (int levelId = 0; levelId < levels.Length; levelId++)
        {
            if (levelId <= PlayerPrefs.GetInt("level") - 1)
            {
                levels[levelId].SetActive(false);
            }
            else
            {
                levels[levelId].SetActive(true);
            }
        }
    }

    public void CustomizeCell()
    {
        menu.SetActive(false);
        customizeCell.SetActive(true);
    }

    public void Customize(string name)
    {
        PlayerPrefs.SetString("popcorn", name);
        PlayerPrefs.Save();
    }
    public void ShowCell(int ShowSkin)
    {
        for (int i = 0; i < Skins.Length; i++)
        {
            Skins[i].SetActive(false);
        }
        Skins[ShowSkin].SetActive(true);
    }


        public void GameOpen(int open)
    {
        PlayerPrefs.SetInt("sublevel", 1);
        PlayerPrefs.SetInt("hp", 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene(open);
    }

    public void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetString("popcorn", "Popcorn");
        PlayerPrefs.SetInt("first", 1);
        PlayerPrefs.SetInt("level", 1);
        PlayerPrefs.SetFloat("Sound", 1);
        stop = false;
        stars = 0;
        SceneManager.LoadScene(0);
    }
}
