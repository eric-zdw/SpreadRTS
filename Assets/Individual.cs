using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Individual : MonoBehaviour
{
    UnitGroup unitGroup;
    private Vector3 direction;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        direction = NewBoidDirection();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * Time.deltaTime * speed;
        if (Vector3.Distance(transform.position, unitGroup.transform.position) > unitGroup.Radius) {
            direction = NewBoidDirection();
            speed = 10f;
        }
        else {
            speed = 5f;
        }
    }

    public void SetGroup(UnitGroup u) {
        unitGroup = u;
    }

    private Vector3 NewBoidDirection() {
        Vector2 randomPoint = Random.insideUnitCircle * unitGroup.Radius;
        Vector3 d = unitGroup.transform.position + new Vector3(randomPoint.x, 0f, randomPoint.y) - transform.position;
        return d.normalized;
    }
}
