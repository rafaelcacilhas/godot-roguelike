using Godot;
namespace roguelike{
	public partial class ActionWithDirection : Action {
        public Vector2I Offset { get; set; } = Vector2I.Zero;
        public ActionWithDirection() {  }
        public ActionWithDirection(int dx, int dy) {
            Offset = new Vector2I(dx, dy);
        }

        public override void Perform(Game game, Entity entity) {
            throw new System.Exception("Calling ActionWithDirection Perform().");
        }
 }
}
