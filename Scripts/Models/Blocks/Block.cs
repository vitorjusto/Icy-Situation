using System;
using System.Collections.Generic;
using Godot;
using WinterGame.Scripts.Enums;
using WinterGame.Scripts.Helpers;

namespace WinterGame.Scripts.Models.Blocks
{
	public partial class Block : CharacterBody2D
	{
		public Vector2 Speed = new(0, 0);
		private List<BlockCollision> _collisions;

		public override void _Ready()
		{
			_collisions = new();

			foreach(var n in GetChildren())
			{
				if(n is CollisionShape2D col)
					_collisions.Add(new BlockCollision(col));
			}
		}

		public override void _PhysicsProcess(double delta)
		{
			if(Speed == Vector2.Zero)
				return;

			var veloccurrentVel = Speed * (float)delta * 60;
			Velocity = veloccurrentVel;

			if(MoveAndSlide())
			{
				Speed = Vector2.Zero;
				FixPosition();
			}
		}

		public void StartMoving(EDirection direction)
		{
			FixPosition();
			Speed = new Vector2(
					x: direction == EDirection.Right? 400: direction == EDirection.Left?-400: 0,
					y: direction == EDirection.Down? 400: direction == EDirection.Up?-400: 0
			);

			_collisions.ForEach((x) => x.onMoving());
		}

		private void FixPosition()
		{
			Position = new Vector2(((float)Math.Floor(Position.X / 32) * 32 + (Position.X % 32 > 16? 32: Position.X % 32 < -16? -32: 0)),
							   (float)Math.Floor(Position.Y / 32) * 32+ (Position.Y % 32 > 16? 32: Position.Y % 32 < -16? -32: 0));
			
			GD.Print(Position);
			_collisions.ForEach((x) => x.onStoped());
		}
	}
}