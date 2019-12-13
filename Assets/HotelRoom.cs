using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomEventsSystem;
using BCE_Interactive;
using Cinemachine;
using UnityEngine.Rendering.PostProcessing;

public class HotelRoom : MonoBehaviour {

    public VideoPlayerUr videoPlayer;
    public bool playedAlready;

    Watchers _watchers;
    Watchers watchers
	{
		get
		{
			if(_watchers == null)
			{
                _watchers = FindObjectOfType<Watchers>();
                Debug.Assert(_watchers != null);
            }
            return _watchers;
        }
	}
    // Use this for initialization
    void Awake () {
        // InteractiveHandlerServiceLocator.RegisterService(new InteractiveHandler());
    }

	private void Update()
	{
        // if(Input.GetKeyDown(KeyCode.R))
            // ExecuteEnding();
    }

	public void StartStory()
	{

		ti.OnInteract();
    }

	void CatchEvent(string eventName)
	{
		if(eventName.StartsWith("BACKGROUND"))
		{
            videoPlayer.PlayVideo(eventName + ".mp4");
        }
		// if(eventName == "RESET_STORY")
		// {
		// 	ti.reader.CloseTextBox();
        //     Debug.Log("Finished");
        //     (ti.reader as HotelTextDisplay).inkOverlord.ResetStory();
		// 	playedAlready = true;
        //     Invoke("Bonjour", 5f);
		// }
		
	}

	public Camera finalCamera;
    public Cinemachine.CinemachineVirtualCamera toDisable;
    public Cinemachine.CinemachineVirtualCamera toEnable;

    public PostProcessProfile profile;
    public void ExecuteEnding()
	{
        finalCamera.targetTexture = null;
        toDisable.gameObject.SetActive(false);
        toEnable.gameObject.SetActive(true);
        Camera.main.GetComponent<AudioListener>().enabled = false;
    }

	public void Reset()
	{
 		ti.reader.ReadKnot("START");
	}
    TextInteractive ti;
    private void Start()
	{
		ti = GetComponent<TextInteractive>();
        Invoke("LazyShit", 0.1f);
    }

    bool secondLoop = false;
    bool ending = false;
    void CatchTags(string tagID, string tagContent)
	{
        if (tagID == "watchers" && !ending)
        {
            if (tagContent.StartsWith("WATCHERS_") && watchers != null)
            {
                if (tagContent == "WATCHERS_BORED" && !playedAlready)
                {
                    watchers.RequestWatchers(tagContent);
                }
                else if (playedAlready && tagContent != "WATCHERS_BORED")
                {
					if(tagContent != "WATCHERS_FIRST_LOOP")
	                	watchers.RequestWatchers(tagContent);
                    else
                    {
                        if (!secondLoop)
                        {
                            secondLoop = true;
							watchers.RequestWatchers(tagContent);
                        }
                        else
                        {
							ending = true;
                            watchers.RequestWatchers("WATCHERS_SECOND_LOOP");
                        }
                    }
                }
            }
        }
    }
	void LazyShit()
	{
        InkOverlord.tagsParser += CatchTags;
        (ti.reader as HotelTextDisplay).inkOverlord.eventDelegate += CatchEvent;
	}
}
