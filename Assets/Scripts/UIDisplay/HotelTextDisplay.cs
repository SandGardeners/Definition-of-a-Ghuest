using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotelTextDisplay : TextDisplay
{
    public float showFinishedText;
    public float hideTextFor;
    protected override void Start()
	{
        base.Start();
        mainTextBox.finishedCallback = null;
        mainTextBox.newLineCallback = null;
        mainTextBox.finishedCallback += TextFinished;
    }


	// public override void MadeChoice(int i)
    // {
    //     Debug.Log("OUI BONJOPURUURU");
    //     choiceManager.ClearChoices();
    //     inkOverlord.MakeChoice(i);
    //     madeChoice = true;
    //     mainTextBox.gameObject.SetActive(false);
    //     Invoke("ProcessText", hideTextFor);
    // }

	void TextFinished()
	{
        if(inkOverlord.canContinue)
		{
            // Debug.Log("OUIOUI3);");
            Invoke("HideText", showFinishedText);
		}
		else if(inkOverlord.hasChoices)
		{
            // Debug.Log("PORUP");
            Process();
		}
    }

    public override void Terminate()
    {
        CloseTextBox();
        // Debug.Log("Finished");
        inkOverlord.ResetStory();
        FindObjectOfType<HotelRoom>().playedAlready = true;
        Invoke("Reset", showFinishedText);
    }

	void Reset()
	{
        ReadKnot("START");
    }
	void HideText()
	{
        // mainTextBox.gameObject.SetActive(false);
        Invoke("ProcessText", hideTextFor);
    }

	void ProcessText()
	{
        // Debug.Log("ouioui");
        // mainTextBox.gameObject.SetActive(true);
        Process();
    }

	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Space) && IsAnyoneReading())
		{	
            Process();
        }	
	}
}
