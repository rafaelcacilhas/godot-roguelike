using Godot;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace roguelike
{
	public partial class MainGameInputHandler : BaseInputHandler
	{
		public readonly Dictionary<string, Vector2I> directions = new()
		{
			{"move_up",  Vector2I.Up},
			{"move_down", Vector2I.Down},
			{"move_left", Vector2I.Left},
			{"move_right", Vector2I.Right},
			{"move_up_left", Vector2I.Up + Vector2I.Left},
			{"move_up_right", Vector2I.Up + Vector2I.Right},
			{"move_down_left", Vector2I.Down + Vector2I.Left},
			{"move_down_right", Vector2I.Down + Vector2I.Right},
		};

		private PackedScene inventoryMenuScene;

        public override void _Ready()
        {
			inventoryMenuScene = ResourceLoader.Load<PackedScene>(
			"res://src/GUI/InventoryMenu/inventory_menu.tscn"
			);
        }

		public async Task<Entity> GetItemAsync(string windowTitle, InventoryComponent inventory)
		{
			if (inventory.Items.Count == 0)
			{
				MessageLog.SendMessage("Inventory is empty!", Colors.IMPOSSIBLE);
				return null;
			}
			var inventoryMenu = inventoryMenuScene.Instantiate<InventoryMenu>();
			AddChild(inventoryMenu);

			inventoryMenu.Build(windowTitle, inventory);

			GetParent<InputHandler>().TransitionTo(InputHandler.InputHandlers.DUMMY);

			var selectedItem = await ToSignal(inventoryMenu, InventoryMenu.SignalName.ItemSelected);
			await ToSignal(GetTree(), SceneTree.SignalName.PhysicsFrame);

			GetParent<InputHandler>().CallDeferred(nameof(InputHandler.TransitionTo), (int)InputHandler.InputHandlers.MAIN_GAME);
			return (Entity)selectedItem?.FirstOrDefault();
		}

		public override async Task<Action> GetActionAsync(Entity player)
		{
			Action action = null;

			foreach (var direction in directions.Keys)
			{
				if (Input.IsActionJustPressed(direction))
				{
					var offset = directions[direction];
					action = new BumpAction(player, offset.X, offset.Y);
				}
			}

			if (Input.IsActionJustPressed("grab_item")) action = new PickupAction(player);
			if (Input.IsActionJustPressed("leave_item"))
			{
				var selectedItem = await GetItemAsync("Select an item to drop", player.InventoryComponent);
				action = new DropItemAction(player, selectedItem);
			}
			if (Input.IsActionJustPressed("item_activate"))
			{
				var selectedItem = await GetItemAsync("Select an item to use", player.InventoryComponent);
				action = new ItemAction(player, selectedItem);
			}

			if (Input.IsActionJustPressed("ui_cancel")) action = new EscapeAction(player);
			if (Input.IsActionJustPressed("ui_text_backspace")) action = new RestartAction(player);

			if (Input.IsActionJustPressed("view_history")) GetParent<InputHandler>().TransitionTo(InputHandler.InputHandlers.HISTORY_VIEWER);

			return action;
		}
	}
}