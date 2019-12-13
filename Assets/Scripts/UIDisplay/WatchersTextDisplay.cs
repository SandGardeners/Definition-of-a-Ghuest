using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchersTextDisplay : TextDisplay 
{
	public TextBox secondaryTextBox;

	private void Awake()
	{
        InkOverlord.tagsParser += LolOk;
	}
	protected override void Start()
	{
        base.Start();

        mainTextBox.finishedCallback = null;
        mainTextBox.newLineCallback = null;
		if(!mute && audioSource != null)
            secondaryTextBox.characterCallback += TryPlaySound;
		secondaryTextBox.finishedCallback = null;
		secondaryTextBox.newLineCallback = null;

        // Debug.Log("bonjour");
    }

    public override void ReadKnot(string knot)
    {
        CloseTextBox();
        secondaryTextBox.transform.parent.gameObject.SetActive(true);
        base.ReadKnot(knot);
        mainTextBox.transform.parent.gameObject.SetActive(false);
    }


    public override void PlayVoiceSound()
    {
        if(shouldBeRight)
            audioSource.PlayOneShot(inkOverlord.RightClips[Random.Range(0, inkOverlord.RightClips.Length)]);
        else
            audioSource.PlayOneShot(inkOverlord.LeftClips[Random.Range(0, inkOverlord.LeftClips.Length)]);
    }
    protected override bool IsAnyoneReading()
    {
        return mainTextBox._isReading || secondaryTextBox._isReading;
    }
	
	public override void CloseTextBox()
	{
        base.CloseTextBox();
        secondaryTextBox._isReading = false;
        secondaryTextBox.ReadLine("");
        mainTextBox.CurrentString = "";
        secondaryTextBox.CurrentString = "";
        secondaryTextBox.transform.parent.gameObject.SetActive(false);
        if(subscribed != null)
            subscribed();
    }
    public System.Action subscribed;
    void LolOk(string tagHead, string tagContent)
	{
        // Debug.Log(tagHead + " " + tagContent);
        if(tagHead == "w" && tagContent == "right")
            shouldBeRight = true;

    }

	protected override void HandleChoices()
	{
        mainTextBox.transform.parent.gameObject.SetActive(true);
        // RectTransform rt = mainTextBox.GetComponent<RectTransform>();
        // rt.sizeDelta = new Vector2(rt.sizeDelta.x, 0f);
        mainTextBox.gameObject.SetActive(false);
		
		base.HandleChoices();
    }
    bool shouldBeRight;
    protected override bool ReadNextLine()
    {
        SetName("", true);
        shouldBeRight = false;
        string line = inkOverlord.NextLine();
        // Debug.Log(line);
        if(line != string.Empty)
        {
			if(shouldBeRight)
            {
                secondaryTextBox.gameObject.SetActive(true);
	            secondaryTextBox.ReadLine(line);
            }
			else
			{
                mainTextBox.transform.parent.gameObject.SetActive(true);
                mainTextBox.gameObject.SetActive(true);
                mainTextBox.ReadLine(line);
			}
        }
		
        if(line != string.Empty)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}
