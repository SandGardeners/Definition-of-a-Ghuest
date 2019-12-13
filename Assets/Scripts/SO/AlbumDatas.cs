using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AlbumData", menuName = "BCE/AlbumData", order = 1)]
public class AlbumDatas : ScriptableObject
{
    public List<Sprite> pictures;
    public List<string> captions;
}