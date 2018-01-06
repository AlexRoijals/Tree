using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointBehaviourRed : MonoBehaviour
{

    public bool inPositionRed;

    public Animator anim;

    // Use this for initialization
    void Start()
    {
        inPositionRed = false;

    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            inPositionRed = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inPositionRed = false;
        }
    }
    void Update()
    {
        anim.SetBool("InPosition", inPositionRed);
    }
}