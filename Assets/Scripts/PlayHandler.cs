using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void PlayDelegate();

public class PlayHandler
{
    public event PlayDelegate OnPlay;

    public void PlayTiles()
    {
        OnPlay();
    }
}
