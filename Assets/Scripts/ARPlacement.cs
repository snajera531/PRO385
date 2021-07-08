using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlacement : MonoBehaviour { 
    public ARRaycastManager raycastManager; 
    public GameObject placement; 

    void Start() { 
        placement.SetActive(false); 
    } 
    
    void Update() { 
        List<ARRaycastHit> hits = new List<ARRaycastHit>(); 
        raycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes); 
        
        if (hits.Count > 0) { 
            transform.position = hits[0].pose.position; 
            transform.rotation = hits[0].pose.rotation; 
            
            if (!placement.activeInHierarchy) { 
                placement.SetActive(true); 
            } 
        } 
    } 
}