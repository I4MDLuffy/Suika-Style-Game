using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    public int score = 0000;
    public TextMeshProUGUI text;
    void Start()
    {
        text.text = score.ToString();
    }
    public void AddToScore(int s)
    {
        if(s == 0)
        {
            score += 1;
        }else if(s == 1)
        {
            score += 3;
        }else if(s == 2)
        {
            score += 6;
        }else if(s ==  3)
        {
            score += 10;
        }else if(s == 4)
        {
            score += 15;
        }else if(s == 5)
        {
            score += 21;
        }else if(s == 6)
        {
            score += 28;
        }else if(s == 7)
        {
            score += 36;
        }else if(s == 8)
        {
            score += 45;
        }else if(s == 9)
        {
            score += 55;
        }else if(s == 10)
        {
            score += 66;
        }else 
        {

        }
        text.text = score.ToString();
        
    }
    void ResetScore()
    {
        score = 0;
        text.text = score.ToString();
    }

}
