using Godot;
using System.Threading.Tasks;
namespace roguelike
{
	public partial class BaseInputHandler : Node
	{
			public virtual Task<Action> GetActionAsync(Entity player) =>
				new Task<Action>(() => null);

		public virtual void Enter() { }
		public virtual void Exit() { }
	}
}

