using Godot;
namespace roguelike
{
	public partial class WaitAction : Action {

        public WaitAction(Entity entity): base(entity) {}

	public override void Perform() {
        return;
	}
 }
}
