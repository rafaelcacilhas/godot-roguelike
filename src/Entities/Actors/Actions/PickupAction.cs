using Godot;

namespace roguelike
{
	public partial class PickupAction : Action
	{
		public PickupAction(Entity entity) : base(entity)
		{
		}

		public override bool Perform()
		{
			var inventory = Entity.InventoryComponent;

			var mapData = GetMapData();
			foreach (var item in mapData.GetItems())
			{
				if (Entity.GridPosition == item.GridPosition)
				{

					if (inventory.Items.Count >= inventory.Capacity)
					{
						MessageLog.SendMessage("Your inventory is full", Colors.IMPOSSIBLE);
						return false;
					}

					mapData.Entities.Remove(item);
					item.GetParent().RemoveChild(item);
					inventory.Items.Add(item);
					MessageLog.SendMessage($"You pick up the {item.Name}", Colors.White);
					return true;
				}
			}
			MessageLog.SendMessage("There's nothing here to pickup", Colors.White);
			return false;
		}
	}
}


