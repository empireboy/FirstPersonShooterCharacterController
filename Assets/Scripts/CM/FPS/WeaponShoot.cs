﻿using UnityEngine;

namespace CM.FPS
{
	public class WeaponShoot : WeaponBase
	{
		[SerializeField] private Transform _shootPoint;
		[SerializeField] private ParticleSystem _muzzleFlash;
		[SerializeField] private AudioSource _shootSound;
		[SerializeField] private float _shootRate = 0.5f;
		[SerializeField] private float _shootRange = 100;

		private float _shootTimer = 0;

		private void Update()
		{
			if (isShooting)
			{
				Shoot();
			}

			if (_shootTimer < _shootRate)
				_shootTimer += Time.deltaTime;
		}

		private void Shoot()
		{
			if (_shootTimer < _shootRate) return;

			Debug.Log("Shooting");

			RaycastHit hit;

			if (Physics.Raycast(_shootPoint.position, _shootPoint.transform.forward, out hit, _shootRange))
			{
				Destroy(hit.transform.gameObject);
			}

			_shootSound.Play();
			_muzzleFlash.Play();

			_shootTimer = 0;
		}
	}
}