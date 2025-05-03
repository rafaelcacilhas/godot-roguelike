using Godot;
using roguelike.src.utils;

namespace roguelike
{
    public partial class Tile : Sprite2D
    {
        private TileDefinition definition;
        private bool isExplored = false;
        public bool IsExplored
        {
            get => isExplored;
            set
            {
                isExplored = value;
                if (isExplored && !Visible)
                {
                    Visible = true;
                }
            }
        }
        private bool isInView = false;
        public bool IsInView
        {
            get => isInView;
            set
            {       
                isInView = value;
                Modulate = isInView ? definition.ColorLit : definition.ColorDark;
                if (isInView && !isExplored)
                {
                    IsExplored = true;  
                }
            }
        }
        public Tile() { }
        public Tile(Vector2I gridPosition, TileDefinition tileDefinition)
        {
            Visible = false;
            Centered = false;
            Position = Grid.GridToWorld(gridPosition);
            SetTileType(tileDefinition);
            Scale = new Vector2(Game.GAME_SCALE, Game.GAME_SCALE);
        }

        public void SetTileType(TileDefinition tileDefinition)
        {
            definition = tileDefinition;
            Texture = definition.Texture;
            Modulate = definition.ColorDark;
        }

        public bool IsWalkable() =>
            definition.IsWalkable;

        public bool IsTransparent() =>
            definition.IsTransparent;
    }
}