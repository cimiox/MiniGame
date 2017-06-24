using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TapHandler : MonoBehaviour, IPointerClickHandler
{
	public TapTask Task { get; set; }

    public void OnPointerClick(PointerEventData eventData)
    {
        Task.Job();
    }
}
