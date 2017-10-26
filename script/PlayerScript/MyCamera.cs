using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour {

    private Transform player;
    private Vector3 offset;
	
	void Start () 
	{
        Camera cam = gameObject.GetComponent<Camera>();
        float[] distance = new float[32];
        distance[8] = 30;
        cam.layerCullDistances = distance;
        cam.layerCullDistances[8] = 30;


        //player = GameObject.Find("Player").GetComponent<Transform>();
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        offset = transform.position - player.position;
	}

    void LateUpdate()
    {
        transform.position = player.position + offset;
    }
}
