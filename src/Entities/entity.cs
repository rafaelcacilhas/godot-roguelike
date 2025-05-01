using System;
using Godot;
using roguelike.src.utils;

namespace roguelike
{
    public partial class Entity : Sprite2D
    {
        private EntityDefinition entityDefinition;
        public EntityDefinition EntityDefinition
        {
            get => entityDefinition;
            set
            {
                entityDefinition = value;
                Texture = entityDefinition.Texture;
                Modulate = entityDefinition.Color;
            }
        }
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

            Centered = false;
            GridPosition = startPosition;
            Scale = new Vector2(Game.GAME_SCALE,Game.GAME_SCALE);
            EntityDefinition = entityDefinition;
        }

        public void Move(Vector2I destination)
        {
            GridPosition = destination;
        }
    
        public bool IsBlockingMovement()
        {
            return EntityDefinition.isBlockingMovement;
        }

        public String GetEntityName()
        {
            return EntityDefinition.Name;
        }
    }
}