using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : ObjectInScene {
	
	Rigidbody rb;
	float speed = 4000;

	void Start () {
		Events.OnStartGame += OnStartGame;
		rb = GetComponent<Rigidbody> ();
		rb.isKinematic = true;
		if (Data.Instance.playerData.ballPosition != Vector3.zero) {
			Vector3 newPos = Data.Instance.playerData.ballPosition;
			newPos.x *= -1;
			newPos.y *= -1;
			newPos.y /= 1.2f;
			newPos.x /= 1.2f;
			transform.localPosition = newPos;
			Data.Instance.playerData.ballPosition = Vector3.zero;
		}
	}
	void OnDestroy()
	{
		Events.OnStartGame -= OnStartGame;
	}
	void OnStartGame()
	{
		rb.GetComponent<Rigidbody> ().isKinematic = false;
	}
	void ____Update()
	{
		float moveHorizontal = Input.acceleration.x;
		float  moveVertical = Input.acceleration.y;                        
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed * Time.deltaTime);
	}
	void OnTriggerEnter(Collider other) {
		if (other.GetComponent<Goal> ()) {
			rb.GetComponent<Rigidbody> ().isKinematic = false;
			Invoke ("Win", 0.2f);
		} else if (other.GetComponent<Fire> ()) {
			rb.GetComponent<Rigidbody> ().isKinematic = false;
			Invoke ("Die", 0.2f);
		}  else if (other.GetComponent<Key> ()) {
			rb.GetComponent<Rigidbody> ().isKinematic = false;
			Events.GotKey ();
			Destroy (other.gameObject);
		}
	}
	WallAsset lastWallAsset;
	void OnCollisionEnter(Collision other) {
		WallAsset w = other.gameObject.GetComponent<WallAsset> ();
		if (w == null)
			return;
		if (w.type == WallAsset.types.DOOR) {
			if (Data.Instance.playerData.keys > 0) {
				Events.UseKey (w.value, w.isLeft);
				w.SetType( WallAsset.types.PATH);
			}
		}
		if (w.type == WallAsset.types.PATH) {
			lastWallAsset = w;
			rb.GetComponent<Rigidbody> ().isKinematic = false;
			Invoke ("OnGotInDoor", 0.2f);
		}
	}
	void OnGotInDoor()
	{
		Data.Instance.playerData.ballPosition = transform.localPosition;
		Events.GotIntoDoor (lastWallAsset.value);
	}
	void Win()
	{
		Events.LevelComplete ();
	}
	void Die()
	{
		Events.Die ();
	}
}
