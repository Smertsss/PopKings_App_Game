using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleBar : MonoBehaviour
{
    [SerializeField] private GameObject blackHoleBar;
    public float maxBar;
    public float nowbar;

    void Start()
    {
        nowbar = 0;
    }

    void Update()
    {
        blackHoleBar.transform.localScale = new Vector3((maxBar - (maxBar - nowbar)) / maxBar, blackHoleBar.transform.localScale.y, 0);
    }
}
