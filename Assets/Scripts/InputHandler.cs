using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BCE_Interactive;
namespace CustomEventsSystem
{
    
public class InteractiveHandlerServiceLocator
{
    static CommandsManager _commandsManager;
    static public CommandsManager commandsManager
    {
        get
        {
            if(_commandsManager == null)
            {
                _commandsManager = GameObject.FindObjectOfType<CommandsManager>();
                if(_commandsManager == null)
                    _commandsManager = new GameObject("CommandsManager", typeof(CommandsManager)).GetComponent<CommandsManager>();
            }

            return _commandsManager;
        }
    }
    static IInteractiveHandler interactiveHandler;
    static NullInteractiveHandler nullInteractiveHandler = new NullInteractiveHandler() ;

    public static IInteractiveHandler GetInteractiveHandler() { return interactiveHandler; }

    public static void RegisterService(IInteractiveHandler service)
    {
        if (service == null)
        {
            // Revert to null service.
            interactiveHandler = nullInteractiveHandler;
        }
        else
        {
            interactiveHandler = service;
        }
    }
}

public interface IInteractiveHandler
{
	void HandleInteractive(Interactive _interactive);
    void MouseDown(Vector2 _mousePosition);
}

public class InteractiveHandler : IInteractiveHandler
{    
    InterfaceManager _interfaceManager;
    protected InterfaceManager interfaceManager
    {
        get
        {
            if(_interfaceManager == null)
                _interfaceManager = UnityEngine.GameObject.FindObjectOfType<InterfaceManager>();

            return _interfaceManager;
        }
    }

    public virtual void HandleInteractive(Interactive _interactive)
    {
        List<Command> commandsToStack = _interactive.CommandsToExecute();
        foreach(Command c in commandsToStack)
        {
            InteractiveHandlerServiceLocator.commandsManager.AddCommand(c);
        }
        InteractiveHandlerServiceLocator.commandsManager.ExecuteCommand();
    }

    public virtual void MouseDown(Vector2 _mousePosition)
    {
        
    }
}

public class NullInteractiveHandler : IInteractiveHandler
{
   public void HandleInteractive(Interactive _interactive)
    {
        Debug.LogError("NO PROPER INTERACTIVE HANDLER SERVICE");
    }

    public void MouseDown(Vector2 _mousePosition)
    {
        
    }
}

public class RoomInteractiveHandler : InteractiveHandler
{
	public override void HandleInteractive(Interactive _interactive)
	{
		base.HandleInteractive(_interactive);
	}

    public override void MouseDown(Vector2 _mousePosition)
    {
        base.MouseDown(_mousePosition);
    }
}


}