using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public float speed = 1.5f;
    public float randomMovementRange = 2, randomMovementTime = 1f;
    public Team team { get; set; }



    Vector2 _targetPoint;
    float _time;
    SpriteRenderer _renderer;

    void Start()
    {
        _renderer = GetComponentInChildren<SpriteRenderer>();
        _renderer.color = GameManager.instance.teamColors[this.team.teamId];
        _targetPoint = transform.position;
    }
    private void FixedUpdate()
    {
        if (_time <= 0)
        {
            _targetPoint = (Vector2)transform.position + Random.insideUnitCircle * randomMovementRange;
            _time = Random.value * randomMovementTime;
        }
        else
        {
            _time -= Time.fixedDeltaTime;
            transform.position = Vector2.Lerp(transform.position, _targetPoint, Time.fixedDeltaTime * speed);
        }

    }
}
