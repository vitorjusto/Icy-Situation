using Godot;
using WinterGame.Scripts.Enums;
using WinterGame.Scripts.Managers;
using WinterGame.Scripts.Models.Level;

namespace WinterGame.Scripts.Handlers;

public class LoadingLevelSceneState : HandlerBase
{
	private readonly LevelManager _levelManager;
	private readonly Player _player;
	private readonly string _path;
	private readonly EWarpType _warpType;

	public LoadingLevelSceneState(LevelManager levelManager, string path, EWarpType warpType)
    {
        _levelManager = levelManager;
        _player = _levelManager.GetTree().Root.GetNode<Player>("/root/Main/Player");
		_path = path;
		_warpType = warpType;
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
		
		_player.ChangeCameraSmooth(false);

		if(_warpType == EWarpType.Entrance)
		{
			_player.Position = instance.StartAnchor.Position;
			instance.StartSection.SetCameraSectionToPlayer();
		}
		else
		{
			_player.Position = instance.EndAnchor.Position; 
			instance.EndSection.SetCameraSectionToPlayer();
		}

		_levelManager.AddChild(instance);
		return true;
	}
}
