using Godot;
namespace roguelike
{
	public partial class Colors : RefCounted
	{
		public static readonly Color White = new Color("ffffff");
		public static readonly Color DarkRed = new Color("550000");
		public static readonly Color Red = new Color("ff0000");


		public static readonly Color PLAYER_ATTACK = new Color("e0e0e0");
		public static readonly Color ENEMY_ATTACK = new Color("ffc0c0");
		public static readonly Color PLAYER_DIE = new Color("ff3030");
		public static readonly Color ENEMY_DIE = new Color("ffa030");
		public static readonly Color WELCOME_TEXT = new Color("20a0ff");

		public static readonly Color INVALID = new Color("ffff00");
		public static readonly Color IMPOSSIBLE = new Color("808080");
		public static readonly Color ERROR = new Color("ff4040");
		public static readonly Color HEALTH_RECOVERED = new Color("00ff00");

		public static readonly Color STATUS_EFFECT_APPLIED = new Color("3fff3f");

        public static readonly Color[] Reds =
        [
            new Color("#ffebee"),
            new Color("#ffcdd2"),
            new Color("#ef9a9a"),
            new Color("#e57373"),
            new Color("#ef5350"),
            new Color("#f44336"),
            new Color("#e53935"),
            new Color("#d32f2f"),
            new Color("#c62828"),
            new Color("#b71c1c"),
            new Color("#ff8a80"),
            new Color("#ff5252"),
            new Color("#ff1744"),
            new Color("#d50000"),
        ];

        public static readonly Color[] Pinks =
        [
            new Color("#fce4ec"),
            new Color("#f8bbd0"),
            new Color("#f48fb1"),
            new Color("#f06292"),
            new Color("#ec407a"),
            new Color("#e91e63"),
            new Color("#d81b60"),
            new Color("#c2185b"),
            new Color("#ad1457"),
            new Color("#880e4f"),
            new Color("#ff80ab"),
            new Color("#ff4081"),
            new Color("#f50057"),
            new Color("#c51162"),
        ];

        public static readonly Color[] Purples =
        [
            new Color("#f3e5f5"),
            new Color("#e1bee7"),
            new Color("#ce93d8"),
            new Color("#ba68c8"),
            new Color("#ab47bc"),
            new Color("#9c27b0"),
            new Color("#8e24aa"),
            new Color("#7b1fa2"),
            new Color("#6a1b9a"),
            new Color("#4a148c"),
            new Color("#ea80fc"),
            new Color("#e040fb"),
            new Color("#d500f9"),
            new Color("#aa00ff"),
        ];

        public static readonly Color[] DeepPurples =
        [
            new Color("#ede7f6"),
            new Color("#d1c4e9"),
            new Color("#b39ddb"),
            new Color("#9575cd"),
            new Color("#7e57c2"),
            new Color("#673ab7"),
            new Color("#5e35b1"),
            new Color("#512da8"),
            new Color("#4527a0"),
            new Color("#311b92"),
            new Color("#b388ff"),
            new Color("#7c4dff"),
            new Color("#651fff"),
            new Color("#6200ea"),
        ];

        public static readonly Color[] Indigos =
        [
            new Color("#e8eaf6"),
            new Color("#c5cae9"),
            new Color("#9fa8da"),
            new Color("#7986cb"),
            new Color("#5c6bc0"),
            new Color("#3f51b5"),
            new Color("#3949ab"),
            new Color("#303f9f"),
            new Color("#283593"),
            new Color("#1a237e"),
            new Color("#8c9eff"),
            new Color("#536dfe"),
            new Color("#3d5afe"),
            new Color("#304ffe"),
        ];

        public static readonly Color[] Blues =
        [
            new Color("#e3f2fd"),
            new Color("#bbdefb"),
            new Color("#90caf9"),
            new Color("#64b5f6"),
            new Color("#42a5f5"),
            new Color("#2196f3"),
            new Color("#1e88e5"),
            new Color("#1976d2"),
            new Color("#1565c0"),
            new Color("#0d47a1"),
            new Color("#82b1ff"),
            new Color("#448aff"),
            new Color("#2979ff"),
            new Color("#2962ff"),
        ];

        public static readonly Color[] LightBlues =
        [
            new Color("#e1f5fe"),
            new Color("#b3e5fc"),
            new Color("#81d4fa"),
            new Color("#4fc3f7"),
            new Color("#29b6f6"),
            new Color("#03a9f4"),
            new Color("#039be5"),
            new Color("#0288d1"),
            new Color("#0277bd"),
            new Color("#01579b"),
            new Color("#80d8ff"),
            new Color("#40c4ff"),
            new Color("#00b0ff"),
            new Color("#0091ea"),
        ];

        public static readonly Color[] Cyans =
        [
            new Color("#e0f7fa"),
            new Color("#b2ebf2"),
            new Color("#80deea"),
            new Color("#4dd0e1"),
            new Color("#26c6da"),
            new Color("#00bcd4"),
            new Color("#00acc1"),
            new Color("#0097a7"),
            new Color("#00838f"),
            new Color("#006064"),
            new Color("#84ffff"),
            new Color("#18ffff"),
            new Color("#00e5ff"),
            new Color("#00b8d4"),
        ];

