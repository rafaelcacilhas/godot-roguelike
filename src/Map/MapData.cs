using Godot;
using Godot.Collections;

namespace roguelike
{
    public partial class MapData : RefCounted
    {
        public const string FLOOR = "floor";
        public const string WALL = "wall";
        public static readonly Dictionary<string, TileDefinition> tileTypes = new Dictionary<string, TileDefinition> {
            { FLOOR, ResourceLoader.Load<TileDefinition>("res://assets/definitions/tiles/tile_definition_floor.tres") },
            { WALL, ResourceLoader.Load<TileDefinition>("res://assets/definitions/tiles/tile_definition_wall.tres") },
        };

        public int Width { get; set; }
        public int Height { get; set; }
        public Array<Tile> Tiles { get; set; }
        public Array<Entity> Entities { get; set; } = new Array<Entity>();
        public Entity Player;

        public float EntityPathfindingWeight = 10;
        public AStarGrid2D Pathfinder;
        public MapData(int mapWidth, int mapHeight, Entity player)
        {
            Width = mapWidth;
            Height = mapHeight;
            Player = player;
            SetupTiles();
        }
        private void SetupTiles()
        {
            Tiles = new Array<Tile>();
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    var tilePosition = new Vector2I(x, y);
                    var tile = new Tile(tilePosition, tileTypes[WALL]);
                    Tiles.Add(tile);
                }
            }

        }

        public Tile GetTile(Vector2I gridPosition)
        {
            var tileIndex = GridToIndex(gridPosition);
            if (tileIndex == -1)
            {
                GD.PrintErr($"Grid position {gridPosition} is out of bounds.");
                return null;
            }
            if (tileIndex >= Tiles.Count)
            {
                GD.PrintErr($"Tile index {tileIndex} is invalid. Tiles count: {Tiles.Count}");
                return null;
            }
            return Tiles[tileIndex];
        }

        private int GridToIndex(Vector2I gridPosition)
        {
            if (!IsInBounds(gridPosition)) return -1;
            return gridPosition.Y * Width + gridPosition.X;
        }

        public bool IsInBounds(Vector2I coordinate)
        {
            return coordinate.X >= 0
                && coordinate.X < Width
                && coordinate.Y >= 0
                && coordinate.Y < Height;
        }

        public bool HasBlockingEntity(Vector2I gridPosition)
        {
            foreach (var entity in Entities)
            {
                if (entity.GridPosition == gridPosition && entity.IsBlockingMovement())
                {
                    return true;
                }
            }
            return false;
        }

        public Entity GetEntityAtLocation(Vector2I gridPosition)
        {
            foreach (var entity in Entities)
            {
                if (entity.GridPosition == gridPosition)
                {
                    return entity;
                }
            }
            return null;
        }

        public void RegisterBlockingEntity(Entity entity)
        {
            Pathfinder.SetPointWeightScale(entity.GridPosition, EntityPathfindingWeight);
        }

        public void UnregisterBlockingEntity(Entity entity)
        {
            Pathfinder.SetPointWeightScale(entity.GridPosition, 0);
        }

        public void SetupPathfinding()
        {
            Pathfinder = new AStarGrid2D();
            Pathfinder.Region = new Rect2I(0, 0, Width, Height);
            Pathfinder.Update();

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    var gridPosition = new Vector2I(x, y);
                    var tile = GetTile(gridPosition);
                    Pathfinder.SetPointSolid(gridPosition, !tile.IsWalkable());
                }
            }

            foreach (var entity in Entities)
            {
                if (entity.IsBlockingMovement())
                {
                    RegisterBlockingEntity(entity);
                }
            }

        }

        public Array<Entity> GetActors()
        {
            var actors = new Array<Entity>();
            foreach (var entity in Entities)
            {
                if (entity.IsAlive()) actors.Add(entity);
            }
            return actors;
        }

        public Entity GetActorAtLocation(Vector2I gridPosition)
        {
            foreach (var actor in GetActors())
            {
                if (actor.GridPosition == gridPosition)
                {
                    return actor;
                }
            }
            return null;
        }


    }
}