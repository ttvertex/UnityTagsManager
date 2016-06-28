using UnityEngine;
using System.Collections;

public class Demo : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        string s = "Plane objects:\n";
        GameObject[] objs = TagsManager.FindGameObjectsWithTag("Plane");
        foreach (GameObject g in objs)
            s += (g.name + "\n");

        GUI.TextField(new Rect(20, 20, 100, 100), s);


        s = "Ball objects:\n";
        objs = TagsManager.FindGameObjectsWithTag("Ball");
        foreach (GameObject g in objs)
            s += (g.name + "\n");

        GUI.TextField(new Rect(120, 20, 100, 100), s);


        s = "Cube objects:\n";
        objs = TagsManager.FindGameObjectsWithTag("Cube");
        foreach (GameObject g in objs)
            s += (g.name + "\n");

        GUI.TextField(new Rect(220, 20, 100, 100), s);


        s = "Camera objects:\n";
        objs = TagsManager.FindGameObjectsWithTag("Camera");
        foreach (GameObject g in objs)
            s += (g.name + "\n");

        GUI.TextField(new Rect(320, 20, 100, 100), s);
    }
}
