using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    public BoxCollider2D npcDelimitedZone;
    private void Update() {
        this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, npcDelimitedZone.bounds.min.x, npcDelimitedZone.bounds.max.x),
                                                Mathf.Clamp(this.transform.position.y, npcDelimitedZone.bounds.min.y, npcDelimitedZone.bounds.max.y),
                                                this.transform.position.z);
                                                
    }

}