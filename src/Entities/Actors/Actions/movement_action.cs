using Godot;
namespace roguelike
{
	public partial class MovementAction : Action {
	public Vector2I Offset { get; set; } = Vector2I.Zero;
	
	public MovementAction(int dx, int dy) {
		Offset = new Vector2I(dx, dy);
	}

	public override void Perform(Game game, Entity entity) {
		var destination = entity.GridPosition + Offset;
		var mapData = game.GetMapData(); 
		var destinationTile = mapData.GetTile(destination);

		if (mapData == null)
		{
			GD.PrintErr("MapData is null!");
			return;
		} 
		
		if (destinationTile == null || !destinationTile.IsWalkable())
			return;
		
		entity.Move(destination);
	}
 }
}
