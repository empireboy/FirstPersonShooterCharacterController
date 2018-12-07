using UnityEngine;
using CM.Orientation;

namespace CM.Essentials.Audio
{
	public class WalkAudio : MonoBehaviour
	{
		[SerializeField] private AudioSource _audioSource;
		[SerializeField] private RigidbodyMovement _rigidbodyMovement;
		[SerializeField] private float _stopAudioSpeed = 1f;

		private bool _isStopping = false;

		private void Update()
		{
			if (_audioSource.isPlaying && !_rigidbodyMovement.IsMoving)
				_isStopping = true;

			if (_isStopping)
			{
				_audioSource.volume -= Time.deltaTime * _stopAudioSpeed;

				if (_audioSource.volume <= 0)
				{
					_audioSource.Stop();
					_isStopping = false;
					_audioSource.volume = 1;
				}
			}
		}
	}
}