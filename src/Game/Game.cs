using Godot;
namespace roguelike{

	public partial class Game : Node2D
	{		
		public const int GAME_SCALE = 2;

		Vector2I playerGridPos = Vector2I.Zero;
		Entity player;
		readonly EntityDefinition playerDefinition = ResourceLoader
				.Load<EntityDefinition>("res://assets/definitions/entities/actors/entity_definition_player.tres");

		InputHandler inputHandler;
		public Map map;

		public override void _Ready(){
			inputHandler = GetNode<InputHandler>("EventHandler");
			map = GetNode<Map>("Map");
			var camera = GetNode<Camera2D>("Camera2D");
			RemoveChild(camera);

			player = new Entity( Vector2I.Zero, playerDefinition, map.MapData);	
			player.AddChild(camera);

			map.GenerateDungeon(player);
			map.UpdateFov(player.GridPosition);
		}

		public override void _PhysicsProcess(double delta)
		{
			var action = inputHandler.GetAction(player);

			if (action != null) {
				action?.Perform();
				HandleEnemyTurn();
				map.UpdateFov(player.GridPosition);
			}
		}

		public void HandleEnemyTurn()
		{
			foreach (var entity in GetMapData().Entities)
			{
				if (entity != player && entity.IsAlive() ){
					GD.Print( entity.GetEntityName(), " performing Action");
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
