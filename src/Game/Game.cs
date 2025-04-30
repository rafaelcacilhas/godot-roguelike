using Godot;
using roguelike.src.utils;
namespace roguelike{

public partial class Game : Node2D
{		
	Vector2I playerGridPos = Vector2I.Zero;
	Entity player;
		readonly EntityDefinition playerDefinition = ResourceLoader
			.Load<EntityDefinition>("res://assets/definitions/entities/actors/entity_definition_player.tres");
	EventHandler eventHandler;
	Node2D entities;
	public Map map;
	public const int GAME_SCALE = 2;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready(){
		eventHandler = GetNode<EventHandler>("EventHandler");
		entities = GetNode<Node2D>("Entities");
		map = GetNode<Map>("Map");
		var camera = GetNode<Camera2D>("Camera2D");

		player = new Entity( Vector2I.Zero, playerDefinition);
		RemoveChild(camera);
		player.AddChild(camera);
		entities.AddChild(player);

		map.GenerateDungeon(player);
		map.UpdateFov(player.GridPosition);
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
		
	public override void _PhysicsProcess(double delta)
	{
		var action = eventHandler.GetAction();
		if (action != null) {
			var previousPosition = player.GridPosition;
			action?.Perform(this, player);

			if(player.GridPosition != previousPosition){
				map.UpdateFov(player.GridPosition);
			}

		}
	}
}

}
