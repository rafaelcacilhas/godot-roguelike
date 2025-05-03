using Godot;
namespace roguelike
{
	public partial class MeleeAction : ActionWithDirection {

        public MeleeAction(Entity entity, int dx, int dy) : base(entity, dx, dy) {
            Offset = new Vector2I(dx, dy);
        }

	public override void Perform() {
        var target = GetBlockingEntityAtDestination();
        if (target == null)
        {
            return;
        }
        GD.Print($"Attacking {target.GetEntityName()} at {target.GridPosition}");        
	}
 }
}
