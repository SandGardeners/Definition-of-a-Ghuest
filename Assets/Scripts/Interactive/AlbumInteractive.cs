using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BCE_Interactive
{
    
public class AlbumInteractive : DisplayInteractive 
{
	public string albumID;
	AlbumDisplay albumDisplay;

    public override void OnInteract()
    {
        albumDisplay.Activate(StopInteraction, DatasManager.datasLibrary.Request<AlbumDatas>(albumID));
    }

    // Use this for initialization
    protected override void Start () 
	{
        string prefabName = "ALBUM";
        base.Start();
		albumDisplay = processable as AlbumDisplay;
    }
	
}

}