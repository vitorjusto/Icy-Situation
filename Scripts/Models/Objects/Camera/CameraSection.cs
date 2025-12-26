using System.Collections.Generic;
using Godot;
using WinterGame.Scripts.Enums;
using WinterGame.Scripts.Helpers;
using WinterGame.Scripts.Models.Blocks;

namespace WinterGame.Scripts.Models.Objects.Camera;

public partial class CameraSection : Node2D
{
	private readonly List<CameraBlocker> _blockers = new();
	private readonly List<BlockRestarter> _blocks = new();
	private Player player;
	public bool Active = false;

	public override void _Ready()
	{
		foreach(var node in GetChildren())
		{
			if(node is CameraBlocker blocker)
				_blockers.Add(blocker);
			if(node is Block block)
				_blocks.Add(new BlockRestarter(block));
			if(node is ResetButton button)
				button.Connect("body_entered", new Callable(this, "onResetButtonPressed"));
		}

	}

	public void onPlayerDetected(Node2D node)
		=> SetCameraSectionToPlayer();
	public void SetCameraSectionToPlayer()
	{
		if(Active)
			return;
			
        var camera = Player.GetPlayer().GetNode<Camera2D>("Camera2D");
    
        foreach(var blocker in _blockers)
        {
            HandleCameraBehavior(camera, blocker);
        }

		onResetButtonPressed(null);
		EmitSignal("OnActivated", this);
	}

    private void HandleCameraBehavior(Camera2D camera, CameraBlocker blocker)
    {
        if (blocker.Direction == EDirection.Up)
            camera.LimitTop = (int)blocker.Position.Y;
        if (blocker.Direction == EDirection.Down)
            camera.LimitBottom = (int)blocker.Position.Y;
        if (blocker.Direction == EDirection.Left)
            camera.LimitLeft = (int)blocker.Position.X;
        if (blocker.Direction == EDirection.Right)
            camera.LimitRight = (int)blocker.Position.X;
    }

	public void onResetButtonPressed(Node2D node)
	{
        foreach(var block in _blocks)
        {
            block.Restart();
        }
	}

	[Signal]
	public delegate void OnActivatedEventHandler(CameraSection cameraSection);
}
