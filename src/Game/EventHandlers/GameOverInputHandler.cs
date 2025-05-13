using Godot;

namespace roguelike
{
	public partial class GameOverInputHandler : BaseInputHandler
	{
		public override Action GetAction(Entity player)
		{
			Action action = null;
			if (Input.IsActionJustPressed("ui_cancel"))
			{
				action = new EscapeAction(player);
			}
			return action;
		}
	}
}

