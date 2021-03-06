﻿using UnityEngine;
using System.Collections;

public class SteeringSeparation : MonoBehaviour {

	public LayerMask mask;
	public float search_radius = 5.0f;
	public AnimationCurve falloff;

	Move move;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        // TODO 1: Agents much separate from each other:
        // 1- Find other agents in the vicinity (use a layer for all agents)
        // 2- For each of them calculate a escape vector using the AnimationCurve
        // 3- Sum up all vectors and trim down to maximum acceleration
        Collider[] cols = Physics.OverlapSphere(transform.position, search_radius, mask);
        Vector3 repulsionVec = Vector3.zero;

        foreach(Collider col in cols) //Iterate all colliders that intersected with the sphere around the tank
        {
            Vector3 rep = Vector3.zero;
                if(col.gameObject != this.gameObject) //Check if the collider is the gameObject's 
                {
                    rep = transform.position - col.transform.position;
                    rep.Normalize();
                    //rep *= falloff.Evaluate();
                    rep *= move.max_mov_velocity; //TMP: should change this to use curves

                    repulsionVec += rep;  //Summ all repulsion velocity vectors
                }
        }

        move.SetMovementVelocity(repulsionVec);
	}

	void OnDrawGizmosSelected() 
	{
		// Display the explosion radius when selected
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, search_radius);
	}
}
