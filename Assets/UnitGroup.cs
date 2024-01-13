using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitGroup : MonoBehaviour
{
    public GameObject unitPrefab;
    private int numberOfUnits = 50;
    private Color teamColor;

    private float radius = 100f;

    // Start is called before the first frame update
    void Start()
    {
        float area = numberOfUnits * 5f;
        radius = Mathf.Sqrt(area / Mathf.PI);

        for (int i = 0; i < numberOfUnits; i++) {
            Vector2 randCircle = Random.insideUnitCircle * radius;
            Individual u = Instantiate(unitPrefab, transform.position + new Vector3(randCircle.x, 0f, randCircle.y), Quaternion.identity).GetComponent<Individual>();
            u.SetGroup(this);
        }

        GetComponent<CapsuleCollider>().radius = radius;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float Radius {
        get { return radius; }
    }

    
}
