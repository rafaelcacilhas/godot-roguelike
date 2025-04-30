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
        public int MaxRooms { get; set; } = 5;
        [Export]
        public int RoomMinSize { get; set; } = 5;
        [Export]
        public int RoomMaxSize { get; set; } = 10;

        RandomNumberGenerator rng = new RandomNumberGenerator();

        public MapData GenerateDungeon(Entity player){
			var dungeon = new MapData(MapWidth, MapHeight);
			var rooms = new Array<Rect2I>();

            for (int currentRoom = 0; currentRoom < MaxRooms; currentRoom++)
            {
                var roomWidth = rng.RandiRange(RoomMinSize, RoomMaxSize);
                var roomHeight = rng.RandiRange(RoomMinSize, RoomMaxSize);
                GD.Print($"Room {currentRoom}: {roomWidth}x{roomHeight}");
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
                } else {
                    TunnelBetween(dungeon, rooms.Last().GetCenter(), newRoom.GetCenter());
                }
                
                PlaceEntities(dungeon, newRoom);
                PlaceItems(dungeon, newRoom);
                rooms.Add(newRoom);
            }
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
        
        private void PlaceEntities(MapData dungeon, Rect2I room){

        }
        private void PlaceItems(MapData dungeon, Rect2I room){

        }
        public override void _Ready()
        {
            rng.Randomize();
        }
    } 
}