using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int correctAnswer=0;
    int questionSeen=0;
    public int getCorrecAnswer(){
        return correctAnswer;
    }
    public void setCorrectAnswer(){
        correctAnswer++;
    }
     public int getQuestionSeen(){
        return questionSeen;
    }
    public void setQuestionSeen(){
        questionSeen++;
    }
    public int calculateScore(){
        return Mathf.RoundToInt(correctAnswer /(float) questionSeen *100);
    }
}
