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

        Node2D tiles;
	    Node2D entities;
        public override void _Ready()
        {
            dungeonGenerator = GetNode<DungeonGenerator>("MapGenerator");
            FieldOfView = GetNode<FieldOfView>("FieldOfView");
            entities = GetNode<Node2D>("Entities");
		    tiles = GetNode<Node2D>("Tiles");
        }

        public void GenerateDungeon(Entity player)
        {
            MapData = dungeonGenerator.GenerateDungeon(player);
            PlaceTiles();
            PlaceEntities(player);
        }

        private void PlaceTiles()
        {
            foreach (var tile in MapData.Tiles)
            {
                tiles.AddChild(tile);
            }
        }
        private void PlaceEntities(Entity player)
        {
            foreach (var entity in MapData.Entities)
            {
                entities.AddChild(entity);
            }
        }
        public void UpdateFov(Vector2I playerGridPos)
        {
            FieldOfView.UpdateFov(MapData, playerGridPos, FovRadius);

            foreach (var entity in MapData.Entities)
            {
                entity.Visible = MapData.GetTile(entity.GridPosition).IsInView;
            }
        }

    }
}