using Godot;
namespace roguelike
{
    public partial class FighterComponent : Component
    {
        [Signal]
        public delegate void HpChangedEventHandler(int hp, int hpMax);
        public int MaxHP { get; set; }
        private int hp;
        public int HP
        {
            get => hp; set
            {
                hp = Mathf.Clamp(value, 0, MaxHP);
                EmitSignal(SignalName.HpChanged, hp, MaxHP);
                if (hp <= 0) Die();
            }
        }
        public int Attack { get; set; }
        public int Defense { get; set; }

        public AtlasTexture DeathTexture { get; set; }
        public Color DeathColor { get; set; }

        public FighterComponent(FighterComponentDefinition fighterDefinition)
        {
            MaxHP = fighterDefinition.MaxHP;
            HP = fighterDefinition.MaxHP;
            Attack = fighterDefinition.Attack;
            Defense = fighterDefinition.Defense;
            DeathTexture = fighterDefinition.DeathTexture;
            DeathColor = fighterDefinition.DeathColor;
        }

        public void TakeDamage(int damage)
        {
            HP -= damage - Defense;
            if (HP < 0) HP = 0;
        }

        public bool IsAlive()
        {
            return HP > 0;
        }

        public void Die()
        {
            string DeathMessage;
            if (GetMapData().Player == Entity)
            {
                DeathMessage = "You died!";
                var signalBus = GetNode<SignalBus>("/root/SignalBus");
                signalBus.EmitSignal(SignalBus.SignalName.PlayerDied);
            }
            else
            {
                DeathMessage = $"{Entity.GetEntityName()} has died.";
            }

            var messageColor = Entity == GetMapData().Player ? Colors.PLAYER_DIE : Colors.ENEMY_DIE;
            MessageLog.SendMessage(DeathMessage, messageColor);

            Entity.EntityType = EntityType.CORPSE;
            Entity.Texture = DeathTexture;
            Entity.Modulate = DeathColor;
            Entity.AIComponent.QueueFree();
            Entity.AIComponent = null;
            Entity.Name = "Remains of " + Entity.GetEntityName();
            Entity.BlocksMovement = false;
            GetMapData().UnregisterBlockingEntity(Entity);

        }
    }
}