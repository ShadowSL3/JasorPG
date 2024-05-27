using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;
    private List<Node> path;
    private int targetIndex;

    void Start()
    {
        pathffindignAI pathfinding = GetComponent<pathffindignAI>();
        pathfinding.target = target;
        pathfinding.seeker = transform;
        pathfinding.Invoke("FindPath", 0.1f); // Inizializza il calcolo del percorso
    }

    void Update()
    {
        if (path == null || targetIndex >= path.Count)
            return;

        Node node = path[targetIndex];
        Vector3 targetPosition = new Vector3(node.worldPosition.x, transform.position.y, node.worldPosition.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (transform.position == targetPosition)
        {
            targetIndex++;
        }
    }

    public void OnPathFound(List<Node> newPath)
    {
        path = newPath;
        targetIndex = 0;
    }
}
