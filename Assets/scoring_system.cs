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
    
    // Start is called before the first frame update
    
    void Start()
    {
        bluescoreTxt.text = "B. Score: " + blueScore;
        redscoreTxt.text = "R.score:" + redScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void updateBluescore(int score)
    {
        blueScore += score;

        bluescoreTxt.text = "B. Score; " + blueScore;
    }

    public void updateRedscore(int score)
    {
        redScore += score;

        redscoreTxt.text = "red. Score; " + redScore;
    }
}
