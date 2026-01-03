using Godot;

namespace WinterGame.Scripts.Managers;
public partial class SFXManager : Node2D
{
	public static AudioStreamPlayer aspBoxStopped {get; private set; }
	public static AudioStreamPlayer aspDoorOpen {get; private set; }
	public static AudioStreamPlayer aspHitBox {get; private set; }
	public static AudioStreamPlayer aspPickupCoin {get; private set; }
	public static AudioStreamPlayer aspPlayerPunch {get; private set; }
	public static AudioStreamPlayer aspReset {get; private set; }

	public override void _Ready()
	{
		aspBoxStopped = GetNode<AudioStreamPlayer>("ASPBoxStopped");
		aspDoorOpen = GetNode<AudioStreamPlayer>("ASPDoorOpen");
		aspHitBox = GetNode<AudioStreamPlayer>("ASPHitBox");
		aspPickupCoin = GetNode<AudioStreamPlayer>("ASPPickupCoin");
		aspPlayerPunch = GetNode<AudioStreamPlayer>("ASPPlayerPunch");
		aspReset = GetNode<AudioStreamPlayer>("ASPReset");
	}
}
