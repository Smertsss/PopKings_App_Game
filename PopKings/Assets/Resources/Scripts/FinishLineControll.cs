using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineControll : MonoBehaviour
{
    public bool getIn = true;
    public bool getOut = false;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Popcorn"))
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 100, 0, 100);
            getIn = true;
            getOut = false;
        }
        
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Popcorn"))
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(100, 100, 100, 100);
            getOut = true;
            getIn = false;
        }  
    }
}
