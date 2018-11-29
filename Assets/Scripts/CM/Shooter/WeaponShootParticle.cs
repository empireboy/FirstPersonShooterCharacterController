using UnityEngine;
using CM.Orientation;

namespace CM.Shooter
{
	public class WeaponShootParticle : MonoBehaviour
	{
		[SerializeField] private ParticleSystem _muzzleFlash;

		public void OnShoot()
		{
			_muzzleFlash.Play();
		}
	}
}