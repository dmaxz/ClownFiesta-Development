using System.Collections;
using System.Collections.Generic;
using MoreMountains.CorgiEngine;
using UnityEditor;
using UnityEngine;
using static MoreMountains.CorgiEngine.CharacterStates;

public class CheckClimbing : MonoBehaviour
{
    public GameObject[] gameObjects;
    public bool isclimbing = false;

    public Material mat;

    private void Start()
    {
        SetRenderer(gameObjects[0], gameObjects[1], true);
        SetRenderer(gameObjects[2], gameObjects[3], false);
        SetMaterials(gameObjects[1].GetComponentsInChildren<SpriteRenderer>(), gameObjects[3].GetComponentsInChildren<SpriteRenderer>());
    }

    void SetMaterials(Renderer[] rends1, Renderer[] rends2)
    {
        for (int i = 0; i < rends1.Length; i++)
        {
            rends1[i].material = mat;
            rends1[i].shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
        }
        for (int i = 0; i < rends2.Length; i++)
        {
            rends2[i].material = mat;
            rends2[i].shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
        }
    }

    private void Update()
    {
        // Debug.Log(GetComponentInParent<Character>().MovementState.CurrentState);
        if (GetComponentInParent<Character>().MovementState.CurrentState == MovementStates.LadderClimbing && isclimbing == false)
        {
            isclimbing = true;
            SetRenderer(gameObjects[0], gameObjects[1], false);
            SetRenderer(gameObjects[2], gameObjects[3], true);
        }
        else if (GetComponentInParent<Character>().MovementState.CurrentState != MovementStates.LadderClimbing)
        {
            isclimbing = false;

            SetRenderer(gameObjects[0], gameObjects[1], true);
            SetRenderer(gameObjects[2], gameObjects[3], false);
            // GetComponentInParent<Character>()._animator.SetFloat("LadderClimbingSpeedY", 0f);
        }
    }

    void SetRenderer(GameObject body, GameObject shadow, bool status)
    {
        Renderer[] rends1 = body.GetComponentsInChildren<Renderer>();
        Renderer[] rends2 = shadow.GetComponentsInChildren<Renderer>();
        for (int i = 0; i < rends1.Length; i++)
        {
            rends1[i].enabled = status;
        }
        for (int i = 0; i < rends2.Length; i++)
        {
            rends2[i].enabled = status;
        }

    }
}
