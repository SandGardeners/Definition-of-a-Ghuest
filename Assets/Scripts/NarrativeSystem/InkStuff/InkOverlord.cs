using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using System;

public class InkOverlord : MonoBehaviour
{
    public List<Choice> GetChoices()
    {   
        return inkStory.currentChoices;
    }

    public TextAsset storyScript;
    Story inkStory;
    public string GetCurrentPath()
    {
        return lastPath;
    }
    public static Action<string, string> tagsParser;
    public void ChangeVariable(string _key, object _v)
    {
        inkStory.variablesState[_key] = _v;
    }

    public bool canContinue
    {
        get
        {
            return inkStory.canContinue;
        }
    }

    public bool hasChoices
    {
        get
        {
            return inkStory.currentChoices.Count > 0;
        }
    }

    string lastPath;

    public string NextLine()
    {
        lastPath = inkStory.state.CurrentPathAsString();
        // Debug.Log(lastPath);
  
        string line = inkStory.Continue();
        Debug.Assert(!inkStory.hasError);
        if (tagsParser != null)
            GetTags();

        return line;
    }

    public void ResetStory()
    {
        inkStory.ResetState();
    }

    public bool MakeChoice(int index)
    {
        if (index < inkStory.currentChoices.Count)
        {
            inkStory.ChooseChoiceIndex(index);
            return true;
        }
        Debug.LogError("INVALID CHOICE INDEX");
        return false;
    }


    public Action<String> eventDelegate;
    Action<string> inkEventDelegate;
    public AudioClip[] LeftClips;
    public AudioClip[] RightClips;

    // Use this for initialization
    void Awake()
    {
        // if (_instance == null)
        //     _instance = this;
        // else
        // {
        //     Destroy(gameObject);
        //     return;
        // }
   
   
        DontDestroyOnLoad(gameObject);
        inkEventDelegate += CatchEvent;
        inkStory = new Story(storyScript.text);
        inkStory.BindExternalFunction<String>("CustomEvent", inkEventDelegate);
    }

    void CatchEvent(string eventTag)
    {
        // Debug.Log("CATCHED EVENT " + eventTag);
        if (eventDelegate != null)
        {
            eventDelegate(eventTag);
        }
    }

    void Update()
    {
      
    }



    public void RequestKnot(string knotPath)
    {
        inkStory.ChoosePathString(knotPath);
        // Debug.Log(inkStory.globalTags);
        // Debug.Log(inkStory.currentTags);
    }

    public void GetTags()
    {
        List<string> tags = inkStory.currentTags;
        if (tags.Count > 0)
        {
            foreach (string s in tags)
            {
                // Debug.Log(s);
                string[] tag = s.Split(':');
                if (tag.Length != 2)
                {
                    Debug.LogError("Invalid tag syntax " + tag);
                }
                tagsParser(tag[0], tag[1]);
            }
        }
    }
}
