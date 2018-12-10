using UnityEngine;

namespace CM.Shooter
{
	public class WeaponReloadAnimations : MonoBehaviour
	{
		[SerializeField] private Animator _animator;

		[Header("Animation Parameters")]
		[SerializeField] private string _reloadingState = "Reload";
		[SerializeField] private string _isReloadingParam = "IsReloading";


		private WeaponReload _weaponReload;
		private AnimatorStateInfo _previousAnimatorState;

		private void Awake()
		{
			_weaponReload = GetComponent<WeaponReload>();
		}

		private void Update()
		{
			if (!_animator.GetCurrentAnimatorStateInfo(0).IsName(_reloadingState) && _previousAnimatorState.IsName(_reloadingState))
			{
				if (_weaponReload)
					_weaponReload.FinishReloading();
			}

			_animator.SetBool(_isReloadingParam, _weaponReload.IsReloading);

			_previousAnimatorState = _animator.GetCurrentAnimatorStateInfo(0);
		}
	}
}