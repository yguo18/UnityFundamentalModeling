using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
public class Keyword : MonoBehaviour {
	Vector2 range = new Vector2(4f, 3f);
	Quaternion mStart;
	Vector2 mRot = Vector2.zero;
	// Use this for initialization
	void Start () {
		mStart = transform.localRotation;
	}
	// Update is called once per frame
	void Update () {
		TransformTrans ();
		if (Input.GetMouseButtonDown (0)) {
			if (EventSystem.current.currentSelectedGameObject != null) {
				if (EventSystem.current.currentSelectedGameObject.tag != "Delete" && EventSystem.current.currentSelectedGameObject.tag == "button") {
					Debug.Log (EventSystem.current.currentSelectedGameObject.transform.Find ("Text").GetComponent<Text> ().text.ToString ());
					GameObject.Find ("Canvas/Image/Text").GetComponent<Text> ().text += EventSystem.current.currentSelectedGameObject.transform.Find ("Text").GetComponent<Text> ().text.ToString ();
				} else if (EventSystem.current.currentSelectedGameObject.tag == "Delete") {
					string str = GameObject.Find ("Canvas/Image/Text").GetComponent<Text> ().text.ToString ();
					if (str.Length != 0) {
						GameObject.Find ("Canvas/Image/Text").GetComponent<Text> ().text = str.Substring (0, str.Length - 1);
					}
				} else if (EventSystem.current.currentSelectedGameObject.tag == "Quite") {
					Quit ();
				}
			}
		}
	}
	private void Quit(){
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}


	// Update is called once per frame
	private void TransformTrans () {
		Vector3 pos = Input.mousePosition;
		float halfWidth = Screen.width * 0.5f;
		float halfHeight = Screen.height * 0.5f;
		float x = Mathf.Clamp ((pos.x - halfWidth) / halfWidth, -1f, 1f);
		float y = Mathf.Clamp ((pos.y - halfHeight) / halfHeight, -1f, 1f);
		mRot = Vector2.Lerp (mRot,new Vector2 (x, y), Time.deltaTime);
		transform.localRotation = mStart * Quaternion.Euler (-mRot.x * range.x, mRot.y * range.y, 0f);
	}
}
