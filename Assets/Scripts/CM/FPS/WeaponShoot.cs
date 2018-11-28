using UnityEngine;
using CM.Orientation;

namespace CM.FPS
{
	public class WeaponShoot : WeaponBase
	{
		[SerializeField] private Transform _shootPoint;
		[SerializeField] private ParticleSystem _muzzleFlash;
		[SerializeField] private AudioSource _shootSound;
		[SerializeField] private float _shootRate = 0.5f;
		[SerializeField] private float _shootRange = 100;
		[SerializeField] private float _ammo = 25;
		[SerializeField] private TransformLock _weaponTransformLock;

		private float _shootTimer = 0;
		private float _currentAmmo;

		[SerializeField] private Animator animator;

		private bool _isReloading;

		private void Start()
		{
			_currentAmmo = _ammo;
		}

		private void Update()
		{
			if (animator.GetCurrentAnimatorStateInfo(0).IsName("Reload") && !_isReloading)
			{
				_isReloading = true;
			}

			if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") && _isReloading)
			{
				animator.ResetTrigger("Reload");
				_isReloading = false;
				_currentAmmo = _ammo;
			}

			if (isShooting && _currentAmmo > 0 && !_isReloading)
			{
				Shoot();
			}
			else if (isShooting)
			{
				//Reload();
			}

			if (_shootTimer < _shootRate)
				_shootTimer += Time.deltaTime;

			/*if (Input.GetKeyDown(KeyCode.R) && _currentAmmo != _ammo)
				Reload();*/
		}

		private void Shoot()
		{
			if (_shootTimer < _shootRate) return;

			_currentAmmo--;

			RaycastHit hit;

			if (Physics.Raycast(_shootPoint.position, _shootPoint.transform.forward, out hit, _shootRange))
			{
				Destroy(hit.transform.gameObject);
			}

			_weaponTransformLock.UpdateRandomTransform();

			_shootSound.Play();
			_muzzleFlash.Play();

			_shootTimer = 0;
		}

		private void Reload()
		{
			animator.SetTrigger("Reload");
		}
	}
}