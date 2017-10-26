using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private float moveSpeed = 5;
    public GameObject myTarget;

    public void AimTarget (GameObject target) {
        myTarget = target;
	}
	
	void Update () {
        Vector3 diplacement = myTarget.transform.position - transform.position ;
        Vector3 direction = diplacement.normalized;
        Vector3 velocity = direction * moveSpeed * Time.deltaTime;

        transform.Translate(velocity);

        float range = diplacement.magnitude;
        if(range <= 0.3f)
        {
            PoolManager.ReleaseObject(this.gameObject);
        }

	}

   
}
