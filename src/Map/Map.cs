using Godot;

namespace roguelike
{
    public partial class Map : Node2D
    {
        [Export]
        public int MapWidth { get; set; } = 80;

        [Export]
        public int MapHeight { get; set; } = 45;

        [Export]
        public int FovRadius { get; set; } = 8;

        public MapData MapData { get; set; }
        private DungeonGenerator dungeonGenerator;
        public FieldOfView FieldOfView { get; set; }
        public override void _Ready()
        {
            dungeonGenerator = GetNode<DungeonGenerator>("MapGenerator");
            FieldOfView = GetNode<FieldOfView>("FieldOfView");
        }

        public void GenerateDungeon(Entity player)
        {
            MapData = dungeonGenerator.GenerateDungeon(player);
            PlaceTiles();
        }

        private void PlaceTiles()
        {
            foreach (var tile in MapData.Tiles)
            {
                AddChild(tile);
            }
        }
        public void UpdateFov(Vector2I playerGridPos)
        {
            FieldOfView.UpdateFov(MapData, playerGridPos, FovRadius);
        }
    }
}