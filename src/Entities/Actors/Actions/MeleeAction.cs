using Godot;
namespace roguelike
{
    public partial class MeleeAction : ActionWithDirection
    {

        public MeleeAction(Entity entity, int dx, int dy) : base(entity, dx, dy)
        {
            Offset = new Vector2I(dx, dy);
        }

        public override void Perform()
        {
            var target = GetTargetActor();
            if (target == null)
            {
                return;
            }

            var damage = Entity.FighterComponent.Attack - target.FighterComponent.Defense;
            var AttackDescription = $"Attacking {target.GetEntityName()} at {target.GridPosition}";
            if (damage < 0)
            {
                AttackDescription += " but it was blocked!";
                damage = 0;
            }
            target.FighterComponent.HP -= damage;
            GD.Print(AttackDescription);
        }
    }
}
