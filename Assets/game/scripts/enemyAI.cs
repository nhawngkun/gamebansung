using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class enemyAI : MonoBehaviour
{
    public SpriteRenderer characterSR;
    public float moveSpeed;
    public float nextWPDistance;
    public Seeker seeker;
    public Transform target;
    Path path;
    Coroutine moveCoroutine;
    private void Start(){
        target = FindObjectOfType<player>().gameObject.transform;
        CalculatePath();

    }
    void CalculatePath()
    {
        if(seeker.IsDone()){
            seeker.StartPath(transform.position,target.position,OnPathCallback);
        }
    }
    void OnPathCallback(Path p){
        if(path.error) return;
        path = p;
    }
    void MoveToTarget(){
        if(moveCoroutine !=null) StopCoroutine(moveCoroutine);
        moveCoroutine = StartCoroutine(MoveToTargetCoroutine());

    }
    IEnumerator MoveToTargetCoroutine(){
        int currentWP = 0;
        while (currentWP < path.vectorPath.Count){
            Vector2 direction =((Vector2)path.vectorPath[currentWP]- (Vector2)transform.position).normalized;
            Vector3 force = direction * moveSpeed * Time.deltaTime;
            transform.position += force;
            float distance =Vector2.Distance(transform.position, path.vectorPath[currentWP]);
            if(distance < nextWPDistance){
                currentWP++;
            }
            if ( force.x != 0){
                if( force.x > 0)
                 characterSR.transform.localScale = new Vector3(-6,6,0);
                 else characterSR.transform.localScale = new Vector3(-6,6,0);
            
            yield return null;

        }

    }
    }}
