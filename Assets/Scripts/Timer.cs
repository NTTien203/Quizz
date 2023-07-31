using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion=30f;
    [SerializeField] float timetoShowCorrectAnswer=10f;
    public bool isAnsweringQuestion;
    public bool loadNextQuestion;
    float timeValue;
    public float fillFraction;

    void Update()
    {
        updateTimer();
    }
    void updateTimer(){
        timeValue-=Time.deltaTime;
       if(isAnsweringQuestion)
       {
        if(timeValue>0){
            fillFraction=timeValue/timeToCompleteQuestion;
        }
        if(timeValue<=0){
            timeValue=timetoShowCorrectAnswer;
            isAnsweringQuestion=false;
        }  
        
       }else {
        if(timeValue>0){
            fillFraction=timeValue/timetoShowCorrectAnswer;
        }
        if(timeValue<=0){
            timeValue=timeToCompleteQuestion;
            isAnsweringQuestion=true;
            loadNextQuestion=true;
        }
       }

       
    }
    public void cancelTimer(){
        timeValue=0;
    }
}
