using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    [SerializeField] public Image[] hp_sprites;
    public int hp_delet = 0;

    [SerializeField] private Sprite alive;
    [SerializeField] private Sprite die;
    [SerializeField] private AudioSource myFx;
    [SerializeField] private AudioClip Lose;

    void Start()
    {
        for (int hp_sprite = 0; hp_sprite < hp_sprites.Length; hp_sprite++)
        {
            // я хз как сделать картинку
             hp_sprites[hp_sprite].sprite = alive;
        }
    }

    void Update()
    {
        for (int hp_sprite = hp_sprites.Length-1; hp_sprite > hp_sprites.Length - hp_delet-1; hp_sprite--)
        {Debug.Log("Img"+hp_sprite);
            // я хз как сделать картинку
            hp_sprites[hp_sprite].sprite = die;
            myFx.PlayOneShot(Lose);

        }
    }
}