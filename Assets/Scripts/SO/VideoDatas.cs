using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VideoData", menuName = "BCE/VideoData", order = 1)]
public  class VideoDatas : ScriptableObject
{
    public UnityEngine.Video.VideoClip clip;
    public string caption;
}