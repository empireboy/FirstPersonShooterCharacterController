using UnityEngine;

namespace CM.Shooter
{
	public class WeaponReloadAnimations : MonoBehaviour
	{
		[SerializeField] private Animator _animator;

		[Header("Animation Parameters")]
		[SerializeField] private string _reloadingTriggerParam = "Reload";


		private WeaponReload _weaponReload;
		private AnimatorStateInfo _previousAnimatorState;

		private void Awake()
		{
			_weaponReload = GetComponent<WeaponReload>();
		}

		private void Update()
		{
			if (!_animator.GetCurrentAnimatorStateInfo(0).IsName(_reloadingTriggerParam) && _previousAnimatorState.IsName(_reloadingTriggerParam))
			{
				_animator.ResetTrigger(_reloadingTriggerParam);
				_weaponReload.FinishReloading();
			}

			_previousAnimatorState = _animator.GetCurrentAnimatorStateInfo(0);
		}

		public void OnReload()
		{
			_animator.SetTrigger(_reloadingTriggerParam);
			_weaponReload.StartReloading();
		}
	}
}