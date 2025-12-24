using Godot;
using WinterGame.Scripts.Enums;
using WinterGame.Scripts.Helpers;
using WinterGame.Scripts.Models.Blocks;

namespace WinterGame.Scripts.Models.Players
{
	public partial class HammerColision : Area2D
	{
		private CollisionShape2D _colLeft;
		private CollisionShape2D _colRight;
		private CollisionShape2D _colUp;
		private CollisionShape2D _colDown;
		public bool IsPunching { get; private set; }
	
		private readonly QuickTimer _timer = new(20);
		public override void _Ready()
		{
			_colLeft = GetNode<CollisionShape2D>("ColLeft");
			_colRight = GetNode<CollisionShape2D>("ColRight");
			_colUp = GetNode<CollisionShape2D>("ColUp");
			_colDown = GetNode<CollisionShape2D>("ColDown");
	
			_timer.Stop();
		}
	
		public override void _Process(double delta)
		{
			if(_timer.Process(delta))
			{
				_colLeft.Disabled = true;
				_colRight.Disabled = true;
				_colUp.Disabled = true;
				_colDown.Disabled = true;
				_timer.Stop();
				IsPunching = false;
			}
	
			if(_timer.IsDisabled())
			{
				if(Input.IsActionJustPressed("Punch"))
				{
					_colUp.Disabled = Player.GetPlayer().FacingDirection != EDirection.Up;
					_colDown.Disabled = Player.GetPlayer().FacingDirection != EDirection.Down;
					_colLeft.Disabled = Player.GetPlayer().FacingDirection != EDirection.Left;
					_colRight.Disabled = Player.GetPlayer().FacingDirection != EDirection.Right;
	
					_timer.Start();
					IsPunching = true;
				}
			}
		}

		public void OnBodyDetected(Node2D body)
		{
			if(body is Block block)
			{
				block.StartMoving(Player.GetPlayer().FacingDirection);
			}
		}
	}
}