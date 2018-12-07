using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CM.Orientation;

namespace CM.Essentials.Audio
{
	public class WalkAudio : MonoBehaviour
	{
		[SerializeField] private AudioSource _audioSource;
		[SerializeField] private RigidbodyMovement _rigidbodyMovement;

		private void Update()
		{
			if (_audioSource.isPlaying && !_rigidbodyMovement.IsMoving)
				_audioSource.Stop();
		}
	}
}