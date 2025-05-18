using Godot;
namespace roguelike
{
	public partial class Colors : RefCounted
	{
		public static readonly Color PLAYER_ATTACK = new Color("e0e0e0");
		public static readonly Color ENEMY_ATTACK = new Color("ffc0c0");
		public static readonly Color PLAYER_DIE = new Color("ff3030");
		public static readonly Color ENEMY_DIE = new Color("ffa030");
		public static readonly Color WELCOME_TEXT = new Color("20a0ff");

		public static readonly Color White = new Color("ffffff");
		public static readonly Color DarkRed = new Color("550000");
		public static readonly Color Red = new Color("ff0000");

	}

}
