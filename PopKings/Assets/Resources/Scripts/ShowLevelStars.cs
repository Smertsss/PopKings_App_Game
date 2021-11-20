using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLevelStars : MonoBehaviour
{
    [SerializeField] private GameObject[] StarsHave;
    [SerializeField] private int Level;
    void Update()
    { int SetStars;
        SetStars=PlayerPrefs.GetInt("LvlStars" + Level);
        for(int i = 0; i < SetStars; i++)
        {
            StarsHave[i].SetActive(true);
        }
    }

}
