using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBehaviour : MonoBehaviour {

    //Tree states //Red //Green //Blue

    public bool positionRed;
    public bool positionGreen;
    public bool positionBlue;

    public PointBehaviourBlue pointBlue;
    public PointBehaviourRed pointRed;
    public PointBehaviourGreen pointGreen;

    public GameObject RedParticle;
    public GameObject GreenParticle;
    public GameObject BlueParticle;
    public GameObject GrayParticle;

    public Animator anim;

    // Use this for initialization
    void Start ()
    {
        positionBlue = false;
        positionGreen = false;
        positionRed = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        positionBlue = pointBlue.inPositionBlue;
        positionGreen = pointGreen.inPositionGreen;
        positionRed = pointRed.inPositionRed;

        
        if (positionRed == true)
        {
            RedParticle.SetActive(true);
            GreenParticle.SetActive(false);
            BlueParticle.SetActive(false);
            GrayParticle.SetActive(false);
        }
        else if (positionGreen == true)
        {
            RedParticle.SetActive(false);
            GreenParticle.SetActive(true);
            BlueParticle.SetActive(false);
            GrayParticle.SetActive(false);
        }
        else if (positionBlue == true)
        {
            RedParticle.SetActive(false);
            GreenParticle.SetActive(false);
            BlueParticle.SetActive(true);
            GrayParticle.SetActive(false);
        }
        else
        {
            RedParticle.SetActive(false);
            GreenParticle.SetActive(false);
            BlueParticle.SetActive(false);
            GrayParticle.SetActive(true);
        }

        anim.SetBool("PositionRed", positionRed);
        anim.SetBool("PositionGreen", positionGreen);
        anim.SetBool("PositionBlue", positionBlue);
    }
}
