using UnityEngine;

namespace CM.Orientation
{
	public class RigidbodyMovementAnimations : RigidbodyMovementBase
	{
		[Header("Animation Parameters")]
		[SerializeField] private string _isMovingParam = "IsMoving";

		private Animator _animator;

		private void Awake()
		{
			_animator = GetComponent<Animator>();
		}

		private void Update()
		{
			if (_animator)
				_animator.SetBool(_isMovingParam, IsMoving);
		}
	}
}