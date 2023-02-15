using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flocker : Kinematic
{
    public GameObject myCohereTarget;
    BlendSteering blendSteering;
    Kinematic[] kBirds;

    void Start()
    {
        // Separate
        Separation separate = new Separation();
        separate.character = this;
        GameObject[] goBirds = GameObject.FindGameObjectsWithTag("bird");

        kBirds = new Kinematic[goBirds.Length - 1];
        int j = 0;

        for (int i = 0; i < goBirds.Length - 1; i++)
        {
            if (goBirds[i] == this)
            {
                continue;
            }
            kBirds[j++] = goBirds[i].GetComponent<Kinematic>();
        }

        separate.targets = kBirds;

        // Cohere
        Arrive cohere = new Arrive();
        cohere.character = this;
        cohere.target = myCohereTarget;

        // Look -rotate
        LookWhereGoing myRotateType = new LookWhereGoing();
        myRotateType.character = this;

        blendSteering = new BlendSteering();
        blendSteering.behaviors = new BehaviorAndWeight[3];
        blendSteering.behaviors[0] = new BehaviorAndWeight();
        blendSteering.behaviors[0].behavior = separate;
        blendSteering.behaviors[0].weight = 1f; 
        blendSteering.behaviors[1] = new BehaviorAndWeight();
        blendSteering.behaviors[1].behavior = cohere;
        blendSteering.behaviors[1].weight = 1f; 
        blendSteering.behaviors[2] = new BehaviorAndWeight();
        blendSteering.behaviors[2].behavior = myRotateType;
        blendSteering.behaviors[2].weight = 1f;

    }

    // Update is called once per frame
    protected override void Update()
    {
        steeringUpdate = new SteeringOutput();
        steeringUpdate = blendSteering.getSteering();

        base.Update();
    }
}
