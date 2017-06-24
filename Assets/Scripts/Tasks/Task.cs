using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Task 
{
	public delegate void TaskComplete(Task task);
	public abstract event TaskComplete OnTaskComplete;
	public abstract string Name { get; set; }
	public abstract void Job();
	protected abstract IReward[] GetReward();

	protected void DistributionAwards(IReward[] reward)
	{
		for (int i = 0; i < reward.Length; i++)
		{
			if (reward[i] is IInventoryItem)
				Inventory.Instance.AddItem(reward[i] as IInventoryItem);
			else
				Cash.Count += reward[i].Count;
		}
	}
}
