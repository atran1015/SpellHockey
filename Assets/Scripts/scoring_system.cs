using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoring_system : MonoBehaviour
{
    

    public int blueScore;
    public int redScore;
    
    public Text bluescoreTxt;
    public Text redscoreTxt;

    public int redhealth;
    public int redhealthbar;

    public Image[] redbar;
    public Sprite redbar2;

    public int bluehealth;
    public int bluehealthbar;

    public Image[] bluebar;
    public Sprite bluebar2;




    // Start is called before the first frame update

    void Start()
    {
        
        //bluescoreTxt.text = "B. Score: " + blueScore;
        //redscoreTxt.text = "R.score:" + redScore;
        redhealthbar = redhealth = 6;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("1"))
        {
            updateBluescore(1);
        }
        if (Input.GetKeyDown("2"))
        {
            updateRedscore(1);
        }
        updateRedHealthbar();
        updateBlueHealthbar();


        
    }
   

    public void updateBluescore(int score)
    {
        blueScore += score;

        bluescoreTxt.text = "B. Score; " + blueScore;

        redhealth -= 1;
        redhealthbar -= 1;
        
    }

    public void updateRedscore(int score)
    {
        redScore += score;

        redscoreTxt.text = "red. Score; " + redScore;
        bluehealth -= 1;

    }
    
    public void updateRedHealthbar()
    {

        switch (redhealth)
        {
            case 6:
                redbar[0].enabled = true; //only 100 sprite shwon
                redbar[1].enabled = false;
                redbar[2].enabled = false;
                redbar[3].enabled = false;
                redbar[4].enabled = false;
                redbar[5].enabled = false;
                break;
            case 5:
                redbar[0].enabled = false;
                redbar[1].enabled = true; 
                break;
            case 4:
                redbar[1].enabled = false;
                redbar[2].enabled = true; ;
                break;
            case 3:
                redbar[2].enabled = false;
                redbar[3].enabled = true; ;
                break;
            case 2:
                redbar[3].enabled = false;
                redbar[4].enabled = true; ;
                break;
            case 1:
                redbar[4].enabled = false;
                redbar[5].enabled = true; ;
                break;
            case 0:
                redbar[5].enabled = false;
                break;
        }

    }
    public void updateBlueHealthbar()
    {

        switch (bluehealth)
        {
            case 6:
                bluebar[0].enabled = true; //only 100 sprite shwon
                bluebar[1].enabled = false;
                bluebar[2].enabled = false;
                bluebar[3].enabled = false;
                bluebar[4].enabled = false;
                bluebar[5].enabled = false;
                break;
            case 5:
                bluebar[0].enabled = false;
                bluebar[1].enabled = true;
                break;
            case 4:
                bluebar[1].enabled = false;
                bluebar[2].enabled = true; ;
                break;
            case 3:
                bluebar[2].enabled = false;
                bluebar[3].enabled = true; ;
                break;
            case 2:
                bluebar[3].enabled = false;
                bluebar[4].enabled = true; ;
                break;
            case 1:
                bluebar[4].enabled = false;
                bluebar[5].enabled = true; ;
                break;
            case 0:
                bluebar[5].enabled = false;
                break;
        }
    }
}
