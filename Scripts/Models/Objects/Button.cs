using Godot;
using System.Collections.Generic;
using System.Linq;

namespace WinterGame.Scripts.Models.Objects;
public partial class Button : Area2D
{
	private readonly List<Node2D> _nodes = new();

	public bool IsActived => _nodes.Any();

	public void onBodyEntered(Node2D node)
		=> _nodes.Add(node);
		
	public void onBodyExited(Node2D node)
		=> _nodes.Remove(node);
}