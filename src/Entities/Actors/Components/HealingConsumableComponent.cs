using Godot;
namespace roguelike{
    public partial class HealingConsumableComponent: ConsumableComponent
    {
        public int HealingAmount { get; set; }

        public HealingConsumableComponent(HealingConsumableComponentDefinition definition)
        {
            HealingAmount = definition.HealingAmount;   
        }   

        public override bool Activate(ItemAction action)
        {
            var consumer = action.Entity;
            var amountRecovered = consumer.FighterComponent.Heal(HealingAmount);
            if (amountRecovered > 0) {
                MessageLog.SendMessage($"{consumer.Name} used {Name} and recovered {amountRecovered} HP.", Colors.HEALTH_RECOVERED);
                return true;
            }
            MessageLog.SendMessage("Your health is already full.", Colors.IMPOSSIBLE);
            return false;
        }
    }
}