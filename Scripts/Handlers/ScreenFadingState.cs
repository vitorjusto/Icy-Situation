using Godot;
using WinterGame.Scripts.Managers;

namespace WinterGame.Scripts.Handlers;
public class ScreenFadingState : HandlerBase
{
    private readonly Player _player;
    private readonly Control _blackScreen;
    private static int BlackScreenSpeed => 50;

    public ScreenFadingState(LevelManager levelManager)
    {
        _blackScreen = levelManager.GetTree().Root.GetNode<Control>("/root/Main/CanvasLayer/Panel");
        _player = levelManager.GetTree().Root.GetNode<Player>("/root/Main/Player");
        _blackScreen.Position = new Vector2(-1391, 0);
        _blackScreen.Visible = true;
    }

    public override bool Handle()
    {
        _blackScreen.Position = new Vector2(_blackScreen.Position.X + BlackScreenSpeed, _blackScreen.Position.Y);
        _player.LockMovement();

        return _blackScreen.Position.X >= -70;
    }
}