using Godot;
using WinterGame.Scripts.Models.Objects.Camera;

namespace WinterGame.Scripts.Models.Level;
public partial class LevelBase : Node2D
{
	[Export]
	public Node2D StartAnchor;
	[Export]
	public Node2D EndAnchor;
	[Export]
	public CameraSection StartSection;
	[Export]
	public CameraSection EndSection;

	private CameraSection _currentSection;
	public override void _Ready()
	{
		foreach(var node in GetChildren())
		{
			if(node is CameraSection section)
				section.Connect("OnActivated", new Callable(this, "OnSectionActivated"));
		}
	}

	public void OnSectionActivated(CameraSection cameraSection)
	{
		if(_currentSection is not null)
			_currentSection.Active = false;
		
		_currentSection = cameraSection;
		_currentSection.Active = true;
	}
}
