using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    //let camera follow target
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;
        public float lerpSpeed = 1.0f;

        private Vector3 offset;

        private Vector3 targetPos;

        private void Start()
        {
            if (target == null) return;

            offset = transform.position - target.position;

            if (DataPersistency.hasStoredPlayerCoords())
            {
                float[] coords = DataPersistency.getCameraCoords();
                this.transform.position = new Vector3(coords[0], coords[1], 0);
            }
        }

        private void Update()
        {
            if (target == null) return;

            targetPos = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.deltaTime);
        }

    }
}
