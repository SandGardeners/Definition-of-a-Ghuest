using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PictureData", menuName = "BCE/PictureData", order = 1)]
public class PictureDatas : ScriptableObject
{
    public Sprite picture;
    public string caption;
}