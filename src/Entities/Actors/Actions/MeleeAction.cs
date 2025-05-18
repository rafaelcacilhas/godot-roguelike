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
            var AttackColor = Entity == GetMapData().Player ? Colors.PLAYER_ATTACK : Colors.ENEMY_ATTACK;
            var AttackDescription = $"Attacking {target.GetEntityName()} at {target.GridPosition}";

            if (damage <= 0)
            {
                AttackDescription += " but it was blocked!";
                damage = 0;
            }
            else
            {
                AttackDescription += $" for {damage} damage!";
            }

            target.FighterComponent.HP -= damage;
            MessageLog.SendMessage(AttackDescription, AttackColor);
        }
    }
}
