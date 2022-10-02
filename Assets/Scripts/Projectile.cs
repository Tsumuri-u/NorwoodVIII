using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    BoxCollider2D boxCollider;
    private float speed = 5f;
    private bool hit;
    private float direction;
    private float lifetime;

    private void Awake() {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update() {
        if(hit) return;
        lifetime += Time.deltaTime;
        if (lifetime > 0.1) {
            Deactivate();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        hit = true;
        boxCollider.enabled = false;
        Deactivate();
    }

    public void SetDirection(float dir) {
        lifetime = 0;
        direction = dir;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != direction) {
            localScaleX = -localScaleX;
        }

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void Deactivate() {
        gameObject.SetActive(false);
    }
 }
