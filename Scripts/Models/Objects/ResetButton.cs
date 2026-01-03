using Godot;
using WinterGame.Scripts.Managers;

namespace WinterGame.Scripts.Models.Objects;

public partial class ResetButton : Area2D
{
	public AnimatedSprite2D Sprite;

	public override void _Ready()
	{
		Sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	public void OnBodyEntered(Node2D node)
	{
		EmitSignal("OnPress");
		if(!SFXManager.aspReset.Playing)
			SFXManager.aspReset.Play();
		
		Sprite.Play("Pressing");
	}

	public void OnBodyExited(Node2D node)
		=> Sprite.Play("Idle");
	
	[Signal]
	public delegate void OnPressEventHandler();
}