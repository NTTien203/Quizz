using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    Quiz quiz;
    EndScreen endScreen;
    void Start()
    {
        quiz=FindObjectOfType<Quiz>();
        endScreen=FindObjectOfType<EndScreen>();
        quiz.gameObject.SetActive(true);
        endScreen.gameObject.SetActive(false);
    }

    
    void Update()
    {
        Switcher();
    }
    void Switcher(){
        if(quiz.isComplete==true){
             quiz.gameObject.SetActive(false);
            endScreen.gameObject.SetActive(true);
            endScreen.showFinalScore();
        }
    }
    public void onReplayLevel(){
        SceneManager.LoadScene(0);
    }
}
