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
	Map map;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready(){
		eventHandler = GetNode<EventHandler>("EventHandler");
		entities = GetNode<Node2D>("Entities");
		map = GetNode<Map>("Map");

		var size = GetViewportRect().Size.Floor() / 2;
		var player_start_pos = Grid.WorldToGrid((Vector2I)size);	
		player = new Entity(player_start_pos, playerDefinition);
		entities.AddChild(player);

		GD.Print("player.GridPosition: ", player.GridPosition);

		var npc = new Entity(player_start_pos + Vector2I.Right, playerDefinition);
		npc.Modulate = Colors.OrangeRed;
		entities.AddChild(npc);
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
		action?.Perform(this, player);
	}
}

}
