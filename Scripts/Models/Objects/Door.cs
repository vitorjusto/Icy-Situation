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

	public override void _Process(double delta)
	{
		if(Buttons.All((x) => x.IsActived))
			Modulate = Color.Color8(0, 255, 0);
		else 
			Modulate = Color.Color8(255, 0, 0);
	}
}
