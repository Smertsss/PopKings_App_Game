using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishLineSystem : MonoBehaviour
{
    //колличество пересечённых линий победы
    private int a=0;
    private GameObject[] finishline;
    private float timeLeft;
    private bool goTime=false;
    [SerializeField] private Image LevelTimerProgress;
    [SerializeField] private GameObject LevelTimer;
    [SerializeField] private GameObject Mark;
    private HpBar hpBar;
    void Awake()
    {
        LevelTimer.SetActive(false);
        Mark.SetActive(false);
        hpBar = GameObject.FindGameObjectWithTag("HpBar").GetComponent<HpBar>();
       
    }
    void Start()
    {  finishline = GameObject.FindGameObjectsWithTag("FinishLine");
    }

        private void Update()
    {
        a = 0;
         Debug.Log(timeLeft);
        Debug.Log("Длина массива "+finishline.Length);
        

        for(int lineId = 0; lineId < finishline.Length; lineId++)
        {
            FinishLineControll check = finishline[lineId].GetComponent<FinishLineControll>();
            if (check.getIn && !check.getOut)
            {
                a++;
                Debug.Log("A="+a);
            }
        }
         void TimerProgress()
        {

        }

        if (a == finishline.Length&& finishline.Length!=0)
        {
           goTime=true;

        }
        else
        {
            timeLeft = 0;
            goTime = false;
            LevelTimer.SetActive(false);
        }

        if (goTime==true)
        {
            timeLeft += Time.deltaTime;
            LevelTimer.SetActive(true);
            float progress = timeLeft / 5;
            LevelTimerProgress.fillAmount = progress;
        }
        else
        {
            timeLeft = 0;
            LevelTimer.SetActive(false);
        }

        if (timeLeft >= 5)
        {
            Mark.SetActive(true);
            
        }
        if (timeLeft >= 5.5)
        {PlayerPrefs.SetInt("hp", PlayerPrefs.GetInt("hp") + (hpBar.hp_sprites.Length - hpBar.hp_delet));
            PlayerPrefs.SetInt("sublevel", PlayerPrefs.GetInt("sublevel") + 1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
        }
        if (PlayerPrefs.GetInt("sublevel") == 6)
        {
            LevelTimer.SetActive(false);
        }
    }
}
