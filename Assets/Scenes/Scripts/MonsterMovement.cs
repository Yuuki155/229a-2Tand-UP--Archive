using UnityEngine;
using System.Collections;

public class MonsterMovement : MonoBehaviour
{
    public float moveDistance = 4f;   
    public float moveSpeed = 2f;      

    Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        StartCoroutine(MoveLoop());
    }

    IEnumerator MoveLoop()
    {
        while (true)
        {
            yield return MoveToX(startPos.x + moveDistance); 
            yield return MoveToX(startPos.x);                
            yield return MoveToX(startPos.x - moveDistance); 
            yield return MoveToX(startPos.x);                
        }
    }

    IEnumerator MoveToX(float targetX)
    {
        while (Mathf.Abs(transform.position.x - targetX) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                new Vector3(targetX, transform.position.y, transform.position.z),
                moveSpeed * Time.deltaTime
            );
            yield return null;
        }
    }
}
