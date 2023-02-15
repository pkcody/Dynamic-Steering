using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorAndWeight
{
    public SteeringBehavior behavior = null;
    public float weight = 0f;
}

public class BlendSteering
{
    public BehaviorAndWeight[] behaviors;

    float maxAcceleration = 5f;
    float maxRotation = 7f;

    public SteeringOutput getSteering()
    {
        SteeringOutput result = new SteeringOutput();

        //get acc
        foreach (BehaviorAndWeight b in behaviors)
        {
            SteeringOutput so = b.behavior.getSteering();
            if (so != null)
            {
                result.angular += so.angular * b.weight;
                result.linear += so.linear * b.weight;
            }
        }

        result.linear = result.linear.normalized * maxAcceleration;
        float angularAcceleration = Mathf.Abs(result.angular);
        if (angularAcceleration > maxRotation)
        {
            result.angular /= angularAcceleration;
            result.angular *= maxRotation;
        }

        return result;
    }

    
}