        public static readonly Color[] Teals =
        [
            new Color("#e0f2f1"),
            new Color("#b2dfdb"),
            new Color("#80cbc4"),
            new Color("#4db6ac"),
            new Color("#26a69a"),
            new Color("#009688"),
            new Color("#00897b"),
            new Color("#00796b"),
            new Color("#00695c"),
            new Color("#004d40"),
            new Color("#a7ffeb"),
            new Color("#64ffda"),
            new Color("#1de9b6"),
            new Color("#00bfa5"),
        ];

        public static readonly Color[] Greens =
        [
            new Color("#e8f5e9"),
            new Color("#c8e6c9"),
            new Color("#a5d6a7"),
            new Color("#81c784"),
            new Color("#66bb6a"),
            new Color("#4caf50"),
            new Color("#43a047"),
            new Color("#388e3c"),
            new Color("#2e7d32"),
            new Color("#1b5e20"),
            new Color("#b9f6ca"),
            new Color("#69f0ae"),
            new Color("#00e676"),
            new Color("#00c853"),
        ];

        public static readonly Color[] LightGreens =
        [
            new Color("#f1f8e9"),
            new Color("#dcedc8"),
            new Color("#c5e1a5"),
            new Color("#aed581"),
            new Color("#9ccc65"),
            new Color("#8bc34a"),
            new Color("#7cb342"),
            new Color("#689f38"),
            new Color("#558b2f"),
            new Color("#33691e"),
            new Color("#ccff90"),
            new Color("#b2ff59"),
            new Color("#76ff03"),
            new Color("#64dd17"),
        ];

        public static readonly Color[] Limes =
        [
            new Color("#f9fbe7"),
            new Color("#f0f4c3"),
            new Color("#e6ee9c"),
            new Color("#dce775"),
            new Color("#d4e157"),
            new Color("#cddc39"),
            new Color("#c0ca33"),
            new Color("#afb42b"),
            new Color("#9e9d24"),
            new Color("#827717"),
            new Color("#f4ff81"),
            new Color("#eeff41"),
            new Color("#c6ff00"),
            new Color("#aeea00"),
        ];

        public static readonly Color[] Yellows =
        [
            new Color("#fffde7"),
            new Color("#fff9c4"),
            new Color("#fff59d"),
            new Color("#fff176"),
            new Color("#ffee58"),
            new Color("#ffeb3b"),
            new Color("#fdd835"),
            new Color("#fbc02d"),
            new Color("#f9a825"),
            new Color("#f57f17"),
            new Color("#ffff8d"),
            new Color("#ffff00"),
            new Color("#ffea00"),
            new Color("#ffd600"),
        ];

        public static readonly Color[] Ambers =
        [
            new Color("#fff8e1"),
            new Color("#ffecb3"),
            new Color("#ffe082"),
            new Color("#ffd54f"),
            new Color("#ffca28"),
            new Color("#ffc107"),
            new Color("#ffb300"),
            new Color("#ffa000"),
            new Color("#ff8f00"),
            new Color("#ff6f00"),
            new Color("#ffe57f"),
            new Color("#ffd740"),
            new Color("#ffc400"),
            new Color("#ffab00"),
        ];

        public static readonly Color[] Oranges =
        [
            new Color("#fff3e0"),
            new Color("#ffe0b2"),
            new Color("#ffcc80"),
            new Color("#ffb74d"),
            new Color("#ffa726"),
            new Color("#ff9800"),
            new Color("#fb8c00"),
            new Color("#f57c00"),
            new Color("#ef6c00"),
            new Color("#e65100"),
            new Color("#ffd180"),
            new Color("#ffab40"),
            new Color("#ff9100"),
            new Color("#ff6d00"),
        ];

        public static readonly Color[] DeepOranges =
        [
            new Color("#fbe9e7"),
            new Color("#ffccbc"),
            new Color("#ffab91"),
            new Color("#ff8a65"),
            new Color("#ff7043"),
            new Color("#ff5722"),
            new Color("#f4511e"),
            new Color("#e64a19"),
            new Color("#d84315"),
            new Color("#bf360c"),
            new Color("#ff9e80"),
            new Color("#ff6e40"),
            new Color("#ff3d00"),
            new Color("#dd2c00"),
        ];

        public static readonly Color[] Browns =
        [
            new Color("#efebe9"),
            new Color("#d7ccc8"),
            new Color("#bcaaa4"),
            new Color("#a1887f"),
            new Color("#8d6e63"),
            new Color("#795548"),
            new Color("#6d4c41"),
            new Color("#5d4037"),
            new Color("#4e342e"),
            new Color("#3e2723"),
        ];

        public static readonly Color[] Greys =
        [
            new Color("#fafafa"),
            new Color("#f5f5f5"),
            new Color("#eeeeee"),
            new Color("#e0e0e0"),
            new Color("#bdbdbd"),
            new Color("#9e9e9e"),
            new Color("#757575"),
            new Color("#616161"),
            new Color("#424242"),
            new Color("#212121"),
        ];

        public static readonly Color[] BlueGreys =
        [
            new Color("#eceff1"),
            new Color("#cfd8dc"),
            new Color("#b0bec5"),
            new Color("#90a4ae"),
            new Color("#78909c"),
            new Color("#607d8b"),
            new Color("#546e7a"),
            new Color("#455a64"),
            new Color("#37474f"),
            new Color("#263238"),
        ];


	}

}
