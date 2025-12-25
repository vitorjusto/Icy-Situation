using Godot;
using WinterGame.Scripts.Managers;

namespace WinterGame.Scripts.Handlers;
public class StartGameTransistionState: HandlerBase
{
    private readonly Player _player;
    private readonly LevelManager _levelManager;
    private readonly Control _blackScreen;

    public StartGameTransistionState(LevelManager levelManager)
    {
            
        _levelManager = levelManager;
        _player = _levelManager.GetTree().Root.GetNode<Player>("/root/Main/Player");
        _blackScreen = _levelManager.GetTree().Root.GetNode<Control>("/root/Main/CanvasLayer/Panel");

        _blackScreen.Position = new Vector2(-10, 0);
        _blackScreen.Visible = true;
    }

    public override bool Handle()
    {
        _player.LockMovement();

        return true;
    }
}