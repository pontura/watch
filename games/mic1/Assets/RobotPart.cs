﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotPart : MonoBehaviour {

	public float speed = 2;
	public RobotPart parent;
    public ParticleSystem particles;
	public Animation anim;
	public float distance = 0.02f;
	public SpriteRenderer spriteRenderer;
	public TrailRenderer trail;

	public void Init(int bichoID)
	{
		anim = GetComponent<Animation> ();

		if(anim != null)
			anim.Play ("bicho" + bichoID);
		
		Color color = Data.Instance.config.GetBicho (bichoID).colors [0];
		trail.startColor = color;
		trail.endColor = color;
		trail.material.color =  color;

		float f = ((float)Random.Range (0, 10) - 5) / 20;
		print ("F: " + f);
		color.r += ((float)Random.Range (0, 10) - 5) / 20;
		color.g += ((float)Random.Range (0, 10) - 5) / 20;
		color.b += ((float)Random.Range (0, 10) - 5) / 20;

		spriteRenderer.color =color;


		if (particles != null) {
			var main = particles.main;
			main.startColor = Data.Instance.config.GetBicho (bichoID).colors [0];
		}
	}
	void Update () {
		if (parent == null)
			return;
		transform.LookAt (parent.transform);
		float dist = Vector3.Distance (parent.transform.position, transform.position);
		if (dist < distance)
			return;
		transform.position = Vector3.MoveTowards (transform.position, parent.transform.position, Time.deltaTime * (dist/speed));
	}
    bool isOnPArticles;
	public void TurnOnParticles(float value)
    {
		//distance = value / 2;
        if (particles == null) return;

		particles.startSize = value;
		if (isOnPArticles)
			return;
        particles.Play();
        isOnPArticles = true;
    }
    public void TurnOffParticles()
    {
        if (particles == null || !isOnPArticles) return;
        particles.Stop();
        isOnPArticles = false;
    }
}
