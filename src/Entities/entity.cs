using Godot;
using roguelike.src.utils;

namespace roguelike
{
    public partial class Entity : Sprite2D
    {
        private Vector2I gridPosition;
        public Vector2I GridPosition
        {
            get => gridPosition;
            set
            {
                gridPosition = value;
                Position = Grid.GridToWorld(gridPosition);
            }
        }

        public Entity(){}

        public Entity(Vector2I startPosition, EntityDefinition entityDefinition)
        {
            Texture = entityDefinition.Texture;
            Modulate = entityDefinition.Color;
            Centered = false;
            GridPosition = startPosition;
        }

        public void Move(Vector2I destination)
        {
            GridPosition = destination;
        }
    }
}