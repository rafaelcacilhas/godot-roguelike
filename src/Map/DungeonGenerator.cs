using Godot;
using Godot.Collections;
using System.Linq;

namespace roguelike{    
    public partial class DungeonGenerator : Node { 
        [ExportCategory("Map Dimensions")]
        [Export]
        public int MapWidth { get; set; } = 70;
        [Export]
        public int MapHeight { get; set; } = 40;

        [ExportCategory("Rooms RNG")]
        [Export]
        public int MaxRooms { get; set; } = 2;
        [Export]
        public int RoomMinSize { get; set; } = 5;
        [Export]
        public int RoomMaxSize { get; set; } = 10;

        [ExportCategory("Monsters RNG")]
        [Export]
        public int MaxMonstersPerRoom { get; set; } = 5;
        [Export]
        public int MaxItemsPerRoom { get; set; } = 2;

        public const string ORC = "orc";
        public const string TROLL = "troll";
        public const string HEALTH_POTION = "health_potion";

		public static readonly Dictionary<string, EntityDefinition> entityTypes = new(){
            { ORC, ResourceLoader.Load<EntityDefinition>("res://assets/definitions/entities/actors/entity_definition_orc.tres") },
            { TROLL, ResourceLoader.Load<EntityDefinition>("res://assets/definitions/entities/actors/entity_definition_troll.tres") },
            { HEALTH_POTION, ResourceLoader.Load<EntityDefinition>("res://assets/definitions/entities/items/health_potion_definition.tres") },
        };
    
        RandomNumberGenerator rng = new RandomNumberGenerator();

        public MapData GenerateDungeon(Entity player){
			var dungeon = new MapData(MapWidth, MapHeight, player);
			var rooms = new Array<Rect2I>();
            dungeon.Entities.Add(player);

            for (int currentRoom = 0; currentRoom < MaxRooms; currentRoom++)
            {
                var roomWidth = rng.RandiRange(RoomMinSize, RoomMaxSize);
                var roomHeight = rng.RandiRange(RoomMinSize, RoomMaxSize);
                var roomX = rng.RandiRange(1, MapWidth - roomWidth - 1);
                var roomY = rng.RandiRange(1, MapHeight - roomHeight - 1);
                var newRoom = new Rect2I(roomX, roomY, roomWidth, roomHeight);

                var hasIntersections = rooms.Any(room => room.Intersects(newRoom.Grow(-1)));
                if (hasIntersections)
                {
                    currentRoom--;
                    continue;
                }
    
                CarveRoom(dungeon, newRoom);

                if(!rooms.Any()){
                    player.GridPosition = newRoom.GetCenter();
                    player.MapData = dungeon;
                } else {
                    TunnelBetween(dungeon, rooms.Last().GetCenter(), newRoom.GetCenter());
                }
                
                PlaceEntities(dungeon, newRoom);
                PlaceItems(dungeon, newRoom);
                rooms.Add(newRoom);
            }
            dungeon.SetupPathfinding();
            return dungeon;
        }
    
        private static void CarveTile(MapData dungeon, int x, int y)
        {
            var tilePosition = new Vector2I(x, y);
            var tile = dungeon.GetTile(tilePosition);
            tile.SetTileType(MapData.tileTypes[MapData.FLOOR]);
        }
        private static void CarveRoom(MapData dungeon,Rect2I room)
        {
            var inner = room.Grow(-1);
            for (int x = inner.Position.X; x < inner.End.X; x++)
            {
                for (int y = inner.Position.Y; y < inner.End.Y; y++)
                {
                    CarveTile(dungeon, x, y);
                }
            }
        }

        private static void TunnelHorizontal(MapData dungeon, int y, int xStart, int xEnd)
        {
            var xMin = Mathf.Min(xStart, xEnd);
            var xMax = Mathf.Max(xStart, xEnd);
            for (int x = xMin; x <= xMax; x++)
            {
                CarveTile(dungeon, x, y);
            }
        }

        private static void TunnelVertical(MapData dungeon, int x, int yStart, int yEnd)
        {
            var yMin = Mathf.Min(yStart, yEnd);
            var yMax = Mathf.Max(yStart, yEnd);
            for (int y = yMin; y <= yMax; y++)
            {
                CarveTile(dungeon, x, y);
            }
        }
        
        private void TunnelBetween(MapData dungeon, Vector2I start, Vector2I end){
            if (rng.Randf() < 0.5){
                TunnelHorizontal(dungeon, start.Y, start.X, end.X);
                TunnelVertical(dungeon, end.X, start.Y, end.Y);
            }
            else { 
                TunnelVertical(dungeon, start.X, start.Y, end.Y);
                TunnelHorizontal(dungeon, end.Y, start.X, end.X);
            }
        }

        private void PlaceEntities(MapData dungeon, Rect2I room)
        {
            var numberOfMonsters = rng.RandiRange(1, MaxMonstersPerRoom);
            for (int i = 0; i < numberOfMonsters; i++)
            {
                var monsterX = rng.RandiRange(room.Position.X + 1, room.End.X - 1);
                var monsterY = rng.RandiRange(room.Position.Y + 1, room.End.Y - 1);
                var monsterPosition = new Vector2I(monsterX, monsterY);

                var canPlaceMonster = checkBlockers(dungeon, monsterPosition);
                if (canPlaceMonster)
                {
                    var random = rng.RandiRange(0, 1);
                    var monster = random < 0.5 ? new Entity(monsterPosition, entityTypes[ORC], dungeon) : new Entity(monsterPosition, entityTypes[TROLL], dungeon);
                    dungeon.Entities.Add(monster);
                }
            }

            var numberOfItems = rng.RandiRange(1, MaxItemsPerRoom);
            for (int i = 0; i < numberOfItems; i++)
            {
                var itemX = rng.RandiRange(room.Position.X + 1, room.End.X - 1);
                var itemY = rng.RandiRange(room.Position.Y + 1, room.End.Y - 1);
                var itemPosition = new Vector2I(itemX, itemY);

                var canPlaceItem  = checkBlockers(dungeon, itemPosition);
                if (canPlaceItem)
                {
                    var item = new Entity(itemPosition, entityTypes[HEALTH_POTION], dungeon);
                    dungeon.Entities.Add(item);
                }
            }
        }
        private void PlaceItems(MapData dungeon, Rect2I room){

        }
        public override void _Ready()
        {
            rng.Randomize();
        }

        private bool checkBlockers(MapData dungeon, Vector2I monsterPosition){
            if(dungeon.GetTile(monsterPosition) == null || !dungeon.GetTile(monsterPosition).IsWalkable()){
                return false;
            }

            foreach (var entity in dungeon.Entities)
            {
                if (entity.GridPosition == monsterPosition)
                {
                    return false;
                }
            }

            return true;
        }
    } 
}