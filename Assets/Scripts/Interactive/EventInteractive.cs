using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BCE_Interactive
{
    
public class EventInteractive : Interactive {

	public UnityEvent m_event;

    public override void OnInteract()
    {
        m_event.Invoke();
    }
}

}