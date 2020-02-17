



















































































using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AI
{
    Transform player;

    public void Init()
    {
        player = Object.FindObjectOfType<Player>().transform;
    }

    public InputProvider.Direction WhereShouldIFly()
    {
        if (player == null)
            Init();
        var closest = FindClosestToPlayer();

        if (closest == null)
            return InputProvider.Direction.None;
        if (closest.position.x > player.transform.position.x)
            return InputProvider.Direction.Rigth;
        else
            return InputProvider.Direction.Left;
    }


    Transform FindClosestToPlayer()
    {
        var boosts = GameObject.FindGameObjectsWithTag("ExtraFuelBoost").ToList();
        boosts.AddRange(GameObject.FindGameObjectsWithTag("StarBoost").ToList());

        if (boosts == null || boosts.Count == 0)
            return null;
        var boostsAbovePlayer = boosts.Where(b => b.transform.position.y > player.transform.position.y);
        if (!boostsAbovePlayer.Any())
            return null;
        return
            boostsAbovePlayer.OrderBy(b => Vector3.Distance(player.transform.position, b.transform.position)).
            First().transform;
    }

   
}