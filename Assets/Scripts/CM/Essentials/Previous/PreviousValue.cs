namespace CM.Previous
{
	public class PreviousValue<T> where T : struct
	{
		protected T value;
		public T Value
		{
			get
			{
				return value;
			}
		}

		public PreviousValue()
		{
			UpdateCaller.AddUpdateCallback(OnValueUpdate);
		}

		public virtual void OnValueUpdate() { }
	}
}