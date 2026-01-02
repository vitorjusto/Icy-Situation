using System;
using Godot;
using WinterGame.Scripts.Enums;
using WinterGame.Scripts.Models.Players;

public partial class Player : CharacterBody2D
{
	private static Player _player;
	private static AnimationPlayer _animation;
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
		_animation = GetNode<AnimationPlayer>("AnimationPlayer");
	}
	public override void _PhysicsProcess(double delta)
	{
		if(!_allowMove)
			return;
		this.Velocity = Input.GetVector("Left", "Right", "Up", "Down") * (float)delta * 20000;
		
		HandlePunch();
		ProcessFacingDirection();
		ProcessAnimations();

		if(this.Velocity == Vector2.Zero)
			_animation.Play("Idle");
		else
			_animation.Play("Walk");

		MoveAndSlide();
		_player.ChangeCameraSmooth(true);
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

	public void ChangeCameraSmooth(bool value)
	{

		GetNode<Camera2D>("Camera2D").PositionSmoothingEnabled = value;
	}
}
