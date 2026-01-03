using Godot;

namespace WinterGame.Scripts.Tutorial;
public partial class ResetTutorial : Node2D
{
	private bool _fadedIn;
	private bool _alreadStarted;
	public void OnFadeIn()
	{
		if(_alreadStarted)
			return;
		_alreadStarted = true;
		GetNode<AnimationPlayer>("AnimationPlayer").Play("FadeIn");
	}

	public void OnFadeOut()
	{
		if(_fadedIn)
			GetNode<AnimationPlayer>("AnimationPlayer").Play("FadeOut");
	}

	public void OnAnimationFinished(string name)
	{
		if(name == "FadeOut")
			CallDeferred("queue_free");
		else
			_fadedIn = true;
	}
}
