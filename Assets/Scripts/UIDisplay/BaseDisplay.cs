using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BaseDisplay : MonoBehaviour, IProcessable {

    public void OnPointerClick(PointerEventData eventData)
    {
        Process();
    }

    public virtual void Process()
    {
        Terminate();
    }

	public Action finished;
    public virtual void Terminate()
    {
		if(finished != null)
			finished();
		finished = null;
		gameObject.SetActive(false);
    }

    public void Activate(Action stopInteraction, ScriptableObject data=null)
    {
		gameObject.SetActive(true);
		finished += stopInteraction;
        if(data != null)
            FeedData(data);
    }

    protected virtual void FeedData(ScriptableObject data)
    {

    }
}
