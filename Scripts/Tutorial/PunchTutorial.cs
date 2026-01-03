using Godot;
using System;

public partial class PunchTutorial : Area2D
{
	private bool _fadedIn;
	private bool _alreadyTriggered;
	private bool _boxMoved;
	public void OnPlayerEntered(Node2D node)
	{
		if(_alreadyTriggered)
			return;
		
		_alreadyTriggered = true;
		GetNode<AnimationPlayer>("AnimationPlayer").Play("FadeIn");
	}

	public override void _Process(double delta)
	{
		if(_fadedIn && _boxMoved)
			GetNode<AnimationPlayer>("AnimationPlayer").Play("FadeOut");
	}

	public void BoxMoved()
		=> _boxMoved = true;

	public void onAnimationFinished(string name)
	{
		if(name == "FadeOut")
			CallDeferred("queue_free");
		else
			_fadedIn = true;
	}
}
