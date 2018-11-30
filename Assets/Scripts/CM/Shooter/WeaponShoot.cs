using UnityEngine;

namespace CM.Shooter
{
	public class WeaponShoot : WeaponBase
	{
		[SerializeField] private Transform _shootPoint;
		[SerializeField] private float _shootRate = 0.5f;
		[SerializeField] private float _shootRange = 100;
		[SerializeField] private Ammo _ammo;

		private float _shootTimer = 0;
		private float _currentAmmo;

		private WeaponReload _weaponReload;

		private void Awake()
		{
			_weaponReload = GetComponent<WeaponReload>();
		}

		private void Update()
		{
			if (isShooting && _ammo.ClipSize > 0 && !_weaponReload.IsReloading)
			{
				Shoot();
			}

			if (_shootTimer < _shootRate)
				_shootTimer += Time.deltaTime;
		}

		private void Shoot()
		{
			if (_shootTimer < _shootRate) return;

			SendMessage("OnShoot", SendMessageOptions.DontRequireReceiver);

			_ammo.ReduceClipSize();

			RaycastHit hit;

			if (Physics.Raycast(_shootPoint.position, _shootPoint.transform.forward, out hit, _shootRange))
			{
				Destroy(hit.transform.gameObject);
			}

			_shootTimer = 0;
		}
	}
}