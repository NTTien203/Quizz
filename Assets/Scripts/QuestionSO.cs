using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Quiz Question",fileName ="new Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2,6)]
    [SerializeField] string Question="Enter new question here";
    [SerializeField] string[] answers=new string[4];
    [SerializeField] int correctAnswerindex;
    public string getQuestion(){
        return Question;
    }
    public int getCorrectAnswerIndex(){
        return correctAnswerindex;
    }
    public string getAnswer(int index){
        return answers[index];
    }
}
   
