using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputScreen : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private GameObject[] platform;
    private GameObject[] hats;
    private GameObject menu;
    private GameObject cell;
[SerializeField] private bool HoleLvl;
    [SerializeField] private Sprite NowProgress;//цвет куружков прогресса
    [SerializeField] private Sprite NextProgress;
    [SerializeField] private Image[] ProgressBar;
    [SerializeField] private Animator TapToFill;
    [SerializeField] private GameObject[] Star;
    [SerializeField] private GameObject[] HideWhenLevelIsCompleted;
    

    private HpBar hpBar;
    private BlackHoleBar blackHoleBar;

    private void Awake()
    {
        Debug.Log("dxjfkcly" + PlayerPrefs.GetInt("LvlStars" + SceneManager.GetActiveScene().buildIndex));
        cell = Resources.Load<GameObject>("Prefab/" + PlayerPrefs.GetString("popcorn"));
        hats = GameObject.FindGameObjectsWithTag("Hat");
        menu = GameObject.FindGameObjectWithTag("Menu");
        hpBar = GameObject.FindGameObjectWithTag("HpBar").GetComponent<HpBar>();
        for (int hatId = 0; hatId < hats.Length; hatId++)
        {
            Hat hat = hats[hatId].GetComponent<Hat>();
            hat.cell = cell;
        }

        // открытие уровня
        if (PlayerPrefs.GetInt("level") < SceneManager.GetActiveScene().buildIndex)
        {
            PlayerPrefs.SetInt("level", SceneManager.GetActiveScene().buildIndex);
        }

        // для первого раза + мини проверка.
        if (PlayerPrefs.GetInt("sublevel") < 1 || 7 < PlayerPrefs.GetInt("sublevel"))
        {
            PlayerPrefs.SetInt("sublevel", 1);
        }

        // монеты
        if (PlayerPrefs.GetInt("sublevel") == 6)
        {
            for (int close = 0; close < HideWhenLevelIsCompleted.Length; close++)
            {
                HideWhenLevelIsCompleted[close].SetActive(false);
            }

            int stars = 0;
            if (PlayerPrefs.GetInt("hp") < 6)
            {
                stars = 1;
                Star[0].SetActive(true);
            }
            else if (6 <= PlayerPrefs.GetInt("hp") && PlayerPrefs.GetInt("hp") <= 12)
            {
                stars = 2;
                Star[0].SetActive(true);
                Star[1].SetActive(true);
            }
            else if (13 <= PlayerPrefs.GetInt("hp") && PlayerPrefs.GetInt("hp") <= 15)
            {
                stars = 3;
                Star[0].SetActive(true);
                Star[1].SetActive(true);
                Star[2].SetActive(true);
            }Debug.Log("Stars"+ PlayerPrefs.GetInt("hp"));
            
            PlayerPrefs.SetInt("stars", PlayerPrefs.GetInt("stars")+ stars);
            if (stars > PlayerPrefs.GetInt("LvlStars" + SceneManager.GetActiveScene().buildIndex))
            {
                PlayerPrefs.SetInt("LvlStars" + SceneManager.GetActiveScene().buildIndex, stars);
            }
        }

            // переход
            if (PlayerPrefs.GetInt("sublevel") == 7)
        {
            PlayerPrefs.Save();
            PlayerPrefs.SetInt("hp", 0);
            if (PlayerPrefs.GetInt("level") == PlayerPrefs.GetInt("maxlevel"))
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                PlayerPrefs.SetInt("sublevel", 1);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }

        for (int platformId = 0; platformId < platform.Length; platformId++)
        {
            if (platformId == PlayerPrefs.GetInt("sublevel") - 1)
            {
                platform[platformId].SetActive(true);
            }
            else
            {
                platform[platformId].SetActive(false);
            }
        }
        if (PlayerPrefs.GetInt("sublevel") < 6)
        {
            for (int prog = 1; prog < PlayerPrefs.GetInt("sublevel"); prog++)
            {
                ProgressBar[prog - 1].sprite = NowProgress;
            }
        }
    }

    void Update()
    {
       
        if (PlayerPrefs.GetInt("sublevel") < 6)
        {
            int prog = PlayerPrefs.GetInt("sublevel") - 1;
            if (prog > 0)
            {
                ProgressBar[prog - 1].sprite = NowProgress;
            }
            ProgressBar[prog].sprite = NextProgress;




            if (HoleLvl == true)
            {
                blackHoleBar = GameObject.FindGameObjectWithTag("BlackHoleBar").GetComponent<BlackHoleBar>();
            }
            if (Input.touchCount > 0)
            {
                TapToFill.SetBool("Hide", true);
                for (int touch = 0; touch < Input.touches.Length; touch++)
                {
                    float positionTouch = Mathf.Pow((Input.touches[touch].position.x - menu.transform.position.x), 2) + Mathf.Pow((Input.touches[touch].position.y - menu.transform.position.y), 2);
                    if (Mathf.Pow(radius, 2) < positionTouch)
                    {
                        for (int hatId = 0; hatId < hats.Length; hatId++)
                        {
                            Hat hat = hats[hatId].GetComponent<Hat>();
                            hat.respavn = true;

                        }
                    }
                    else
                    {
                        for (int hatId = 0; hatId < hats.Length; hatId++)
                        {
                            Hat hat = hats[hatId].GetComponent<Hat>();
                            hat.respavn = false;

                        }
                    }
                }
            }
            else
            {
                TapToFill.SetBool("Hide", false);
                for (int hatId = 0; hatId < hats.Length; hatId++)
                {
                    Hat hat = hats[hatId].GetComponent<Hat>();
                    hat.respavn = false;
                }
            }
            if (HoleLvl == true)
            {
                if (blackHoleBar.nowbar == blackHoleBar.maxBar)
                {
                    PlayerPrefs.SetInt("sublevel", PlayerPrefs.GetInt("sublevel") + 1);
                    PlayerPrefs.SetInt("hp", PlayerPrefs.GetInt("hp") + (hpBar.hp_sprites.Length - hpBar.hp_delet));
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
            if (hpBar.hp_delet == hpBar.hp_sprites.Length)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }


    public void ReStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    // следующий уровень
    public void Next()
    {
        PlayerPrefs.SetInt("sublevel", PlayerPrefs.GetInt("sublevel") + 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // переход в меню
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}