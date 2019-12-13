using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BCE_Interactive
{
    
public abstract class DisplayInteractive : Interactive {
    
    [SerializeField]
    protected InterfaceManager interfaceManager;

    protected BaseDisplay processable;
    protected string prefabName;
	// Use this for initialization
	protected override void Start () 
	{
		base.Start();
        Debug.Assert(interfaceManager != null);
        processable = interfaceManager.InstantiateModule(DatasManager.prefabsLibrary[prefabName]).GetComponent<BaseDisplay>();
	}

    public override void OnInteract()
    {
        processable.Activate(StopInteraction);
    }
}

}