namespace roguelike
{
	public partial class WaitAction : Action
	{
		public WaitAction(Entity entity) : base(entity) { }

		public override bool Perform()
		{
			return true;
		}
	}
}
