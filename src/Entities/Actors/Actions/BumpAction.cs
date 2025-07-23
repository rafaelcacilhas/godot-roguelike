using Godot;
namespace roguelike
{
    public partial class BumpAction : ActionWithDirection
    {

        public BumpAction(Entity entity, int dx, int dy) : base(entity, dx, dy)
        {
            Offset = new Vector2I(dx, dy);
        }


        public override bool Perform()
        {
            var target = GetTargetActor();
            if (target == null)
            {
                return new MovementAction(Entity, Offset.X, Offset.Y).Perform();
            }
            return new MeleeAction(Entity, Offset.X, Offset.Y).Perform();
        }
    }
}
