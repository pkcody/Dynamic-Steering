using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAvoidance : Seek
{
    //public float avoidDistance = .5f;
    public float avoidDistance = 20f;

    public float lookahead = 10f;

    protected override Vector3 getTargetPosition()
    {

        RaycastHit hit;

        if (Physics.Raycast(character.transform.position + new Vector3(0, .5f,0), character.linearVelocity, out hit, lookahead))
        {
            Debug.DrawRay(character.transform.position, character.linearVelocity.normalized * hit.distance, Color.red, 0.5f);
            return hit.point - (hit.normal * avoidDistance);
        }
        else
        {
            //return base.getTargetPosition();
            Debug.DrawRay(character.transform.position, character.linearVelocity.normalized * hit.distance, Color.blue, 0.5f);
            return Vector3.positiveInfinity;
        }

    }
}
