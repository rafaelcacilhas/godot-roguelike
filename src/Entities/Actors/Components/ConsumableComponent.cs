using Godot;
namespace roguelike
{
    public abstract partial class ConsumableComponent : Component
    {
        public Action GetAction(Entity consumer) => 
            new ItemAction(consumer, Entity, null);
        public void Consume(Entity consumer)
        {
            var inventory = consumer.InventoryComponent;
            inventory.Items.Remove(Entity);
            Entity.QueueFree();
        }

        public abstract bool Activate(ItemAction action);
    }
}