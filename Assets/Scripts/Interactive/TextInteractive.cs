using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BCE_Interactive
{
    
public class TextInteractive : DisplayInteractive, ITagsParser {

    [HideInInspector]
    public TextDisplay reader;
	
    public string knot;
    public Vector2 textboxOffset;
    protected Vector2 textboxPosition;
    public override void OnInteract()
	{
        base.OnInteract();
        InkOverlord.tagsParser += ParseTag;
        RectTransform rt = reader.GetComponent<RectTransform>();
        rt.anchoredPosition = (textboxPosition);//, Quaternion.identity);
        rt.ForceUpdateRectTransforms();
       // reader.Mute();
        reader.ReadKnot(knot);
	}

    protected override void StopInteraction()
	{
        base.StopInteraction(); 
        InkOverlord.tagsParser -= ParseTag;
	}
	public virtual void ParseTag(string tagHeader, string content)
    {
        switch(tagHeader)
		{
            case "debug":
                Debug.Log("DEBUG LOL SALUT");
                break;
			case "name":
                reader.SetName(content, true);
                break;
            case "event":
                switch(content)
                {
                    default:
                        break;
                }
                break;
            case "speed":
                float textSpeed;
                if(float.TryParse(content, out textSpeed))
                {
                    // Debug.Log(textSpeed);
                    reader.SetSpeed(textSpeed);
                }
                else
                {
                    // Debug.Log("Can't parse textSpeed");
                }
                break;
            case "delay":
                float textDelay;
                if(float.TryParse(content, out textDelay))
                {
                    // Debug.Log(textDelay);
                    reader.SetDelay(textDelay);
                }
                else
                {
                    // Debug.Log("Can't parse textDelay");
                }
                break;
            default:
                break;
        }
    }

        [SerializeField]
        string variant;
        // Use this for initialization
        protected override void Start () 
	{
        prefabName = "TEXT"+variant;
        base.Start();
		reader = processable as TextDisplay;
            reader.inkOverlord = interfaceManager.inkOverlord;
            textboxPosition = (Vector2.zero) + textboxOffset;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

}