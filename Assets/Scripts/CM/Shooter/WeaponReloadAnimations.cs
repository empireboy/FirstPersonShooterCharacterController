using UnityEngine;
using CM.Previous;

namespace CM.Shooter
{
	public class WeaponReloadAnimations : MonoBehaviour
	{
		[SerializeField] private Animator _animator;

		[Header("Animation Parameters")]
		[SerializeField] private string _reloadingState = "Reload";
		[SerializeField] private string _isReloadingParam = "IsReloading";

		//private AnimatorStateInfo _previousAnimatorState;
		private PreviousAnimatorStateInfo _previousAnimatorStateInfo;

		private void Awake()
		{
			_previousAnimatorStateInfo = new PreviousAnimatorStateInfo(_animator);
		}

		private void Start()
		{
			WeaponReload weaponReload = GetComponent<WeaponReload>();
			weaponReload.OnReloadStart += OnReloadStart;
			weaponReload.OnReloadFinish += OnReloadFinish;
		}

		private void Update()
		{
			if (!_animator.GetCurrentAnimatorStateInfo(0).IsName(_reloadingState) && _previousAnimatorStateInfo.Value.IsName(_reloadingState))
				GetComponent<WeaponReload>().FinishReloading();
		}

		private void OnReloadStart()
		{
			_animator.SetBool(_isReloadingParam, true);
		}

		private void OnReloadFinish()
		{
			_animator.SetBool(_isReloadingParam, false);
		}
	}
}