using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Red ball is a child class of Ball
/// </summary>
public class RedBall : Ball
{

    protected override void PrintMessage()
    {
        print("I'm a red ball");
    }

}
