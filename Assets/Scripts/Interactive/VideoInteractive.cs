using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace BCE_Interactive
{
    public class VideoInteractive : DisplayInteractive 
    {
        public override void OnInteract()
        {        
            videoDisplay.Activate(StopInteraction, DatasManager.datasLibrary.Request<VideoDatas>(videoID));
        }

        VideoDisplay videoDisplay;
        public string videoID;
        // Use this for initialization
        protected override void Start () 
        {
            prefabName = "VIDEO";
            base.Start();
            videoDisplay = processable as VideoDisplay;
        }
        
        // Update is called once per frame
        void Update () 
        {
            
        }
    }

}