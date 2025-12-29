using Godot;
using WinterGame.Scripts.Enums;
using WinterGame.Scripts.Handlers;

namespace WinterGame.Scripts.Managers;
public partial class LevelManager : Node2D
{
	private static LevelManager _manager;
	public static LevelManager GetManager()
		=> _manager;
	
    private HandlerBase _screenTransitionState;

	public override void _Ready()
	{
		_manager = this;
		
    	_screenTransitionState = new StartGameTransistionState(this);
    	_screenTransitionState.SetNextHandler(new LoadingLevelSceneState(this, "res://Scenes/Levels/Level2.tscn", EWarpType.Entrance))
    					      .SetNextHandler(new ScreenUnfadingState(this));
	}

    public void ChangeLevel(string path, EWarpType warpType)
    {
        if(_screenTransitionState is not null)
    		return;
                
    	_screenTransitionState = new ScreenFadingState(this);
    	_screenTransitionState.SetNextHandler(new LoadingLevelSceneState(this, path, warpType))
    					      .SetNextHandler(new ScreenUnfadingState(this));
    }
    
	public override void _Process(double delta)
    {
    	HandleScreenTransistion();
    }

    private void HandleScreenTransistion()
    {
        if(_screenTransitionState is null)
    		return;

    	if(_screenTransitionState.Handle())
    		_screenTransitionState = _screenTransitionState.NextHandler;
    }
}
