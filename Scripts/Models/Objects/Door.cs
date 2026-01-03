using Godot;
using System.Linq;
using WinterGame.Scripts.Enums;
using WinterGame.Scripts.Managers;

namespace WinterGame.Scripts.Models.Objects;
public partial class Door : Node2D
{
	[Export]
	public Button[] Buttons;
	[Export]
	public EColor Color;

	private CollisionShape2D _col;
	private Node2D _tex;
	private bool _alreadyActivated;
	public override void _Ready()
	{
		_col = GetNode<CollisionShape2D>("CollisionShape2D");
		
		if(Color == EColor.Red)
		{
			_tex = GetNode<Node2D>("RedDoorActive");
			GetNode<Node2D>("BlueDoorActive").Visible = false;
			GetNode<Node2D>("BlueDoorDeactive").Visible = false;
		}
		else
		{
			_tex = GetNode<Node2D>("BlueDoorActive");
			GetNode<Node2D>("RedDoorActive").Visible = false;
			GetNode<Node2D>("RedDoorDeactive").Visible = false;
		}
	}

	public override void _Process(double delta)
	{
		if(Buttons.All((x) => x.IsActived))
		{
			if(!_alreadyActivated)
			{
				_alreadyActivated = true;
				SFXManager.aspDoorOpen.Play();
			}
			_col.Disabled = true;
			_tex.Visible = false;
		}
		else 
		{
			_alreadyActivated = false;
			_col.Disabled = false;
			_tex.Visible = true;
		}
	}
}
