using UnityEngine;

namespace CM.FPS
{
	public class WeaponReload : MonoBehaviour
	{
		[SerializeField] private Animator _animator;

		private bool _isReloading;
		public bool IsReloading
		{
			get
			{
				return _isReloading;
			}
		}

		private void Update()
		{
			if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Reload") && !IsReloading)
			{
				_isReloading = true;
			}

			if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") && IsReloading)
			{
				_animator.ResetTrigger("Reload");
				_isReloading = false;
				SendMessage("OnReloadFinished", SendMessageOptions.DontRequireReceiver);
				//_currentAmmo = _ammo;
			}
		}

		public void OnReload()
		{
			_animator.SetTrigger("Reload");
			SendMessage("OnReloadStart", SendMessageOptions.DontRequireReceiver);
		}
	}
}