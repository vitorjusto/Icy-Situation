using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using WinterGame.Scripts.Enums;

namespace WinterGame.Scripts.Models.Objects;
public partial class Button : Area2D
{
	public AnimatedSprite2D Sprite;
	private readonly List<Node2D> _nodes = new();

	[Export]
	public EColor Color;
	public override void _Ready()
	{
		Sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		ChangeColor();
	}

	private void ChangeColor()
	{
		if(Color == EColor.Red)
			Sprite.Play("Red");
		else
			Sprite.Play("Blue");
	}

	public bool IsActived => _nodes.Any();

	public void onBodyEntered(Node2D node)
	{
		Sprite.Play("Pressing");
		_nodes.Add(node);
	}
		
	public void onBodyExited(Node2D node)
	{
		ChangeColor();
		_nodes.Remove(node);
	}
}