using UnityEngine;
using NaughtyAttributes;

namespace CM.Orientation
{
	public class TransformLock : MonoBehaviour
	{
		public float positionSpeed = 3;
		public float rotationSpeed = 3;

		[SerializeField] private Vector3 _targetPosition;
		[SerializeField] private Vector3 _targetRotation;

		[Header("Sway Transform")]
		[SerializeField] private bool _sway = false;
		[ShowIf("_sway")]
		public Vector2 swayAmount = new Vector2(0.02f, 0.02f);
		[ShowIf("_sway")]
		public Vector2 maxSwayAmount = new Vector2(0.05f, 0.05f);

		private Vector3 _targetPositionStart;
		private Vector3 _targetRotationStart;

		private void Start()
		{
			_targetPositionStart = _targetPosition;
			_targetRotationStart = _targetRotation;
		}

		private void Update()
		{
			Vector3 swayPosition = Vector3.zero;

			if (_sway)
			{
				float swayX = -Input.GetAxis("Mouse X") * swayAmount.x;
				float swayY = -Input.GetAxis("Mouse Y") * swayAmount.y;
				swayX = Mathf.Clamp(swayX, -maxSwayAmount.x, maxSwayAmount.x);
				swayY = Mathf.Clamp(swayY, -maxSwayAmount.y, maxSwayAmount.y);
				swayPosition = new Vector3(swayX, swayY, 0);
			}

			transform.localPosition = Vector3.Lerp(transform.localPosition, _targetPosition + swayPosition, Time.deltaTime * positionSpeed);
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

		public void Sway(bool sway)
		{
			_sway = sway;
		}
	}
}
