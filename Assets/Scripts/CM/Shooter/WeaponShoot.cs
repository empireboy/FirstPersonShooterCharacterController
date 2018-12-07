using UnityEngine;

namespace CM.Shooter
{
	public class WeaponShoot : MonoBehaviour
	{
		[SerializeField] private Transform _shootPoint;
		[SerializeField] private float _shootRate = 0.5f;
		[SerializeField] private float _shootRange = 100;
		[SerializeField] private Ammo _ammo;

		private bool _isShooting = false;
		public bool IsShooting
		{
			get
			{
				return _isShooting;
			}
		}

		private float _shootTimer = 0;
		private float _currentAmmo;

		private WeaponReload _weaponReload;

		private void Awake()
		{
			_weaponReload = GetComponent<WeaponReload>();
		}

		private void Update()
		{
			if (_shootTimer < _shootRate)
				_shootTimer += Time.deltaTime;
		}

		public void Shoot()
		{
			if (_shootTimer < _shootRate) return;

			if (!(_ammo.CurrentClipSize > 0 && !_weaponReload.IsReloading)) return;

			_isShooting = true;

			SendMessage("OnShoot", SendMessageOptions.DontRequireReceiver);

			_ammo.ReduceClipSize();

			RaycastHit hit;

			if (Physics.Raycast(_shootPoint.position, _shootPoint.transform.forward, out hit, _shootRange))
			{
				Destroy(hit.transform.gameObject);
			}

			_shootTimer = 0;
		}

		public void ShootStop()
		{
			_isShooting = false;
		}
	}
}