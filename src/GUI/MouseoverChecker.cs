using Godot;
using roguelike.src.utils;
using System;

namespace roguelike
{

	public partial class MouseoverChecker : Node2D
	{
		[Signal]
		public delegate void EntitiesFocusedEventHandler(string entityList);
		private Vector2I mouseTile = new Vector2I(-1, -1);
		private Map map;

		public override void _Ready()
		{
			map = GetParent<Map>();
		}

		public override void _UnhandledInput(InputEvent @event)
		{
			if (@event is InputEventMouseMotion)
			{
				var MousePosition = GetLocalMousePosition();
				var TilePosition = Grid.WorldToGrid((Vector2I)MousePosition);

				if (mouseTile != TilePosition)
				{
					mouseTile = TilePosition;
					EmitSignal(SignalName.EntitiesFocused, GetNamesAtLocation(TilePosition));
				}
			}

		}

		public string GetNamesAtLocation(Vector2I gridPosition)
		{
			var mapData = map.MapData;

			var tile = mapData.GetTile(gridPosition);
			if (tile == null || !tile.IsInView)
			{
				return string.Empty;
			}

			var entitiesAtLocation = mapData.GetBlockingEntityAtLocation(gridPosition);

			return entitiesAtLocation?.GetEntityName();
		}
	}

}