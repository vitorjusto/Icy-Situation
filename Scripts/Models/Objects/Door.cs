using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using WinterGame.Scripts.Models.Objects;

namespace WinterGame.Scripts.Models.Objects;
public partial class Door : Node2D
{
	[Export]
	public Button[] Buttons;

	private CollisionShape2D _col;
	private Node2D _tex;
	public override void _Ready()
	{
		_col = GetNode<CollisionShape2D>("CollisionShape2D");
		_tex = GetNode<Node2D>("DoorActive");
	}

	public override void _Process(double delta)
	{
		if(Buttons.All((x) => x.IsActived))
		{
			_col.Disabled = true;
			_tex.Visible = false;
		}
		else 
		{
			_col.Disabled = false;
			_tex.Visible = true;
		}
	}
}
