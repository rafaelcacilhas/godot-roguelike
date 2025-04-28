using Godot;
namespace roguelike{
	public partial class Action : RefCounted {
		public virtual void Perform(Game game, Entity entity) { 
			throw new System.Exception("Calling base Action Perform()."); 
		}
 }
}
