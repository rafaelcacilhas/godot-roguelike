using Godot;
namespace roguelike
{

	public partial class Game : Node2D
	{
		public const int GAME_SCALE = 2;

		[Signal]
		public delegate void PlayerCreatedEventHandler(Entity player);
		Vector2I playerGridPos = Vector2I.Zero;
		Entity player;
		readonly EntityDefinition playerDefinition = ResourceLoader
				.Load<EntityDefinition>("res://assets/definitions/entities/actors/entity_definition_player.tres");

		InputHandler inputHandler;
		public Map map;

		public override void _Ready()
		{
			inputHandler = GetNode<InputHandler>("InputHandler");
			map = GetNode<Map>("Map");
			var camera = GetNode<Camera2D>("Camera2D");
			RemoveChild(camera);

			player = new Entity(Vector2I.Zero, playerDefinition, map.MapData);
			player.AddChild(camera);
			EmitSignal(SignalName.PlayerCreated, player);

			map.GenerateDungeon(player);
			map.UpdateFov(player.GridPosition);

			MessageLog.SendMessage("Welcome Adventurer!", Colors.WELCOME_TEXT);
		}

		public override void _PhysicsProcess(double delta)
		{
			if (inputHandler == null)
			{
				GD.PrintErr("inputHandler is null!");
				return;
			}

			if (player == null)
			{
				GD.PrintErr("player is null!");
				return;
			}

			if (map == null || map.MapData == null)
			{
				GD.PrintErr("map or map.MapData is null!");
				return;
			}

			var action = inputHandler.GetAction(player);

			if (action != null)
			{
				action.Perform();
				HandleEnemyTurn();
				map.UpdateFov(player.GridPosition);
			}
		}

		public void HandleEnemyTurn()
		{
			foreach (var entity in GetMapData().Entities)
			{
				if (entity != player && entity.IsAlive())
				{
					GD.Print(entity.GetEntityName(), " performing Action");
					entity.AIComponent?.Perform();
				}
			}
		}

		public MapData GetMapData()
		{
			if (map == null || map.MapData == null)
			{
				GD.PrintErr("Map or MapData is null!");
				return null;
			}
			return map.MapData;
		}
	}

}
