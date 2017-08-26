﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ResourceManager : MonoBehaviour {
    public static ResourceManager thisManager;
    public int[] resources = new int[3];
    public string[] resourceTags;
    Text[,] resourcesText;
    public Transform resourcesTextObj;

    private void Awake() {
        resourcesText = new Text[resources.Length, 20];
        thisManager = this;
        for(int i = 0; i < resources.Length; i++) {
            GameObject[] a = GameObject.FindGameObjectsWithTag(resourceTags[i]);
            for (int ii = 0; ii < a.Length; ii++) {
                resourcesText[i, ii] = a[ii].GetComponent<Text>();
            }
        }
    }
    public void Add(int count, int resource) {
        resources[resource] += count;
        Refresh(resource);
    }
    public void Subtract(int count, int resource) {
        resources[resource] -= count;
        Refresh(resource);
    }
    void Refresh(int resource) {
        for(int i = 0; resourcesText[resource,i] != null; i++) {
            resourcesText[resource,i].text = resources[resource].ToString();
        }

    }
}