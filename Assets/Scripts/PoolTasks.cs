﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PoolTasks : MonoBehaviour 
{
	public static PoolTasks Instance;
	public GameObject Content;
	public GameObject[] JobArray;
	private float delayForNextTask = 60f;

	private GameObject taskPrefab;
	private GameObject TaskPrefab
	{
		get 
		{ 
			if (taskPrefab == null)
				return taskPrefab = Resources.Load<GameObject>("Task");
			return taskPrefab;
		}
	}
	
    private System.Random randomTask = new System.Random();

	private Dictionary<Task, GameObject> taskList = new Dictionary<Task, GameObject>();
	private Dictionary<Task, GameObject> TaskList
	{
		get { return taskList; }
		set { taskList = value; }
	}
	
	private void OnEnable()
	{
		StartCoroutine(GetTask());
	}

	private void Awake()
	{
		if(Instance != null)
			Destroy(this);
		else
			Instance = this;
	}

	private IEnumerator GetTask()
	{
		while(true)
		{
			switch(randomTask.Next(0, 5))
			{
				case 0:
					CreateTask(new TripleSwipeLeft(), JobArray[0]);
					break;
				case 1:
					CreateTask(new TripleSwipeRight(), JobArray[1]);
					break;
				case 2:
					CreateTask(new DoubleClickButton(), JobArray[2]);
					break;
				case 3:
					CreateTask(new DoubleClickRightSide(), JobArray[3]);
					break;
				case 4:
					CreateTask(new FiveTap(), JobArray[4]);
					break;
			}

			yield return new WaitForSeconds(delayForNextTask);
		}
	}

	private void CreateTask(Task task, GameObject jobGO)
    {
        GameObject taskGO = Instantiate(TaskPrefab, Content.transform);
        taskGO.GetComponentInChildren<Text>().text = task.Name;
        taskGO.GetComponent<Button>().onClick.AddListener(delegate
        {
            jobGO.SetActive(true);
            gameObject.SetActive(false);
        });

        task.OnTaskComplete += TaskComplete;

        if (task is SwipeTask)
            jobGO.GetComponent<SwipeHandler>().Task = task as SwipeTask;
        else
            jobGO.GetComponent<TapHandler>().Task = task as TapTask;

        TaskList.Add(task, taskGO);
    }

    private void TaskComplete(Task task)
    {
        gameObject.SetActive(true);
		
		for (int i = 0; i < JobArray.Length; i++)
		{
			if (JobArray[i].activeSelf == true)
				JobArray[i].SetActive(false);
		}
		
		foreach (var item in TaskList)
		{
			if (item.Key == task)
				Destroy(item.Value);
		}

		TaskList.Remove(task);

		task.OnTaskComplete -= TaskComplete;
    }
}
