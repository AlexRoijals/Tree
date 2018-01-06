using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointBehaviourBlue : MonoBehaviour {

    public bool inPositionBlue;

    public Animator anim;

    // Use this for initialization
    void Start()
    {
        inPositionBlue = false;

    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            inPositionBlue = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inPositionBlue = false;
        }
    }

    void Update()
    {
        anim.SetBool("InPosition", inPositionBlue);
    }
}
