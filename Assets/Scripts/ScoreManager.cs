using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    int score;
    public Text scoreText;
   public void Score(int value)
    {
        score=score+value;
        scoreText.text = "Score" + score;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
