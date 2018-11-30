using UnityEngine;

namespace CM.Shooter
{
	public class WeaponShootAudio : MonoBehaviour
	{
		public AudioSource shootSound;

		public void OnShoot()
		{
			if (shootSound)
				shootSound.Play();
		}
	}
}