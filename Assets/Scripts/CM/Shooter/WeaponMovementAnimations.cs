using UnityEngine;
using CM.Orientation;

namespace CM.Shooter
{
	public class WeaponMovementAnimations : MonoBehaviour
	{
		[SerializeField] private Animator _animator;

		[Header("Animation Parameters")]
		[SerializeField] private string _isMovingParam = "IsMoving";

		[SerializeField] private RigidbodyMovement _rigidbodyMovement;

		private void Update()
		{
			_animator.SetBool(_isMovingParam, _rigidbodyMovement.IsMoving);
		}
	}
}