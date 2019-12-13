using System.Collections;
using System.Collections.Generic;
using BCE_Interactive;
using UnityEngine;
using CustomEventsSystem;
public class Watchers : MonoBehaviour {

    public MeshRenderer screenRenderer;
    public float screenFadeTime;
    public AudioSource[] source;
    TextInteractive ti;
    void StartStory()
	{
        ti = GetComponent<TextInteractive>();
        ti.OnInteract();
        (ti.reader as WatchersTextDisplay).subscribed += DebugOui;
        (ti.reader as WatchersTextDisplay).inkOverlord.eventDelegate += HandleEvent;
    }
    bool shouldStartMovie;
    bool shouldTriggerEnding;
    void DebugOui()
    {
        if(shouldStartMovie)
        {
            StartCoroutine(FadeIn());
            shouldStartMovie = false;
        }

        if (shouldTriggerEnding)
        {
            FindObjectOfType<HotelRoom>().ExecuteEnding();
            shouldTriggerEnding = false;
        }
    }

    public void RequestWatchers(string knot)
    {
        ti.reader.Terminate();
        ti.knot = knot;
        ti.OnInteract();
    }

    void HandleEvent(string eventTag)
    {
        switch(eventTag)
        {
            case "START_MOVIE":
                shouldStartMovie = true;
                break;
            case "TRIGGER_ENDING":
                shouldTriggerEnding = true;
                break;
        }
    }

    IEnumerator FadeIn()
    {
        float timer = 0;
        while(timer < screenFadeTime)
        {
            timer += Time.deltaTime;
            float ratio = Utilities.Ease.cubeIn(timer / screenFadeTime);
            foreach(AudioSource s in source)
            {
                s.volume = ratio;
            }
            screenRenderer.material.SetColor("_Color", Color.Lerp(alpha, Color.white, ratio));
            yield return new WaitForEndOfFrame();
        }
        HotelRoom hr = FindObjectOfType<HotelRoom>();
        Debug.Assert(hr != null);
        hr.StartStory();
    }

    Color alpha = new Color(0f, 0f, 0f, 0f);
    private void Awake()
	{
        screenRenderer.material.SetColor("_Color", alpha);
    }
	private void Start()
	{
        Invoke("StartStory", 3f);
    }
}
