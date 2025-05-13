using System;
using Godot;
using roguelike.src.utils;

namespace roguelike
{
    public partial class Entity : Sprite2D
    {
        public enum AIType { NONE, HOSTILE }
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
        public MapData MapData;
        public string EntityName { get; set; }
        public bool BlocksMovement { get; set; }

        public FighterComponent FighterComponent { get; set; }
        public BaseAIComponent AIComponent { get; set; }

        private EntityType entityType;
        public EntityType EntityType
        {
            get => entityType;
            set
            {
                entityType = value;
                ZIndex = (int)entityType;
            }
        }

        public Entity() { }

        public Entity(Vector2I startPosition, EntityDefinition entityDefinition, MapData mapData)
        {
            Scale = new Vector2(Game.GAME_SCALE, Game.GAME_SCALE);
            Centered = false;
            GridPosition = startPosition;
            EntityDefinition = entityDefinition;
            MapData = mapData;
            SetEntityType(entityDefinition);
        }

        public void Move(Vector2I offset)
        {
            MapData.UnregisterBlockingEntity(this);
            GridPosition += offset;
            MapData.RegisterBlockingEntity(this);
        }

        public bool IsBlockingMovement()
        {
            return BlocksMovement;
        }

        public string GetEntityName()
        {
            return EntityDefinition.Name;
        }

        public bool IsAlive()
        {
            return AIComponent != null;
        }

        public void SetEntityType(EntityDefinition entityDefinition)
        {
            EntityDefinition = entityDefinition;
            BlocksMovement = entityDefinition.isBlockingMovement;
            EntityName = entityDefinition.Name;
            Texture = entityDefinition.Texture;
            Modulate = entityDefinition.Color;
            EntityType = entityDefinition.EntityType;

            switch (entityDefinition.AIType)
            {
                case AIType.HOSTILE:
                    AIComponent = new HostileEnemyAIComponent();
                    AddChild(AIComponent);
                    break;
            }

            if (entityDefinition.FighterDefinition != null)
            {
                FighterComponent = new FighterComponent(entityDefinition.FighterDefinition);
                AddChild(FighterComponent);
            }

        }

    }
}