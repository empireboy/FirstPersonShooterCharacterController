using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

namespace CM.Movement
{
	public class MouseLook : MonoBehaviour
	{
		public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
		public RotationAxes rotationAxes = RotationAxes.MouseXAndY;
		public Vector2 sensivity = new Vector2(2f, 2f);
		[Header("Mouse Y Properties")]
		public float clampYMin = -70;
		public float clampYMax = 70;
		public bool invertY = false;
		[Header("Mouse X Properties")]
		public bool invertX = false;
		[Header("Input")]
		[SerializeField] private string _horizontalAxes = "Mouse X";
		[SerializeField] private string _verticalAxes = "Mouse Y";

		private Vector2 rotation = new Vector2(0, 0);

		private void Start()
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}

		private void Update()
		{
			Vector2 axes = new Vector2(Input.GetAxis(_horizontalAxes), Input.GetAxis(_verticalAxes));
			Vector2 invert = new Vector2
			{
				x = (invertX) ? -1 : 1,
				y = (invertY) ? -1 : 1
			};

			rotation.x += (axes.x * sensivity.x) * invert.x;
			rotation.y += (axes.y * sensivity.y) * invert.y;

			rotation.y = Mathf.Clamp(rotation.y, clampYMin, clampYMax);

			switch (rotationAxes)
			{
				case RotationAxes.MouseXAndY:
					transform.localEulerAngles = new Vector3(rotation.y, rotation.x, 0);
					break;
				case RotationAxes.MouseX:
					transform.localEulerAngles = new Vector3(0, rotation.x, 0);
					break;
				case RotationAxes.MouseY:
					transform.localEulerAngles = new Vector3(rotation.y, 0, 0);
					break;
			}
		}
	}
}