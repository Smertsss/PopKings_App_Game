using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hat : MonoBehaviour
{
    [SerializeField] private float length;
    public bool respavn = false;
    public GameObject cell;
    [SerializeField]
    private Animator CannonAnim;

    void Update()
    {
        if (respavn)
        {
            cell.transform.position = transform.position + transform.forward / length + new Vector3(Random.Range(-0.1f, 0.1f), -0.1f, 0);
            Instantiate(cell);
            CannonAnim.SetBool("Shoot", true);
        }else
        CannonAnim.SetBool("Shoot", false);
        Debug.Log(CannonAnim.GetBool("Shoot"));
    }
}
