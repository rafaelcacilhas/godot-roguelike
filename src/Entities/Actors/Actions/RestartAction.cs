namespace roguelike

{
	public partial class RestartAction : Action
	{
		public RestartAction(Entity entity) : base(entity) { }
		public override bool Perform()
		{
			return false;
		}
	}
}
