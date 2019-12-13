using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public partial class InterfaceManager : MonoBehaviour 
{
    public InkOverlord inkOverlord;
    Dictionary<BaseDisplay, BaseDisplay> interfacePrefabs;

    BaseDisplay processable;

    public delegate void SimpleDelegate();
    
    public Texture2D normalCursor;
    public Texture2D interactiveCursor;
    public Texture2D walkableCursor;
    public DatasLibrary library;
    Dictionary<string, CharacterDatas> characterDatas;
    public AudioClip[] defaultVoices;

    [HideInInspector]
    public bool canProcess = true;

    Vector2 cursorHotSpot = new Vector2(-0.2f, -0.2f);
    
    public Color darkColor;
    public Color transparentColor;
    
    

    //SHOULD MOVE
    public AudioClip GetVoiceClip(string name)
    {
        if(characterDatas != null)
        {
            if(characterDatas.ContainsKey(name))
            {
                AudioClip[] voices = characterDatas[name].characterVoice;
                return voices[UnityEngine.Random.Range(0, voices.Length)];
            }
        }
        return defaultVoices[UnityEngine.Random.Range(0, defaultVoices.Length)];
        
    }

   
    //SHOULD MOVE
    public void NormalCursor()
    {
        Cursor.SetCursor(normalCursor, cursorHotSpot, CursorMode.Auto);
    }

    //SHOULD MOVE
    public void InteractiveCursor()
    {
        Cursor.SetCursor(interactiveCursor, cursorHotSpot, CursorMode.Auto);
    }

    //SHOULD MOVE
    public void WalkableCursor()
    {
        Cursor.SetCursor(walkableCursor, cursorHotSpot, CursorMode.Auto);
    }



    //SHOULD MOVE
    public void Resume()
    {
    }
    //SHOULD MOVE
    public void Quit()
    {
        Application.Quit();        
    }

 
    
    void Update()
	{
    //    HandleInputs();
        //ON THE FLY COMPONENT
	}
    //PART OF PROCESS() REFACTORING

    public BaseDisplay InstantiateModule(BaseDisplay readerPrefab)
    {
		BaseDisplay module;      
		if(interfacePrefabs.ContainsKey(readerPrefab))
		{
            module = interfacePrefabs[readerPrefab];
        }
		else
		{
			module = interfacePrefabs[readerPrefab] = GameObject.Instantiate(readerPrefab, transform);
		}

        module.gameObject.SetActive(false);
        return module;
    }

	void Awake()
	{
        interfacePrefabs = new Dictionary<BaseDisplay, BaseDisplay>();

        if(library != null)
        {
            characterDatas = new Dictionary<string, CharacterDatas>();
            foreach(CharacterDatas cd in library.charactersDatas)
            {
                characterDatas[cd.characterName] = cd;
            }
        }
    }
    //DEBUG COMPONENT


}
