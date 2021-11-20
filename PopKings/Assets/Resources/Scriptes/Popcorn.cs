using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popcorn : MonoBehaviour
{
    [SerializeField] private float price;
    private HpBar hpBar;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BlackHole")
        {
            BlackHoleBar bar = GameObject.FindGameObjectWithTag("BlackHoleBar").GetComponent<BlackHoleBar>();
            if (bar.nowbar + price < bar.maxBar)
            {
                bar.nowbar += price;
            }
            else
            {
                bar.nowbar = bar.maxBar;
            }

            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "ExitZone")
        {
            hpBar = GameObject.FindGameObjectWithTag("HpBar").GetComponent<HpBar>();
            if (hpBar.hp_delet < hpBar.hp_sprites.Length)
            {
                hpBar.hp_delet++;
            }

            Destroy(this.gameObject);
        }
    }
}
