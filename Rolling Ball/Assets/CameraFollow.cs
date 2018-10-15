﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public GameObject ball;
    private Vector3 offset;
	// Use this for initialization
	void Start () {
        offset = gameObject.transform.position - ball.gameObject.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = ball.transform.position+offset;
	}
}
