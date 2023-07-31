using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Question")]
    [SerializeField] TextMeshProUGUI questionText;
     QuestionSO currentQuestion;
     [SerializeField] List<QuestionSO> question=new List<QuestionSO>();
    [Header("Answer")]
    [SerializeField] GameObject[] buttonAnswer; 
    public bool hasAnswerEarly;
    int correctAnswerindex;
    [Header("Button colors")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;
    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;
    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;
    [Header("Slider")]
    [SerializeField] Slider progressBar;
    public bool isComplete;

    void Start()
    {
        timer= FindObjectOfType<Timer>();
        scoreKeeper=FindObjectOfType<ScoreKeeper>();
        progressBar.maxValue=question.Count;
        progressBar.value=0;
        
    }
    private void Update() {
        timerImage.fillAmount=timer.fillFraction;
        if(timer.loadNextQuestion){
            if(progressBar.value==progressBar.maxValue){
            isComplete=true;
        }
            getNextQuestion();
            timer.loadNextQuestion=false;
        }else if(!hasAnswerEarly && !timer.isAnsweringQuestion){
            displayAnswer(-1);
            SetButtonState(false);
        }
    }
    public void displayQuestion(){
         questionText.text=currentQuestion.getQuestion();
        for(int i=0;i<4;i++){
        TextMeshProUGUI buttonText= buttonAnswer[i].GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text=currentQuestion.getAnswer(i);
        }
    }
     void SetButtonState(bool State){
        for(int i=0;i<buttonAnswer.Length;i++){
            Button button= buttonAnswer[i].GetComponent<Button>();
            button.interactable=State;
        }
    }
    void getNextQuestion(){
        if(question.Count>0){
        SetButtonState(true);
        getRandomQuestion();
        setDefaultSpriteQuestion();
        displayQuestion();
        scoreKeeper.setQuestionSeen();
        progressBar.value++;
        }
    }
    void getRandomQuestion(){
        int index=Random.Range(0,question.Count);
        currentQuestion=question[index];
        Debug.Log(index);
        if(question.Contains(currentQuestion))
        {
            question.Remove(currentQuestion);
        }
    }
    public void onAnswerSelected(int index){
        hasAnswerEarly=true;
        displayAnswer(index);
        SetButtonState(false);
        timer.cancelTimer();
        scoreText.text="Score:"+ scoreKeeper.calculateScore()+"%";
    
    }
    public void displayAnswer(int index){
        if(index==currentQuestion.getCorrectAnswerIndex())
        {
            questionText.text="Correct";
            Image ButtonImage= buttonAnswer[index].GetComponent<Image>();
            ButtonImage.sprite=correctAnswerSprite;
            scoreKeeper.setCorrectAnswer();
        }
        else
        {
                questionText.text="Answer:"+currentQuestion.getAnswer(currentQuestion.getCorrectAnswerIndex());
                Image ButtonImage= buttonAnswer[currentQuestion.getCorrectAnswerIndex()].GetComponent<Image>();
                ButtonImage.sprite=correctAnswerSprite;

        }
    }
    void setDefaultSpriteQuestion(){
        for(int i=0;i<buttonAnswer.Length;i++){
            Image ButtonImage= buttonAnswer[i].GetComponent<Image>();
            ButtonImage.sprite=defaultAnswerSprite;
        }
    }
    
}
