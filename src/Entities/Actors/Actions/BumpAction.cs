using Godot;
namespace roguelike
{
	public partial class BumpAction : ActionWithDirection {
        public BumpAction() { }

        public BumpAction(int dx, int dy)
        {
            Offset = new Vector2I(dx, dy);
        }

	public override void Perform(Game game, Entity entity) {
		var destination = entity.GridPosition + Offset;
        var mapData = game.GetMapData();     
        if(mapData.HasBlockingEntity(destination))
        {
            var blockingEntity = mapData.GetEntityAtLocation(destination);
            if (blockingEntity != null )
            {
                var meleeAction = new MeleeAction(Offset.X, Offset.Y);
                meleeAction.Perform(game, entity);
            }
        }
        else
        {
            var movementAction = new MovementAction(Offset.X, Offset.Y);
            movementAction.Perform(game, entity);
	    }
    }
 }
}
