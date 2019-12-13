using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatasManager : MonoBehaviour 
{
	public static DatasLibrary datasLibrary;
	public static Dictionary<string, BaseDisplay> prefabsLibrary;
	public DatasLibrary datas;
	public List<PrefabTuple> prefabs;

	void Awake()
	{
		datasLibrary = datas;
		prefabsLibrary = new Dictionary<string, BaseDisplay>();
		foreach(PrefabTuple go in prefabs)
		{
			prefabsLibrary[go.prefabID] = go.baseDisplay;
		}
	}
}

[System.Serializable]
public struct PrefabTuple
{
	public string prefabID;
	public BaseDisplay baseDisplay;
}
