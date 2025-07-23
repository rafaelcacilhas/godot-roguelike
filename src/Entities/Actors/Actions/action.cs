using Godot;
namespace roguelike
{
	public partial class Action : RefCounted
	{

		public Entity Entity { get; set; }

		public Action(Entity entity)
		{
			Entity = entity;
		}
		public virtual bool Perform()
		{
			return false;
		}

		public MapData GetMapData()
		{
			if (Entity == null || Entity.MapData == null)
			{
				GD.PrintErr("Entity or MapData is null!");
				return null;
			}
			return Entity.MapData;
		}
	}
}
