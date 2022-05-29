using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class CameraFollow : MonoBehaviour
    {
        public float xMargin = 1f; // Расстояние по оси X, на которое игрок может переместиться, прежде чем камера последует за ним.
        public float yMargin = 1f;
        public float xSmooth = 8f; // Насколько плавно камера отслеживает движение игрока.
        public float ySmooth = 8f; 

        private Transform m_Player;

        private void Awake()
        {
            m_Player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        private bool CheckXMargin()
        {
            // Возвращает true, если расстояние между камерой и игроком по оси x больше, чем поле x.
            return Mathf.Abs(transform.position.x - m_Player.position.x) > xMargin;
        }

        private bool CheckYMargin()
        {
            return Mathf.Abs(transform.position.y - m_Player.position.y) > yMargin;
        }

        private void Update()
        {
            TrackPlayer();
        }

        private void TrackPlayer()
        {
            // По умолчанию целевые координаты x и y камеры являются ее текущими координатами x и y.
            float targetX = transform.position.x;
            float targetY = transform.position.y;

            // Если игрок вышел за границу х
            if (CheckXMargin())
            {
                // ... целевая координата x должна быть Lerp между текущей позицией x камеры и текущей позицией x игрока.
                targetX = Mathf.Lerp(transform.position.x, m_Player.position.x, xSmooth*Time.deltaTime);
            }

            if (CheckYMargin())
            {
                targetY = Mathf.Lerp(transform.position.y, m_Player.position.y, ySmooth*Time.deltaTime);
            }

            transform.position = new Vector3(targetX, targetY, transform.position.z);
        }
    }
}
