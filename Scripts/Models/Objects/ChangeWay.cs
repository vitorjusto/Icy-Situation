using System.Collections.Generic;
using Godot;
using WinterGame.Scripts.Enums;
using WinterGame.Scripts.Models.Blocks;

namespace WinterGame.Scripts.Models.Objects;
public partial class ChangeWay : Node2D
{
	[Export]
	public EDirection Direction;
	private List<Block> _upBlock = new();
	private List<Block> _downBlock = new();
	private List<Block> _leftBlock = new();
	private List<Block> _rightBlock = new();
	
	private void VerifyCollisions(Block block)
	{
		if(!_upBlock.Contains(block))
			return;
		if(!_downBlock.Contains(block))
			return;
		if(!_leftBlock.Contains(block))
			return;
		if(!_rightBlock.Contains(block))
			return;
		
		block.StartMoving(Direction);
	}

	public void onUpEntered(Node2D node)
	{
		if(node is Block block)
		{
			GD.Print("EUP");
			_upBlock.Add(block);
			VerifyCollisions(block);
		}
	}

	public void onDownEntered(Node2D node)
	{
		if(node is Block block)
		{
			GD.Print("EDOWN");
			_downBlock.Add(block);
			VerifyCollisions(block);
		}
	}

	public void onLeftEntered(Node2D node)
	{
		if(node is Block block)
		{
			GD.Print("ELEFT");
			_leftBlock.Add(block);
			VerifyCollisions(block);
		}
	}

	public void onRightEntered(Node2D node)
	{
		if(node is Block block)
		{
			GD.Print("ERIGHT");
			_rightBlock.Add(block);
			VerifyCollisions(block);
		}
	}

	public void onUpExited(Node2D node)
	{
		GD.Print("SUP");
		if(node is Block block)
			_upBlock.Remove(block);
	}
	public void onDownExited(Node2D node)
	{
		GD.Print("SDOWN");
		if(node is Block block)
			_downBlock.Remove(block);
	}
	public void onLeftExited(Node2D node)
	{
		GD.Print("SLEFT");
		if(node is Block block)
			_leftBlock.Remove(block);
	}
	public void onRightExited(Node2D node)
	{
		GD.Print("SRIGHT");
		if(node is Block block)
			_rightBlock.Remove(block);
	}

}
