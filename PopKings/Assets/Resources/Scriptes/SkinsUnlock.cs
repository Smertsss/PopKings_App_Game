using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinsUnlock : MonoBehaviour
{   [SerializeField]private GameObject Chain;
    [SerializeField] private Text StarsNeed;
    [SerializeField]
    private Menu menu;
    [SerializeField]

    private int Need;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { StarsNeed.text = Need.ToString();
        
        if (menu.stars >= Need)
        {
            Chain.SetActive(false);
        }
    }
        
    
}
