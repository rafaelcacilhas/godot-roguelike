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

        public override void Perform()
        {
            throw new System.Exception("Calling ActionWithDirection Perform().");
        }

        public Vector2I GetDestination()
        {
            return Entity.GridPosition + Offset;
        }

        public Entity GetBlockingEntityAtDestination()
        {
            return GetMapData().GetEntityAtLocation(GetDestination());
        }

        public Entity GetTargetActor()
        {
            return GetMapData().GetActorAtLocation(GetDestination());
        }

    }
}
