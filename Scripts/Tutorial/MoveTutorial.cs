using Godot;

namespace WinterGame.Scripts.Tutorial;
public partial class MoveTutorial : Node2D
{
	private bool _isAnimating;
	public override void _Process(double delta)
	{
		if(_isAnimating)
			return;

		if(!Input.IsActionJustPressed("MoveKeys"))
			return;
		
		GetNode<AnimationPlayer>("AnimationPlayer").Play("new_animation");
		_isAnimating = true;
	}

	public void OnAnimationFinished(string name)
		=> CallDeferred("queue_free");
}