using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GreenBall is a child class of Ball
/// </summary>
public class GreenBall : Ball
{
    override protected void Start()
    {
        impulseVector = new Vector2(0, 5);
        base.Start();
    }

    protected override void PrintMessage()
    {
        print("I'm a green ball");
    }
}
