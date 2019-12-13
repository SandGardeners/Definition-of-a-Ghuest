using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplay : BaseDisplay {

    [HideInInspector]
    public InkOverlord inkOverlord;

    [SerializeField]
	public TextBox mainTextBox;

	[SerializeField]
	protected ChoiceManager choiceManager;

    [SerializeField]
    TextBox nameTextBox;

    public Image lineFinishedFeedback;

   // [SerializeField]
   // GameObject clickCatcher;

    // [SerializeField]
    // Fader fader;

    // [SerializeField]
    // bool introDone = false;

    public bool canSkip = true;
    public bool mute = false;
    protected AudioSource audioSource;
    protected virtual void Start () 
    {
        choiceManager.Input += MadeChoice;
        audioSource = GetComponent<AudioSource>();
        if(!mute && audioSource != null)
            mainTextBox.characterCallback += TryPlaySound;
        if(lineFinishedFeedback != null)
        {
            mainTextBox.finishedCallback += ShowLineFinished;
            mainTextBox.newLineCallback += HideLineFinished;
        }
    }
    void ShowLineFinished()
    {
        lineFinishedFeedback.gameObject.SetActive(true);
        StartCoroutine("FadeLineFinished");
    }
    Color transparent = new Color(0,0,0,0);
    IEnumerator FadeLineFinished()
    {
        float timer = 0;
        int sens = 1;
        while(true)
        {
            timer += Time.deltaTime*sens;
            float ratio = timer/0.5f;
            if(ratio > 1 || ratio < 0)
            {
                sens *= -1;
            }

            lineFinishedFeedback.color = Color.Lerp(transparent, Color.white, Utilities.Ease.sineInOut(ratio));
            yield return new WaitForEndOfFrame();
        }
    }


    void HideLineFinished()
    {
        lineFinishedFeedback.color = transparent;
        lineFinishedFeedback.gameObject.SetActive(false);
        StopCoroutine("FadeLineFinished");
    }

    public void Mute()
    {
        mute = true;
    }
    public virtual void PlayVoiceSound()
    {
        // Debug.Log("okimhere");
        if(previousName != string.Empty)
        {
            //TODO:audioSource.PlayOneShot(interfaceManager.GetVoiceClip(previousName),0.15f);
        }
    }

    public virtual void ReadKnot(string knot)
    {
        inkOverlord.RequestKnot(knot);
    //    clickCatcher.SetActive(true);
        mainTextBox.transform.parent.gameObject.SetActive(true);
        Process();
    }

    protected virtual bool ReadNextLine()
    {
        SetName("", true);
        string line = inkOverlord.NextLine();
        if(line != string.Empty)
        {
            mainTextBox.ReadLine(tempDelay,tempRatio, line);
        }
        tempDelay = 0f;
        tempRatio = 1f;
        if(line != string.Empty)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    protected bool madeChoice = false;
    public virtual void MadeChoice(int i)
    {
        choiceManager.ClearChoices();
        inkOverlord.MakeChoice(i);
        madeChoice = true;
        Process();   
    }

    protected virtual bool IsAnyoneReading()
    {
        return mainTextBox._isReading;
    }
    
    public override void Process()
    {
        if (!choiceManager.IsBusy || madeChoice)
        {
            madeChoice = false;
            if(IsAnyoneReading())
            {
                if(canSkip)
                {
                    mainTextBox.DisplayImmediate();
                }

            }
            else if (inkOverlord.canContinue)
            {
                if(!ReadNextLine())
                {
                    Terminate();
                }
            }
            else if (inkOverlord.hasChoices)
            {
                HandleChoices();
            }
            else
            {
                Terminate();
            }
        }
        else if(canSkip)
        {
            choiceManager.DisplayImmediate();
        }  
    }

    protected virtual void HandleChoices()
    {
        
                choiceManager.FeedChoices(inkOverlord.GetChoices());
                choiceManager.DisplayChoices();
    }

    float tempDelay = 0f;
    float tempRatio = 1f;
    public void SetDelay(float textDelay)
    {
        tempDelay = textDelay;
    }

    public void SetSpeed(float textSpeed)
    {
        tempRatio = textSpeed;
    }

    public override void Terminate()
    {
        CloseTextBox();
        base.Terminate();
    }

    string previousName = "";
    public void SetName(string name, bool immediate)
    {
        nameTextBox.transform.parent.gameObject.SetActive(name != string.Empty);
        if(name != string.Empty && name != previousName)
        {
            RectTransform parent = nameTextBox.transform.parent.GetComponent<RectTransform>();
            parent.sizeDelta = nameTextBox.GetComponent<RectTransform>().sizeDelta = new Vector2(name.Length * 25f, parent.sizeDelta.y);
            nameTextBox.ReadLine(0f, 0f, name);
           // nameTextBox.DisplayImmediate();
        }
        previousName = name;
    }

    public virtual void CloseTextBox()
    {
        nameTextBox.ReadLine("");
        mainTextBox.ReadLine("");
        mainTextBox._isReading = false;
        choiceManager.ClearChoices();
        nameTextBox.transform.parent.gameObject.SetActive(false);
        mainTextBox.transform.parent.gameObject.SetActive(false);
    }

    protected float timer = 0f;
    public float sfxDelay = 0.01f;

    protected void TryPlaySound()
    {
        // Debug.Log("Trying to talk");
        if (audioSource != null)
        {
            // Debug.Log(timer + " - " + sfxDelay);
            if (timer > sfxDelay)
            {
                    timer = 0f;
                    PlayVoiceSound();
            }
        }
    }

    void Update()
    {
       timer += Time.deltaTime;
    }

    void RemoveTrigger()
    {
     //   clickCatcher.SetActive(false);
    }

    void RemoveBackground()
    {
        // introDone = true;
        // fader.allBlackDelegate -= RemoveBackground;
   //     clickCatcher.SetActive(false);
    }

    /*
public InputField inputField;

public void OpenInputField()
{
   inputField.gameObject.SetActive(true);
   inputField.Select();
   inputField.ActivateInputField();
}
*/
}
