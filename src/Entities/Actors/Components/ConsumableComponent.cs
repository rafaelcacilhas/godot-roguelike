using Godot;
namespace roguelike
{
    public abstract partial class ConsumableComponent : Component
    {
        public Action GetAction(Entity consumer) => 
            new ItemAction(consumer, Entity, null);
        public void Consume(Entity consumer)
        {
        }

        public abstract bool Activate(ItemAction action);
    }
}