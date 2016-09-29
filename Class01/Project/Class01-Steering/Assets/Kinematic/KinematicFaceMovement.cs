﻿using UnityEngine;
using System.Collections;

public class KinematicFaceMovement : MonoBehaviour {

	Move move;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
	}
	
	// Update is called once per frame
	void Update () {
        // TODO 7: rotate the whole tank to look in the movement direction
        // Extremnely similar to TODO 2
        float targetAngle = Mathf.Atan2(move.mov_velocity.x, move.mov_velocity.z) * Mathf.Rad2Deg;

        float currentAngle = Mathf.Atan2(transform.forward.x, transform.forward.z) * Mathf.Rad2Deg;

        float delta = Mathf.DeltaAngle(targetAngle, currentAngle);

        if(Mathf.Abs(delta) < 1.0f)
        {
            move.SetRotationVelocity(0.0f);
        }
        else
        {
            move.SetRotationVelocity(-delta);
        }
	}
}
