using Godot;
using System;

public partial class SignalBus : Node
{
	public static SignalBus Instance { get; private set; }

	[Signal]
	public delegate void PlayerDiedEventHandler();

	[Signal]
	public delegate void MessageSentEventHandler(string text, Color color);

	public SignalBus()
	{
		Instance = this;
	}
}
