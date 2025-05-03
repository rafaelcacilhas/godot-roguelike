using Godot;

namespace roguelike
{
    [GlobalClass]
    public partial class FighterComponentDefinition : Resource
    {
        [ExportCategory("Stats")]

        [Export]
        public int MaxHP { get; set; }
        [Export]
        public int Attack { get; set; }
        [Export]
        public int Defense { get; set; }

        [ExportCategory("Visuals")]

        [Export]
        public AtlasTexture DeathTexture { get; set; }

        [Export]
        public Color DeathColor { get; set; } = Colors.DarkRed;
    }
}