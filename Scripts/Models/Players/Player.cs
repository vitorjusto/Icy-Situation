using System;
using Godot;
using WinterGame.Scripts.Enums;
using WinterGame.Scripts.Models.Players;

public partial class Player : CharacterBody2D
{
	private static Player _player;
	public static Player GetPlayer()
		=> _player;
	
	[Export]
	public AnimatedSprite2D _sprite;
	[Export]
	public HammerColision _hammer;
	public EDirection FacingDirection { get; private set; }
	private bool _allowMove = true;
	public override void _Ready()
	{
		_player = this;
		FacingDirection = EDirection.Up;
	}
	public override void _PhysicsProcess(double delta)
	{
		if(!_allowMove)
			return;
		this.Velocity = Input.GetVector("Left", "Right", "Up", "Down") * (float)delta * 30000;
		
		HandlePunch();
		ProcessFacingDirection();
		ProcessAnimations();

		MoveAndSlide();

	}

	private void HandlePunch()
	{
		if(_hammer.IsPunching)
			this.Velocity = Vector2.Zero;
	}

	private void ProcessAnimations()
	{
		_sprite.Play(FacingDirection.ToString());
	}

	private void ProcessFacingDirection()
	{

		if(this.Velocity.Y < 0 && FacingDirection == EDirection.Up)
			return;
		if(this.Velocity.Y > 0 && FacingDirection == EDirection.Down)
			return;
		if(this.Velocity.X < 0 && FacingDirection == EDirection.Left)
			return;
		if(this.Velocity.X > 0 && FacingDirection == EDirection.Right)
			return;
		
		if(this.Velocity.Y < 0)
			FacingDirection = EDirection.Up;
		else if(this.Velocity.Y > 0)
			FacingDirection = EDirection.Down;
		else if(this.Velocity.X < 0)
			FacingDirection = EDirection.Left;
		else if(this.Velocity.X > 0)
			FacingDirection = EDirection.Right;
		
	}

	public void LockMovement()
		=> _allowMove = false;

	internal void UnlockMovement()
		=> _allowMove = true;
}
