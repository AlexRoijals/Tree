using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointBehaviourGreen : MonoBehaviour {

    public bool inPositionGreen;

    public Animator anim;

    // Use this for initialization
    void Start()
    {
        inPositionGreen = false;

    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            inPositionGreen = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inPositionGreen = false;
        }
    }

    void Update()
    {
        anim.SetBool("InPosition", inPositionGreen);
    }
}
