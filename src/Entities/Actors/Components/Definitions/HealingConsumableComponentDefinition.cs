using Godot;
namespace roguelike {
    [GlobalClass]
    public partial class HealingConsumableComponentDefinition : ConsumableComponentDefinition
    {
        [Export]
        public int HealingAmount { get; set; } = 0;
    }
}  