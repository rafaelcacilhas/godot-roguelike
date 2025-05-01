using Godot;
namespace roguelike
{
	public partial class MovementAction : ActionWithDirection {
        public MovementAction() { }

        public MovementAction(int dx, int dy)
        {
            Offset = new Vector2I(dx, dy);
        }

	public override void Perform(Game game, Entity entity) {
		var destination = entity.GridPosition + Offset;
		var mapData = game.GetMapData(); 
		var destinationTile = mapData.GetTile(destination);
		
		if (destinationTile == null || !destinationTile.IsWalkable())
			return;
		if (mapData.HasBlockingEntity(destination))
			return;
		entity.Move(destination);
	}
 }
}
