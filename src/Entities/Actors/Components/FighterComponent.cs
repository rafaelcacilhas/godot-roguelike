using Godot;
namespace roguelike{
    public partial class FighterComponent : Component{
        public int MaxHP { get; set; }
        private int hp;
        public int HP { get => hp; set {
            hp = Mathf.Clamp(value, 0, MaxHP);
            if (hp <= 0) Die();
        } } 
        public int Attack { get; set; }
        public int Defense { get; set; }    

        public AtlasTexture DeathTexture { get; set; } 
        public Color DeathColor { get; set; } 

        public FighterComponent(FighterComponentDefinition fighterDefinition  )
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
            GD.Print("Entity has died.");
        }
    }
}