using Godot;
using WinterGame.Scripts.Models.Objects.Camera;

namespace WinterGame.Scripts.Models.Level;
public partial class LevelBase : Node2D
{
	[Export]
	public Node2D SpawnerAnchor;
	[Export]
	public CameraSection StartSection;

	public override void _Ready()
	{
		StartSection.SetCameraSectionToPlayer();
	}
}
