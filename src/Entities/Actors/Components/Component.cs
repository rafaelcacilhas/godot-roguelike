using Godot;

namespace roguelike{
    public partial class Component : Node2D {
        public Entity Entity { get; set; } 

        public override void _Ready()
        {
            Entity = GetParent() as Entity;
        }
        public MapData GetMapData()
        {
            return Entity.MapData;
        }   
    }
}