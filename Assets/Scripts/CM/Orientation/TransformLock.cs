using UnityEngine;

namespace CM.Orientation
{
	public class TransformLock : MonoBehaviour
	{
		public float positionSpeed = 3;
		public float rotationSpeed = 3;

		[SerializeField] private Vector3 _targetPosition;
		[SerializeField] private Vector3 _targetRotation;
		
		private Vector3 _targetPositionStart;
		private Vector3 _targetRotationStart;

		private void Start()
		{
			_targetPositionStart = _targetPosition;
			_targetRotationStart = _targetRotation;
		}

		private void Update()
		{
			transform.localPosition = Vector3.Lerp(transform.localPosition, _targetPosition, Time.deltaTime * positionSpeed);
			transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(_targetRotation), Time.deltaTime * rotationSpeed);
		}

		public void SetPosition(Vector3 position)
		{
			_targetPosition = position;
		}

		public void SetRotation(Vector3 rotation)
		{
			_targetRotation = rotation;
		}

		public void ResetPosition()
		{
			_targetPosition = _targetPositionStart;
		}

		public void ResetRotation()
		{
			_targetRotation = _targetRotationStart;
		}

		public void ResetTransform()
		{
			ResetPosition();
			ResetRotation();
		}
	}
}
