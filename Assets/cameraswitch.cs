using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class cameraswitch : MonoBehaviour {

	public CinemachineVirtualCamera[] cameras;
	int currentIndex = 0;
	// Use this for initialization
	void Start () {
		foreach (CinemachineVirtualCamera c  in cameras)
		{
			c.gameObject.SetActive(false);
		}
		cameras[0].gameObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.LeftArrow))
		{
			cameras[currentIndex].gameObject.SetActive(false);
			if(currentIndex > 0)
				currentIndex--;
			else
				currentIndex = cameras.Length-1;
			cameras[currentIndex].gameObject.SetActive(true);
		}
		if(Input.GetKeyDown(KeyCode.RightArrow))
		{
			cameras[currentIndex].gameObject.SetActive(false);
			if(currentIndex < cameras.Length-1)
				currentIndex++;
			else
				currentIndex = 0;
			cameras[currentIndex].gameObject.SetActive(true);
			
		}
	}
}
