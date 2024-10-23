namespace TEXTadventureGAME;

public class State
{

    public StateType Type;
    public bool IsActive { get; private set; }

    private List<Action> methodsToCallOnActivate = new List<Action>();
    private List<Action> methodsToCallOnDeactivate = new List<Action>();
    
    
    public State(StateType type)
    {
        Type = type;
        IsActive = false;
        if (type == StateType.Exploring)
        {
            
        }
    }

    public void Activate()
    {
        IsActive = true;
        foreach (Action action in methodsToCallOnActivate)
        {
            action.Invoke();
        }
        //do some stuff
    }

    public void Deactivate()
    {
        IsActive = false;
        foreach (Action action in methodsToCallOnDeactivate)
        {
            action.Invoke();
        }
        //do some stuff >:3
    }

    public void AddToActivateCallList(Action action)
    {
        methodsToCallOnActivate.Add(action);
    }
    
    public void AddToDeactivateCallList(Action action)
    {
        methodsToCallOnDeactivate.Add(action);
    }
    
}
