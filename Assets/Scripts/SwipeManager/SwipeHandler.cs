﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeHandler : MonoBehaviour, IBeginDragHandler, IDragHandler
{
	public SwipeTask Task { get; set; }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(Task != null)
        {
            if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))
            {
                if (eventData.delta.x > 0 && Task.DirectionSwipe == DirectionSwipe.Right) 
                    Task.Job();
                else 
                    Task.Job();
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
    }
}
