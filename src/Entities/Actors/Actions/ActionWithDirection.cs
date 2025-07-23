using Godot;
namespace roguelike
{
    public partial class ActionWithDirection : Action
    {
        public Vector2I Offset { get; set; } = Vector2I.Zero;
        public ActionWithDirection(Entity entity, int dx, int dy) : base(entity)
        {
            Offset = new Vector2I(dx, dy);
        }

        public override bool Perform()
        {
            return false;
        }

        public Vector2I GetDestination()
        {
            return Entity.GridPosition + Offset;
        }

        public Entity GetBlockingEntityAtDestination()
        {
            return GetMapData().GetBlockingEntityAtLocation(GetDestination());
        }

        public Entity GetTargetActor()
        {
            return GetMapData().GetActorAtLocation(GetDestination());
        }

    }
}
