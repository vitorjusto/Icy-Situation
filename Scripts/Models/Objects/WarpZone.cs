using Godot;
using WinterGame.Scripts.Enums;
using WinterGame.Scripts.Managers;

namespace WinterGame.Scripts.Models.Objects;
public partial class WarpZone : Area2D
{
	[Export]
	public string Path;
	[Export]
	public EWarpType GoToAnchor;

	public void OnPlayerDetected(Node2D node)
	{
		LevelManager.GetManager().ChangeLevel(Path, GoToAnchor);
	}
}
