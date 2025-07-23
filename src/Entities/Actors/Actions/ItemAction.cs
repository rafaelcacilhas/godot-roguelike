using Godot;
namespace roguelike
{
    public partial class ItemAction : Action
    {
        public Entity Item { get; set; }
        public Vector2I TargetPosition { get; set; }

        public ItemAction(Entity entity, Entity item, Vector2I? targetPosition) : base(entity)
        {
            Item = item;
            TargetPosition = targetPosition == null? entity.GridPosition : targetPosition.Value;
        }

        public Entity GetTargetActor()
        {
            return GetMapData().GetActorAtLocation(TargetPosition);
        }

        public override bool Perform(){
            if (Item == null) return false;
            return Item.ConsumableComponent.Activate(this);
        }
    }
}