using System.Collections;
using System.Collections.Generic;
using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using UnityEngine;

public class AIWalkExtended : AIWalk
{
    protected override void CheckForTarget()
    {
        if (WalkBehaviour != WalkBehaviours.MoveOnSight)
        {
            return;
        }

        bool hit = false;

        _distanceToTarget = 0;
        // we cast a ray to the left of the agent to check for a Player
        Vector2 raycastOrigin = transform.position + MoveOnSightRayOffset;

        // we cast it to the left	
        // RaycastHit2D raycast = MMDebug.RayCast(raycastOrigin, Vector2.left, ViewDistance, MoveOnSightLayer, Color.yellow, true);
        // // if we see a player
        // if (raycast)
        // {
        //     hit = true;
        //     // we change direction
        //     _direction = Vector2.left;
        //     _distanceToTarget = raycast.distance;
        // }

        // we cast a ray to the right of the agent to check for a Player	
        RaycastHit2D raycast0 = MMDebug.RayCast(raycastOrigin + (Vector2.up), Vector2.right, ViewDistance, MoveOnSightLayer, Color.yellow, true);
        RaycastHit2D raycastu1 = MMDebug.RayCast(raycastOrigin + (Vector2.up * 0.25f * 1), Vector2.right, ViewDistance, MoveOnSightLayer, Color.yellow, true);
        RaycastHit2D raycastu2 = MMDebug.RayCast(raycastOrigin + (Vector2.up * 0.25f * 2), Vector2.right, ViewDistance, MoveOnSightLayer, Color.yellow, true);
        RaycastHit2D raycastu3 = MMDebug.RayCast(raycastOrigin + (Vector2.up * 0.25f * 3), Vector2.right, ViewDistance, MoveOnSightLayer, Color.yellow, true);
        RaycastHit2D raycastd1 = MMDebug.RayCast(raycastOrigin - (Vector2.up * 0.25f * 1), Vector2.right, ViewDistance, MoveOnSightLayer, Color.yellow, true);
        RaycastHit2D raycastd2 = MMDebug.RayCast(raycastOrigin - (Vector2.up * 0.25f * 2), Vector2.right, ViewDistance, MoveOnSightLayer, Color.yellow, true);
        RaycastHit2D raycastd3 = MMDebug.RayCast(raycastOrigin - (Vector2.up * 0.25f * 3), Vector2.right, ViewDistance, MoveOnSightLayer, Color.yellow, true);
        if (raycast0 || raycastu1 || raycastu2 || raycastu3 || raycastd1 || raycastd2 || raycastd3)
        {
            RaycastHit2D[] raycasts = new RaycastHit2D[]{
                raycast0 , raycastu1 , raycastu2 , raycastu3 , raycastd1 , raycastd2 , raycastd3
            };
            RaycastHit2D raycasttrue = new RaycastHit2D();
            for (int i = 0; i < raycasts.Length; i++)
            {
                if (raycasts[i])
                {
                    raycasttrue = raycasts[i];
                }
            }

            hit = true;
            _direction = Vector2.right;
            if (raycasttrue.distance > 0)
            {
                _distanceToTarget = raycasttrue.distance;
            }

        }

        // if the ray has hit nothing, or if we've reached our target, we prevent our character from moving further.
        if ((!hit) || (_distanceToTarget <= StopDistance))
        {
            _direction = Vector2.zero;
        }
        else
        {
            // if we've hit something, we make sure there's no obstacle between us and our target
            RaycastHit2D raycastObstacle = MMDebug.RayCast(raycastOrigin, _direction, ViewDistance, MoveOnSightObstaclesLayer, Color.gray, true);
            if (raycastObstacle && _distanceToTarget > raycastObstacle.distance)
            {
                _direction = Vector2.zero;
            }
        }
    }
}
