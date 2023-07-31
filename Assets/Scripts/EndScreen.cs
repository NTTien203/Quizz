using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EndScreen : MonoBehaviour
{
    
    [SerializeField] TextMeshProUGUI lastScore;
    ScoreKeeper scoreKeeper; 
    void Start()
    {
        scoreKeeper=FindObjectOfType<ScoreKeeper>();
    }
    public void showFinalScore(){
        lastScore.text="Congratulation!\n Your score:"+scoreKeeper.calculateScore()+"%";
    }

   
}
