using Godot;
namespace roguelike
{
	public partial class MeleeAction : ActionWithDirection {
        public MeleeAction() { }

        public MeleeAction(int dx, int dy)
        {
            Offset = new Vector2I(dx, dy);
        }

	public override void Perform(Game game, Entity entity) {
		var destination = entity.GridPosition + Offset;
		var enemy = game.GetMapData().GetEntityAtLocation(destination); 
        if (enemy == null )
            return;
        GD.Print($"Attacking {enemy.GetEntityName()} at {enemy.GridPosition}");        
	}
 }
}
