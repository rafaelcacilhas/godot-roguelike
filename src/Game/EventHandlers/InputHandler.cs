using System.Collections.Generic;
using System.Threading.Tasks;
using Godot;
namespace roguelike
{
	public partial class InputHandler : Node
	{
		public enum InputHandlers { MAIN_GAME, GAME_OVER, HISTORY_VIEWER, DUMMY }

		[Export]
		public InputHandlers StartInputHandler { get; set; }
		public Dictionary<InputHandlers, BaseInputHandler> inputHandlerNodes;

		BaseInputHandler currentInputHandler;
		public override void _Ready()
		{
			inputHandlerNodes = new()
			{
				{ InputHandlers.MAIN_GAME, GetNode<MainGameInputHandler>("MainGameInputHandler") },
				{ InputHandlers.GAME_OVER, GetNode<GameOverInputHandler>("GameOverInputHandler") },
				{ InputHandlers.HISTORY_VIEWER, GetNode<HistoryViewerInputHandler>("HistoryViewerInputHandler") },
				{ InputHandlers.DUMMY, GetNode<BaseInputHandler>("DummyInputHandler") },
			};

			GetNode<SignalBus>("/root/SignalBus").PlayerDied += () => TransitionTo(InputHandlers.GAME_OVER);
			TransitionTo(StartInputHandler);
		}

		public Task<Action> GetActionAsync(Entity player)
		{
			return currentInputHandler?.GetActionAsync(player);
		}

		public void TransitionTo(InputHandlers inputHandler)
		{
			if (inputHandlerNodes[inputHandler] == null)
			{
				GD.PrintErr($"No input handler found for {inputHandler}");
				return;
			}
			currentInputHandler?.Exit();
			currentInputHandler = inputHandlerNodes[inputHandler];

			currentInputHandler?.Enter();
		}
	}

}
