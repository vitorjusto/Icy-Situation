using Godot;
using WinterGame.Scripts.Enums;

namespace WinterGame.Scripts.Models.Objects.Camera;

public partial class CameraBlocker : Node2D
{
	[Export]
	public EDirection Direction;
}