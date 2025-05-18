using Godot;
using roguelike;

public partial class BaseInputHandler : Node
{
	public virtual Action GetAction(Entity entity)
	{
		return null;
	}

	public virtual void Enter() { }
	public virtual void Exit() { }
}
