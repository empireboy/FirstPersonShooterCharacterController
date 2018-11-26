using UnityEngine;

namespace CM.Orientation
{
	public class RigidbodyMovementInputTest : MonoBehaviour, IInput
	{
		private Vector3 input = Vector3.zero;

		public Vector3 GetInput()
		{
			return input;
		}

		private void Update()
		{
			input = Vector3.zero;
			input.x = Input.GetAxis("Horizontal");
			input.z = Input.GetAxis("Vertical");
		}
	}
}