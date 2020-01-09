using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizGameManager : MonoBehaviour
{
    public Questions[] questions;
    public Questions currentQuestion;
    public ScoreControl score = new ScoreControl();
    public LifeControl life = new LifeControl();
    public SuccesStepControl succesStep = new SuccesStepControl();
    public GameTimer timerObj = new GameTimer();
    private Image backgroundPanel;
    private static List<Questions> unansweredQuestions;
    public GameObject trueAnswerLayer1, trueAnswerLayer2, trueAnswerLayer3, trueAnswerLayer4;
    public GameObject falseAnswerLayer1, falseAnswerLayer2, falseAnswerLayer3, falseAnswerLayer4;               

    [SerializeField]
    private Text questionTxt;
    [SerializeField]
    private Text firstButtonText, secondButtonText, thirdButtonText, fourthButtonText; 
    
    private readonly float timeBetweenQuestions = 1f;        
    private int isTrue;    
    Color bgColor = new Color(.2f, .17f, .17f);

    void Start()
    {        
        life.UpdateLifeDisplay();
        score.UpdateScoreDisplay();
        LoadQuestionsFromFile();
        SetBackgroundColor();        
        SetCurrentQuestion();
        timerObj.SetNewTime();
        timerObj.minusLifeTimeCounter = 0;
    }

    void Update()
    {
        timerObj.UpdateTimer();

        if (timerObj.IsZero())
        {
            timerObj.minusLifeTimeCounter += Time.deltaTime;
            if (timerObj.minusLifeTimeCounter > timerObj.minusLifeTime) {
                
                life.DecrementLifeCounter();
                timerObj.minusLifeTimeCounter = 0;
            }
            
            if (LifeControl.LifeCounter == 0f)
                TransitionToGameOver();                
        }
    }
    
//useful methods
    void SetCurrentQuestion()
    {
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];
        questionTxt.text = currentQuestion.questionText;
        SetTextOnButton();

        unansweredQuestions.RemoveAt(randomQuestionIndex);        
    }

    public void SetTextOnButton()
    {
        
        List<string> tempAnswerList = new List<string>(){
            currentQuestion.rightOption,
            currentQuestion.secondOption,
            currentQuestion.thirdOption,
            currentQuestion.fourthOption
        };
                       
        int randomNumberForQuestionLoss = 0;        
        bool rightIsSet = false;

        for (int i=0; i <4; i++)
        {
            
            randomNumberForQuestionLoss = Random.Range(0, tempAnswerList.Count); 
             
            if (i == 0)
            {
                firstButtonText.text = tempAnswerList[randomNumberForQuestionLoss];
                tempAnswerList.RemoveAt(randomNumberForQuestionLoss);

                if (randomNumberForQuestionLoss == 0 && !rightIsSet)
                {
                    isTrue = i + 1;
                    rightIsSet = true;
                }
            }
            else if (i == 1)
            {
                secondButtonText.text = tempAnswerList[randomNumberForQuestionLoss];
                tempAnswerList.RemoveAt(randomNumberForQuestionLoss);

                if (randomNumberForQuestionLoss == 0 && !rightIsSet)
                {
                    isTrue = i + 1;
                    rightIsSet = true;
                }
            }
            else if (i == 2)
            {
                thirdButtonText.text = tempAnswerList[randomNumberForQuestionLoss];
                tempAnswerList.RemoveAt(randomNumberForQuestionLoss);

                if (randomNumberForQuestionLoss == 0 && !rightIsSet)
                {
                    isTrue = i + 1;
                    rightIsSet = true;
                }
            }
            else if (i == 3)
            {
                fourthButtonText.text = tempAnswerList[randomNumberForQuestionLoss];
                tempAnswerList.RemoveAt(randomNumberForQuestionLoss);

                if (randomNumberForQuestionLoss == 0 && !rightIsSet)
                {
                    isTrue = i + 1;
                    rightIsSet = true;
                }
            }


        }              
                                
    }

    public void SetBackgroundColor()
    {
        bgColor[0] = 0.16f + ((5 - LifeControl.LifeCounter) * 0.04f);
        backgroundPanel = GameObject.Find("Background").GetComponent<Image>();
        backgroundPanel.color = bgColor;
    }

