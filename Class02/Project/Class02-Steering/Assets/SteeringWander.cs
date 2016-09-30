using UnityEngine;
using System.Collections;

public class SteeringWander : MonoBehaviour {

    Move move;

    public Vector3 offSet;
    public float radius;
    Vector3 ret = Vector3.zero;

    void Steer(Vector3 target)
    {
        Vector3 dif = target - transform.position;
        dif.Normalize();
        dif *= move.max_mov_acceleration;

        move.AccelerateMovement(dif);
    }

	// Use this for initialization
	void Start () {
        move = GetComponent<Move>();
	}
	
	// Update is called once per frame
	void Update () {
        //TODO: must check that random
        ret = Random.insideUnitSphere;
        ret += offSet;
        ret.y = 0;
        //ret *= radius;
        Steer(ret);
	}

    void OnDrawGizmosSelected()
    {
        if (isActiveAndEnabled)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.TransformPoint(offSet), radius);

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(ret, 0.2f);
        }
    }
}
