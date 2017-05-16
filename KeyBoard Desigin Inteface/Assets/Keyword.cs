using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Keyword : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if (EventSystem.current.currentSelectedGameObject != null) {
				Debug.Log (EventSystem.current.currentSelectedGameObject.transform.Find ("Text").GetComponent<Text> ().text.ToString ());
				GameObject.Find ("Canvas/Image/Text").GetComponent<Text> ().text += EventSystem.current.currentSelectedGameObject.transform.Find ("Text").GetComponent<Text> ().text.ToString ();
			}
		}
	}
}
