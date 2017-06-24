using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventoryItem : IReward
{
	Sprite Image { get; set; }
}
