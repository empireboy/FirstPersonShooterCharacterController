using UnityEngine;

namespace CM.Orientation
{
	public class RigidbodyMovementInput : MonoBehaviour
	{
		public string horizontalAxis = "Horizontal";
		public string verticalAxis = "Vertical";

		private Vector3 _inputs;

		private void Update()
		{
			_inputs = Vector3.zero;
			_inputs.x = Input.GetAxis(horizontalAxis);
			_inputs.z = Input.GetAxis(verticalAxis);
		}

		public Vector3 GetInput()
		{
			return _inputs;
		}
	}
}