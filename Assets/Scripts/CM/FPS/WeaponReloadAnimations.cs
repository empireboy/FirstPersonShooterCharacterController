using UnityEngine;

namespace CM.FPS
{
	public class WeaponReloadAnimations : MonoBehaviour
	{
		[SerializeField] private Animator _animator;

		private WeaponReload _weaponReload;
		private AnimatorStateInfo _previousAnimatorState;

		private void Awake()
		{
			_weaponReload = GetComponent<WeaponReload>();
		}

		private void Update()
		{
			if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Reload") && _previousAnimatorState.IsName("Reload"))
			{
				_animator.ResetTrigger("Reload");
				SendMessage("OnReloadFinished", SendMessageOptions.DontRequireReceiver);
				Debug.Log("reload finished");
			}

			_previousAnimatorState = _animator.GetCurrentAnimatorStateInfo(0);
		}

		public void OnReload()
		{
			_animator.SetTrigger("Reload");
			SendMessage("OnReloadStart", SendMessageOptions.DontRequireReceiver);
		}
	}
}