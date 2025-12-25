using Godot;
using WinterGame.Scripts.Managers;
using WinterGame.Scripts.Models.Level;

namespace WinterGame.Scripts.Handlers;

public class LoadingLevelSceneState : HandlerBase
{
	private LevelManager _levelManager;
	private Player _player;
	private string _path;

	public LoadingLevelSceneState(LevelManager levelManager, string path)
    {
        _levelManager = levelManager;
        _player = _levelManager.GetTree().Root.GetNode<Player>("/root/Main/Player");
		_path = path;
    }

	public override bool Handle()
	{
		var scene = GD.Load<PackedScene>(_path);
		var instance = scene.Instantiate<LevelBase>();
		
		if(_levelManager.GetChildCount() > 0)
		{
			var lastLevel = _levelManager.GetChild(0);
			_levelManager.RemoveChild(lastLevel);
			lastLevel.QueueFree();
		}

		_levelManager.AddChild(instance);
		_player.Position = instance.SpawnerAnchor.Position;

		return true;
	}
}
