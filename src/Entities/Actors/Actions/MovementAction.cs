using Godot;
namespace roguelike
{
	public partial class MovementAction : ActionWithDirection {

        public MovementAction(Entity player, int dx, int dy) : base(player, dx, dy) {}

	public override void Perform() {
		var mapData = GetMapData();
		var destination = mapData.GetTile(GetDestination() );

		if(destination == null || !destination.IsWalkable()) {
			return;
		}

		if(GetBlockingEntityAtDestination() != null) {
			return;
		}

		Entity.Move(Offset);
	}
 }
}
