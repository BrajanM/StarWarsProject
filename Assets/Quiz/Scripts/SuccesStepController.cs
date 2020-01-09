using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class SuccesStepControl
{
    public static int SuccessSerie=0;   
    public Text SuccessMarkingLayer;    
    private Image AnimatedImage;
    private Animator clip;

    protected const string SMALL_SUCCESS_TEXT = "DOBRZE !";
    protected const string BIG_SUCCESS_TEXT = "Dobra robota!";
    protected const string GREAT_SUCCESS_TEXT = "Wymiatasz!";
    protected const string REALLY_GREAT_SUCCESS_TEXT = "Lepiej się nie da!";

    const int SMALL_SUCCESS_NUMBER = 3;
    const int BIG_SUCCESS_NUMBER = 5;
    const int GREAT_SUCCESS_NUMBER = 10;
    const int REALLY_GREAT_SUCCESS_NUMBER = 20;

    public void IncrementSuccess()
    {
        SuccessSerie ++; 
        if (IsMarking())
        {
            MarkSuccesStep();
        }
    }

    public void SetSuccessSeriesOnZero()
    {
       SuccessSerie = 0;
    }
    
    private void SetRightText() {
        switch (SuccessSerie)
        {
            case SMALL_SUCCESS_NUMBER:
                SuccessMarkingLayer.text = SMALL_SUCCESS_TEXT;
                break;
            case BIG_SUCCESS_NUMBER:
                SuccessMarkingLayer.text = BIG_SUCCESS_TEXT;
                break;
            case GREAT_SUCCESS_NUMBER:
                SuccessMarkingLayer.text = GREAT_SUCCESS_TEXT;
                break;
            case REALLY_GREAT_SUCCESS_NUMBER:
                SuccessMarkingLayer.text = REALLY_GREAT_SUCCESS_TEXT;
                break;
            default:
                SuccessMarkingLayer.text = " ";
                break;
        }
    }

    private bool IsMarking() {
        if (SuccessSerie == SMALL_SUCCESS_NUMBER || SuccessSerie == BIG_SUCCESS_NUMBER || 
            SuccessSerie == GREAT_SUCCESS_NUMBER || SuccessSerie == REALLY_GREAT_SUCCESS_NUMBER)
            return true;
        else
            return false;
    }

    private void MarkSuccesStep() {
        switch (SuccessSerie)
        {
            case SMALL_SUCCESS_NUMBER:
                MarkSmallSuccess();
                break;
            case BIG_SUCCESS_NUMBER:
                MarkBigSucces();
                break;
            case GREAT_SUCCESS_NUMBER:
                MarkGreatSucces();
                break;
            case REALLY_GREAT_SUCCESS_NUMBER:
                MarkReallyGreatSucces();
                break;

            default:
                break;
        }

    }

    public void MarkSmallSuccess()
    {
        SetRightText();
        SuccessMarkingLayer.enabled = true;
        AnimatedImage = GameObject.Find("FirstSuccesImage").GetComponent<Image>();
        clip = AnimatedImage.GetComponent<Animator>();
        clip.enabled = true;
    }

    //TODO
    public void MarkBigSucces()
    {
        SetRightText();
        SuccessMarkingLayer.enabled = true;
        AnimatedImage = GameObject.Find("BlueLightBlade").GetComponent<Image>();
        clip = AnimatedImage.GetComponent<Animator>();
        clip.enabled = true;
    }
 
    public void MarkGreatSucces()
    {
        SetRightText();
        SuccessMarkingLayer.enabled = true;
        AnimatedImage = GameObject.Find("GreatSuccessImage").GetComponent<Image>();
        clip = AnimatedImage.GetComponent<Animator>();
        clip.enabled = true;
    }

    public void MarkReallyGreatSucces()
    {
        SetRightText();
        SuccessMarkingLayer.enabled = true;
        AnimatedImage = GameObject.Find("ReallyGreatSuccessImage").GetComponent<Image>();
        AnimatedImage.enabled = true;
        clip = AnimatedImage.GetComponent<Animator>();
        clip.enabled = true;

    }
}
