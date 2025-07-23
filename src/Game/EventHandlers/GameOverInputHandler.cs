using Godot;
using System.Threading.Tasks;

namespace roguelike
{
	public partial class GameOverInputHandler : BaseInputHandler
	{
		public override Task<Action> GetActionAsync(Entity player)
		{
			Action action = null;
			if (Input.IsActionJustPressed("ui_cancel"))
			{
				action = new EscapeAction(player);
			}
			return new Task<Action>(() => action);
		}
	}
}

