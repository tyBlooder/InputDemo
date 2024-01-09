using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.Interaction.Toolkit;
using Unity.PolySpatial;

public class InteractableTest : XRSimpleInteractable
{
    public Material HoveredMaterial;

    private Material UnHoveredMaterial = null;

    private MeshRenderer RendererCom = null;
    // Start is called before the first frame update
    void Start()
    {
        selectEntered.AddListener( OnSelectEnter );
        selectExited.AddListener(OnSelectExit);
        hoverEntered.AddListener(OnHoverEntered);
        hoverExited.AddListener(OnHoverExited);
        RendererCom = GetComponent<MeshRenderer>();
        if (RendererCom != null)
        {
            UnHoveredMaterial = RendererCom.sharedMaterial;
        }
    }

    void OnSelectEnter(SelectEnterEventArgs arg0)
    {
        transform.localScale = Vector3.one * 0.5f;
    }

    void OnSelectExit(SelectExitEventArgs arg0 )
    {
        transform.localScale = Vector3.one * 0.2f;
    }

    void OnHoverEntered( HoverEnterEventArgs arg0 )
    {
        if(RendererCom != null)
            RendererCom.sharedMaterial = HoveredMaterial;
    }

    void OnHoverExited( HoverExitEventArgs arg0 )
    {
        if(RendererCom != null)
            RendererCom.sharedMaterial = UnHoveredMaterial;
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
