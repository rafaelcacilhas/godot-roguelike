using Godot;

namespace roguelike{
    public partial class HostileEnemyAIComponent: BaseAIComponent {
        Vector2[] path;

        public override void Perform(){
            var target = GetMapData().Player;
            var targetPos = target.GridPosition;
            var offset = targetPos - Entity.GridPosition;
            var distance = Mathf.Max( Mathf.Abs(offset.X), Mathf.Abs(offset.Y));

            if ( GetMapData().GetTile(Entity.GridPosition).IsInView){
                if (distance <= 1) new MeleeAction(Entity, offset.X,offset.Y).Perform();
                
                path = GetPointPathTo(targetPos);
                path = path[1..^0]; // Remove the first element (the current position)

                if (path != null && path.Length > 0) {
                    var destination = (Vector2I)path[0];
                    if (GetMapData().GetBlockingEntityAtLocation(destination) != null) new WaitAction(Entity).Perform();
                    
                    path = path[1..^0];
                    var moveOffset = destination - Entity.GridPosition; 
                    new MovementAction(Entity, moveOffset.X, moveOffset.Y).Perform();           
                }
            }
        }
    }
}