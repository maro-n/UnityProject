using UnityEngine;
using System.Collections;
using Common;

public class titleController : MonoBehaviour {
	void Update () {
        if (Input.GetKey(Define.SHOT_KEY1)||Input.GetKey(Define.SHOT_KEY2)||Input.GetKey(Define.SHOT_KEY3)||Input.GetKey(Define.SHOT_KEY4))
        {
            FindObjectOfType<sceneManager>().NextScene(Define.MAIN_GAME);
        }
	}
}
