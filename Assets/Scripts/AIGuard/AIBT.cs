using BehTree;
using System.Collections.Generic;


public class AIBT : Tree
{
    public UnityEngine.Transform[] waypoints;

    public static float speed = 2f;
    public static float fovRange = 6f;
    public static float attackRange = 1f;

    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            new Sequence(new List<Node>
            {
                new CheckEnemyInAttack(transform),
               new TaskAttack(transform),
            }),
            new Sequence(new List<Node>
            {
                new CheckEnemyInFOV(transform),
                new TaskFollow(transform),
            }),
            new TaskPatrol(transform, waypoints),
        });

        return root;
    }
}
