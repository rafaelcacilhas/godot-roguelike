using Godot;
namespace roguelike
{
    public partial class BaseAIComponent : Component
    {
        public virtual void Perform()
        {
        }
        public Vector2[] GetPointPathTo(Vector2I destination)
        {
            return GetMapData().Pathfinder.GetPointPath(Entity.GridPosition, destination);
        }
    }
}