using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SwipeTask : Task 
{
	public int CountSwipe { get; set; }
	public DirectionSwipe DirectionSwipe { get; set; }
}
