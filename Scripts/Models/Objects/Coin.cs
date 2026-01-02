using Godot;

namespace WinterGame.Scripts.Models.Objects;
public partial class Coin : Area2D
{
	[Export]
	public int CoinId;

	public override void _Ready()
	{
		if(Player.GetPlayer().CoinsCollected.Contains(CoinId))
			QueueFree();
	}

	public void OnPlayerDetected(Node2D node)
	{
		var player = (Player)node;
		player.CoinsCollected.Add(CoinId);
		CallDeferred("queue_free");
	}
}
