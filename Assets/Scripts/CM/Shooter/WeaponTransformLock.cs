using UnityEngine;
using CM.Orientation;

namespace CM.Shooter
{
	public class WeaponTransformLock : MonoBehaviour
	{
		[SerializeField] private Transform _shootPoint;
		[SerializeField] private float _shootRate = 0.5f;
		[SerializeField] private float _shootRange = 100;
		[SerializeField] private float _ammo = 25;
		[SerializeField] private TransformLock _weaponTransformLock;
		[SerializeField] private TransformLockData _weaponTransformLockData;

		private float _shootTimer = 0;
		private float _currentAmmo;

		private WeaponReload _weaponReload;

		private void Awake()
		{
			_weaponReload = GetComponent<WeaponReload>();
		}

		private void Start()
		{
			_weaponTransformLock.Set(_weaponTransformLockData);
			_currentAmmo = _ammo;
		}

		private void Update()
		{
			if (isShooting && _currentAmmo > 0 && !_weaponReload.IsReloading)
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

			_currentAmmo--;

			RaycastHit hit;

			if (Physics.Raycast(_shootPoint.position, _shootPoint.transform.forward, out hit, _shootRange))
			{
				Destroy(hit.transform.gameObject);
			}

			_weaponTransformLock.UpdateRandomTransform();

			_shootTimer = 0;
		}
	}
}