using Godot;
using System;

namespace WinterGame.Scripts;
public partial class FinalMessage : Label
{
	public override void _Process(double delta)
	{
		Text = $"CONGRATULATIONS!!{System.Environment.NewLine}{System.Environment.NewLine}YOU FINISHED THE GAME.{System.Environment.NewLine}{System.Environment.NewLine}YOU COLLECTED {Player.GetPlayer().CoinsCollected.Count}/5 COINS";
	}
}
