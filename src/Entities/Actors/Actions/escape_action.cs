using Godot;
namespace roguelike{
    public partial class EscapeAction : Action {
    public override void Perform(Game game, Entity entity) {
        game.GetTree().Quit();
    }   
 }
}
