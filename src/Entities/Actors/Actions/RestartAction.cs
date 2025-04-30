using Godot;
namespace roguelike

{
	public partial class RestartAction : Action {

	public override void Perform(Game game, Entity entity) {
            game.map.GenerateDungeon(entity);

	}
 }
}