// methods controled buttons
    public void SelectFirstButton() {
        if (isTrue == 1)
        {            
            score.AddAndUpdate();
            succesStep.IncrementSuccess();
            trueAnswerLayer1.SetActive(true);
            Debug.Log("CORRECT!");
        }
        else
        {
            life.DecrementLifeCounter();
            falseAnswerLayer1.SetActive(true);
            MarkRightOption();            
            succesStep.SetSuccessSeriesOnZero();           

            Debug.Log("WRONG! , ");
            if (LifeControl.LifeCounter == 0)
            {
                TransitionToGameOver();
                Debug.Log("GameOver!");
            }
        }
            
        StartCoroutine(TransitionToNextQuestion());
    }

    public void SelectSecondButton()
    {
        if (isTrue == 2)
        {            
            score.AddAndUpdate();
            succesStep.IncrementSuccess();
            trueAnswerLayer2.SetActive(true);
            Debug.Log("CORRECT!");
        }
        else
        {
            life.DecrementLifeCounter();
            Debug.Log("WRONG!");
            falseAnswerLayer2.SetActive(true);
            MarkRightOption();
            succesStep.SetSuccessSeriesOnZero();

            if (LifeControl.LifeCounter == 0)
            {
                TransitionToGameOver();
                Debug.Log("GameOver!");
            }
        }

        StartCoroutine(TransitionToNextQuestion());
    }

    public void SelectThirdButton()
    {
        if (isTrue == 3)
        {            
            score.AddAndUpdate();
            succesStep.IncrementSuccess();
            trueAnswerLayer3.SetActive(true);
            Debug.Log("CORRECT!");
        }            
        else
        {
            life.DecrementLifeCounter();
            falseAnswerLayer3.SetActive(true);
            MarkRightOption();
            succesStep.SetSuccessSeriesOnZero();
            Debug.Log("WRONG!");

            if (LifeControl.LifeCounter == 0)
            {
                TransitionToGameOver();
                Debug.Log("GameOver!");
            }
        }

        StartCoroutine(TransitionToNextQuestion());        
    }

    public void SelectFourthButton()
    {
        if (isTrue == 4)
        {
            Debug.Log("CORRECT!");
            score.AddAndUpdate();
            succesStep.IncrementSuccess();
            trueAnswerLayer4.SetActive(true);
        }
        else
        {
            life.DecrementLifeCounter();
            falseAnswerLayer4.SetActive(true);
            MarkRightOption();
            succesStep.SetSuccessSeriesOnZero();

            Debug.Log("WRONG!");
            if (LifeControl.LifeCounter == 0)
            {
                TransitionToGameOver();
                Debug.Log("GameOver!");
            }
        }

        StartCoroutine(TransitionToNextQuestion());
    }

// controling life marks    

    private void MarkRightOption()
    {
        switch (isTrue)
            {
            case 1:
                trueAnswerLayer1.SetActive(true);
                break;
            case 2:
                trueAnswerLayer2.SetActive(true);
                break;
            case 3:
                trueAnswerLayer3.SetActive(true);
                break;
            case 4:
                trueAnswerLayer4.SetActive(true);
                break;
            default:
                break;
        }
    }

    IEnumerator TransitionToNextQuestion()
    {
        unansweredQuestions.Remove(currentQuestion);

        yield return new WaitForSeconds(timeBetweenQuestions);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void TransitionToGameOver()
    {
        unansweredQuestions.Remove(currentQuestion);
        SceneManager.LoadScene("GameOverScene");
    }

    public void LoadQuestionsFromFile()
    {
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            questions = QuestionUtils.LoadQuestionFile();
            if (questions == null)
                Debug.Log("No guestions in memory");
            unansweredQuestions = questions.ToList<Questions>();
        }
    }
}
