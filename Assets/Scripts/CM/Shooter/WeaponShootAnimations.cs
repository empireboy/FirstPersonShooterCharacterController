using UnityEngine;

namespace CM.Shooter
{
	public class WeaponShootAnimations : MonoBehaviour
	{
		[SerializeField] private Animator _animator;

		[Header("Animation Parameters")]
		[SerializeField] private string _isShootingParam = "IsShooting";

		[SerializeField] private WeaponShoot _weaponShoot;

		private void Update()
		{
			_animator.SetBool(_isShootingParam, _weaponShoot.IsShooting);
		}
	}
}