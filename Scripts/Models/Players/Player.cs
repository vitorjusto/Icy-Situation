using System;
using System.Collections.Generic;
using Godot;
using WinterGame.Scripts.Enums;
using WinterGame.Scripts.Models.Players;

public partial class Player : CharacterBody2D
{
	public List<int> CoinsCollected {get; private set;} = new();
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

		if(Input.IsActionJustPressed("DebugMode"))
			GetNode<CollisionShape2D>("CollisionShape2D").Disabled = !GetNode<CollisionShape2D>("CollisionShape2D").Disabled;
			
		this.Velocity = Input.GetVector("Left", "Right", "Up", "Down") * (float)delta * 20000;
		
		ProcessFacingDirection();
		HandlePunch();
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
		{
			this.Velocity = Vector2.Zero;
			return;
		}

		if(Input.IsActionJustPressed("Punch"))
		{
			GetNode<Node2D>("PlayerHandLeft").Visible = FacingDirection == EDirection.Left;
			GetNode<Node2D>("PlayerHandRight").Visible = FacingDirection == EDirection.Right;
			GetNode<Node2D>("PlayerHandUp").Visible = FacingDirection == EDirection.Up;
			GetNode<Node2D>("PlayerHandDown").Visible = FacingDirection == EDirection.Down;

		}else
		{
			GetNode<Node2D>("PlayerHandLeft").Visible = false;
			GetNode<Node2D>("PlayerHandRight").Visible = false;
			GetNode<Node2D>("PlayerHandUp").Visible = false;
			GetNode<Node2D>("PlayerHandDown").Visible = false;
		}
	}

	private void ProcessAnimations()
	{
		_sprite.Play(FacingDirection.ToString());
	}

	private void ProcessFacingDirection()
	{
		if(_hammer.IsPunching)
			return;

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
