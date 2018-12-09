using UnityEngine;

namespace CM.Orientation
{
	public abstract class MovementInputBase : MonoBehaviour
	{
		public string horizontalAxis = "Horizontal";
		public string verticalAxis = "Vertical";

		protected Vector3 inputs;

		private void Update()
		{
			inputs = Vector3.zero;
			inputs.x = Input.GetAxis(horizontalAxis);
			inputs.z = Input.GetAxis(verticalAxis);
		}

		public Vector3 GetInput()
		{
			return inputs;
		}
	}
}