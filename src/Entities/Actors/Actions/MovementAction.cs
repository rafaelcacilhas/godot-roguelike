using Godot;
namespace roguelike
{
	public partial class MovementAction : ActionWithDirection
	{

		public MovementAction(Entity player, int dx, int dy) : base(player, dx, dy) { }

		public override bool Perform()
		{
			var mapData = GetMapData();
			var destination = mapData.GetTile(GetDestination());

			if (destination == null || !destination.IsWalkable())
			{
				return false;
			}

			if (GetBlockingEntityAtDestination() != null)
			{
				return false;
			}

			Entity.Move(Offset);
			return true;
		}
	}
}
