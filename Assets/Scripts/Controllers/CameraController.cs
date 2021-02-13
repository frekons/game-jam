﻿using UnityEngine;

public class CameraController : MonoBehaviour
{
	[Header("Camera")]
	private Rigidbody2D _localPlayerRigidbody;
	public Vector3 CameraOffset = Vector3.zero;

	[SerializeField]
	private float _followSpeed = 1f;

	void Start()
	{
		_localPlayerRigidbody = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
	}

	void LateUpdate()
	{
		Vector3 camPos = _localPlayerRigidbody.transform.position;
		camPos.z = transform.position.z;

		if (_localPlayerRigidbody.transform.position.y < -5f)
			return;

		transform.position = Vector3.Lerp(transform.position, camPos + CameraOffset + new Vector3(_localPlayerRigidbody.velocity.x / 2, 0, 0), Time.deltaTime * _followSpeed);
	}
}
