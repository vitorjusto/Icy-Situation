using Godot;
using WinterGame.Scripts.Managers;

namespace WinterGame.Scripts.Handlers;
public class ScreenUnfadingState : HandlerBase
{
    private readonly Player _player;
    private readonly Control _blackScreen;
    private static int BlackScreenSpeed => 60;

    public ScreenUnfadingState(LevelManager levelManager)
    {
        _blackScreen = levelManager.GetTree().Root.GetNode<Control>("/root/Main/CanvasLayer/Panel");
        _player = levelManager.GetTree().Root.GetNode<Player>("/root/Main/Player");
    }

    public override bool Handle()
    {
        _blackScreen.Position = new Vector2(_blackScreen.Position.X + BlackScreenSpeed, _blackScreen.Position.Y);
        _player.UnlockMovement();

        return _blackScreen.Position.X >= 2000;
    }
}