using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    //let camera follow target
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;

        private Vector3 _offset;

        private void Start()
        {
            _offset = transform.position - target.position;
        }

        private void LateUpdate()
        {
            transform.position = target.position + _offset;
        }
    }
}
