using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BCE_Interactive
{
    
public class PictureInteractive : DisplayInteractive 
{
    public override void OnInteract()
    {
        base.OnInteract();
        imageDisplay.ShowImage(image, caption);
    }
    ImageDisplay imageDisplay;

    public Sprite image;
    public string caption = "";
    // Use this for initialization
    protected override void Start () 
	{
        prefabName = "IMAGE";
        base.Start();
		imageDisplay = processable as ImageDisplay;
    }
	
}

}