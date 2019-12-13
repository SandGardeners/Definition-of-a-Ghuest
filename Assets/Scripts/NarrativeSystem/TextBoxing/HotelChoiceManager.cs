using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using UnityEngine;

public class HotelChoiceManager : ChoiceManager 
{

	public override void FeedChoices(List<Choice> choices)
	{
        for (int i = 0; i < choices.Count; i++)
        {
            Choice c = choices[i];
            // Debug.Log(c.fullPathStringOnChoice);
            TextBox b = InstantiateTextBox((i+1).ToString() + ". " + c.text);
            Vector3 tr = b.transform.parent.localPosition;
            tr.z = 0;
            b.transform.parent.localPosition = tr;
        }

        DisplayChoices();
    }

	private void Update()
	{
		if(IsBusy)
		{
            int choice = -1;
            if(UnityEngine.Input.GetKeyDown(KeyCode.Alpha1) || UnityEngine.Input.GetKeyDown(KeyCode.Keypad1))
			{
                choice = 0;
            }
			else if(UnityEngine.Input.GetKeyDown(KeyCode.Alpha2) || UnityEngine.Input.GetKeyDown(KeyCode.Keypad2))
			{
                choice = 1;
            }
			else if(UnityEngine.Input.GetKeyDown(KeyCode.Alpha3) || UnityEngine.Input.GetKeyDown(KeyCode.Keypad3))
			{
                choice = 2;
            }
            else if(UnityEngine.Input.GetKeyDown(KeyCode.Alpha4) || UnityEngine.Input.GetKeyDown(KeyCode.Keypad4))
			{
                choice = 3;
            }
            else if(UnityEngine.Input.GetKeyDown(KeyCode.Alpha5) || UnityEngine.Input.GetKeyDown(KeyCode.Keypad5))
			{
                choice = 4;
            }
			
			if(choice != -1 && choice < transform.childCount)
			{
				ClickableTextBox[] textBoxes = GetComponentsInChildren<ClickableTextBox>();
				if(textBoxes[choice]._isAvailable)
				{
                    textBoxes[choice].Input(choice);
                }
            }
		}
	}
}
