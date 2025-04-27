using Godot;
using System;
using roguelike.src.utils;

public partial class Game : Node
{
	Vector2I playerGridPos = Vector2I.Zero;
	Sprite2D player;
	EventHandler eventHandler;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		player = GetNode<Sprite2D>("Player");
		eventHandler = GetNode<EventHandler>("EventHandler");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var action = eventHandler.GetAction();
		GD.Print(" action");

		if(action is MovementAction movementAction){
			playerGridPos += movementAction.Offset;
			player.Position = Grid.GridToWorld(playerGridPos);
		}
		else if(action is EscapeAction){
			GetTree().Quit();
		}
	}
}
