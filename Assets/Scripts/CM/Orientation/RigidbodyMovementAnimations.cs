using UnityEngine;

namespace CM.Orientation
{
	public class RigidbodyMovementAnimations : RigidbodyMovementBase
	{
		[Header("Animation Parameters")]
		[SerializeField] private string _isMovingParam = "IsMoving";
		[SerializeField] private string _walkSpeedMultiplierParam = "WalkSpeedMultiplier";

		private Animator _animator;

		private void Awake()
		{
			_animator = GetComponent<Animator>();
		}

		private void Start()
		{
			if (!_animator)
				enabled = false;
		}

		private void Update()
		{
			_animator.SetBool(_isMovingParam, IsMoving);
		}

		public void SetWalkSpeedMultiplier(float multiplier)
		{
			_animator.SetFloat(_walkSpeedMultiplierParam, multiplier);
		}

		public void ResetWalkSpeedMultiplier()
		{
			_animator.SetFloat(_walkSpeedMultiplierParam, 1);
		}
	}
}