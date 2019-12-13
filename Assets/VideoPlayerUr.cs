using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerUr : MonoBehaviour {
	VideoPlayer player;
	public string filename;
	void Awake()
	{
		player = GetComponent<VideoPlayer>();
        PlayVideo(filename);
    }

	public void PlayVideo(string _filename)
	{
		string url = System.IO.Path.Combine(Application.streamingAssetsPath, _filename);
		player.url = url;
	}
}
