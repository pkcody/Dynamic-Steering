using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrioritySteering
{
    public BlendSteering[] groups;
    float epsilon = .1f;
    public SteeringOutput getSteering()
    {
        SteeringOutput steering = new SteeringOutput();
        foreach (BlendSteering group in groups)
        {
            steering = group.getSteering();

            if (steering.linear.magnitude > epsilon || Mathf.Abs(steering.angular) > epsilon)
            {
                return steering;
            }
        }
        return steering;
    }
}
