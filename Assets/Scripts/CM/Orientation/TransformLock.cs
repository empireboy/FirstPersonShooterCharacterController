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

		[SerializeField] private Vector3 _targetPositionRandomizer;
		[SerializeField] private Vector3 _targetRotationRandomizer;
		[SerializeField] private float _randomPositionSpeed;
		[SerializeField] private float _randomRotationSpeed;

		[Header("Sway Transform")]
		[SerializeField] private bool _sway = false;
		[ShowIf("_sway")]
		public Vector2 swayAmount = new Vector2(0.02f, 0.02f);
		[ShowIf("_sway")]
		public Vector2 maxSwayAmount = new Vector2(0.05f, 0.05f);

		private Vector3 _targetPositionStart;
		private Vector3 _targetRotationStart;

		private Vector3 _targetPositionRandom;
		private Vector3 _targetRotationRandom;

		private Vector3 _currentRandomPosition = Vector3.zero;
		private Vector3 _currentRandomRotation = Vector3.zero;

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

			_currentRandomPosition = Vector3.Lerp(_currentRandomPosition, _targetPositionRandom, Time.deltaTime * _randomPositionSpeed);
			_currentRandomRotation = Vector3.Lerp(_currentRandomRotation, _targetRotationRandom, Time.deltaTime * _randomRotationSpeed);

			transform.localPosition = Vector3.Lerp(transform.localPosition, _targetPosition + swayPosition + _currentRandomPosition, Time.deltaTime * positionSpeed);
			transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(_targetRotation + _targetRotationRandom), Time.deltaTime * rotationSpeed);
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

		public void UpdateRandomTransform()
		{
			_targetPositionRandom = new Vector3(
				Random.Range(-_targetPositionRandomizer.x, _targetPositionRandomizer.x),
				Random.Range(-_targetPositionRandomizer.y, _targetPositionRandomizer.y),
				Random.Range(-_targetPositionRandomizer.z, _targetPositionRandomizer.z)
			);
			_targetRotationRandom = new Vector3(
				Random.Range(-_targetRotationRandomizer.x, _targetRotationRandomizer.x),
				Random.Range(-_targetRotationRandomizer.y, _targetRotationRandomizer.y),
				Random.Range(-_targetRotationRandomizer.z, _targetRotationRandomizer.z)
			);
		}

		public void ResetRandomizer()
		{
			_targetPositionRandom = Vector3.zero;
			_targetRotationRandom = Vector3.zero;
		}
	}
}
