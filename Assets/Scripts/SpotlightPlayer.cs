using System.Collections;
using System.Collections.Generic;
using MoreMountains.CorgiEngine;
using UnityEngine;

public class SpotlightPlayer : MonoBehaviour
{
    Light spotlight;
    bool isSpawned = false;
    Character chare;
    private void OnEnable()
    {

    }

    private void Awake()
    {

    }

    private void Start()
    {

    }
    private void Update()
    {
        if (!isSpawned)
        {
            spotlight = GetComponent<Light>();
            Character[] chars = FindObjectsOfType<Character>();
            for (int i = 0; i < chars.Length; i++)
            {

                if (chars[i].CharacterType == Character.CharacterTypes.Player)
                {
                    chare = chars[i];

                    isSpawned = true;

                }
                // Debug.Log(chars[i].transform.name);
            }
        }
        spotlight.transform.LookAt(chare.transform);
    }

}
