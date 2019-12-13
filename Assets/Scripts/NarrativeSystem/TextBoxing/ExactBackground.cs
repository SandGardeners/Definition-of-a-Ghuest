using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExactBackground : MonoBehaviour {

    RectTransform _mine;
    RectTransform _theirs;
    // Use this for initialization
    void Start () 
	{
        _mine = GetComponent<RectTransform>();
        _theirs = GetComponentInChildren<TextMeshBox>().GetComponent<RectTransform>();
    }
	
	// Update is called once per frame
	void Update () 
	{
        if(_theirs != null && _mine != null) 
            _mine.sizeDelta = _theirs.sizeDelta;
    }
}
