using Godot;
namespace roguelike
{
	public partial class Colors : RefCounted
	{
		public static readonly Color White = ColorPallete.White;
        public static readonly Color UIDetails =  ColorPallete.Reds[7];

		public static readonly Color DEATH =  ColorPallete.Reds[7];
		public static readonly Color PLAYER_ATTACK = ColorPallete.Greys[3];
		public static readonly Color ENEMY_ATTACK = ColorPallete.Reds[2];
		public static readonly Color PLAYER_DIE = ColorPallete.Reds[8];
		public static readonly Color ENEMY_DIE = ColorPallete.Oranges[5];
		public static readonly Color WELCOME_TEXT = ColorPallete.Blues[5];

		public static readonly Color INVALID = new Color("ffff00");
		public static readonly Color IMPOSSIBLE = new Color("808080");
		public static readonly Color ERROR = new Color("ff4040");
		public static readonly Color HEALTH_RECOVERED = new Color("00ff00");
		public static readonly Color STATUS_EFFECT_APPLIED = new Color("3fff3f");

	}

}
