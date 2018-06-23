﻿using UnityEngine;
using System.Collections;

public class AgentControl : MonoBehaviour {

	public Transform target;
	protected UnityEngine.AI.NavMeshAgent agent;

	void Start () {
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();	
	}


	void Update () {
		if (Input.GetButtonDown ("Fire1")) 
			SetDestination();
	}
	protected void SetDestination()
	{
		var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit = new RaycastHit();
		if (Physics.Raycast(ray, out hit))
		{
			target.position = hit.point;
			agent.destination = target.position;
		}
	}
}
