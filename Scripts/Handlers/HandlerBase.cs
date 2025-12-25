namespace WinterGame.Scripts.Handlers;
public abstract class HandlerBase
{
    public HandlerBase NextHandler; 
    public HandlerBase SetNextHandler(HandlerBase handler)
    {
        NextHandler = handler;
        return NextHandler;
    }

    public abstract bool Handle();
    
}