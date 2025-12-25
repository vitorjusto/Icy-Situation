using Godot;
using WinterGame.Scripts.Handlers;

namespace WinterGame.Scripts.Managers;
public partial class LevelManager : Node2D
{
    private HandlerBase _screenTransitionState;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
    	StartGame();
	}

    private void StartGame()
    {
        if(_screenTransitionState is not null)
    		return;
                
    	_screenTransitionState = new StartGameTransistionState(this);
    	_screenTransitionState.SetNextHandler(new LoadingLevelSceneState(this, "res://Scenes/Levels/Level1.tscn"))
    					      .SetNextHandler(new ScreenUnfadingState(this));
    }
    
	// Called every frame. 'delta' is the elapsed time since the previous frame.
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
