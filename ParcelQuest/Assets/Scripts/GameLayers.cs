using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLayers : MonoBehaviour
{
    [SerializeField] LayerMask solidObjectsLayer;
    [SerializeField] LayerMask interactableLayer;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] LayerMask scenetransitionLayer;
    [SerializeField] LayerMask triggersLayer;
    public static GameLayers i { get; set; }

    private void Awake()
    {
        i = this; 
    }

    public LayerMask SolidLayer
    {
        get => solidObjectsLayer;
    }
    public LayerMask InteractableLayer
    {
        get => interactableLayer;
    }

    public LayerMask PlayerLayer
    {
        get => playerLayer;
    }

    public LayerMask ScenetransitionLayer
    { 
        get => scenetransitionLayer;
    
    }

    public LayerMask TriggerableLayers
    {
        get => scenetransitionLayer | triggersLayer;
    }
}
