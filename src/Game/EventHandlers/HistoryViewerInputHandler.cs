using Godot;

namespace roguelike
{
    public partial class HistoryViewerInputHandler : BaseInputHandler
    {
        private const int ScrollStep = 16;

        [Export(PropertyHint.NodePathValidTypes, "PanelContainer")]
        public NodePath MessagesPanelPath { get; set; }

        [Export(PropertyHint.NodePathValidTypes, "ScrollContainer")]
        public NodePath MessageLogPath { get; set; }

        private PanelContainer messagePanel;
        private MessageLog messageLog;

        public override void _Ready()
        {
            messagePanel = GetNode<PanelContainer>(MessagesPanelPath);
            messageLog = GetNode<MessageLog>(MessageLogPath);
        }
        public override void Enter() =>
            messagePanel.SelfModulate = Colors.Red;

        public override void Exit() =>
            messagePanel.SelfModulate = Colors.White;


        public override Action GetAction(Entity player)
        {
            Action action = null;

            if (Input.IsActionJustPressed("move_up")) messageLog.ScrollVertical -= ScrollStep;
            else if (Input.IsActionJustPressed("move_down")) messageLog.ScrollVertical += ScrollStep;
            else if (Input.IsActionJustPressed("move_left")) messageLog.ScrollVertical = 0;
            else if (Input.IsActionJustPressed("move_right"))
                messageLog.ScrollVertical = (int)messageLog.GetVScrollBar().MaxValue;

            if (Input.IsActionJustPressed("view_history") || Input.IsActionJustPressed("ui_back"))
                GetParent<InputHandler>().TransitionTo(InputHandler.InputHandlers.MAIN_GAME);

            if (Input.IsActionJustPressed("quit"))
                GetTree().Quit();

            return action;
        }
    }
}
