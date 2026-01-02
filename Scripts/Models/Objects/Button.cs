using Godot;
using System.Collections.Generic;
using System.Linq;

namespace WinterGame.Scripts.Models.Objects;
public partial class Button : Area2D
{
	public AnimatedSprite2D Sprite;
	private readonly List<Node2D> _nodes = new();

	public override void _Ready()
		=> Sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		
	public bool IsActived => _nodes.Any();

	public void onBodyEntered(Node2D node)
	{
		Sprite.Play("Pressing");
		_nodes.Add(node);
	}
		
	public void onBodyExited(Node2D node)
	{
		Sprite.Play("Idle");
		_nodes.Remove(node);
	}
}