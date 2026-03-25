using System;
using System.Collections.Generic;
using UnityEngine;
using Zlipacket.CoreZlipacket.Tools;

namespace Cat.Data
{
    [CreateAssetMenu(fileName = "CatConfig", menuName = "CatConfig")]
    public class SO_CatConfig : ScriptableObject
    {
        public CatData data;
    }

    [Serializable]
    public class CatData
    {
        /*[Header("Bush Task Config")]
        public SerializableDictionary<CatDirection, BrushConfig> brushConfig;
        
        public void OnGizmosDraw()
        {
            foreach (var config in brushConfig.Values)
            {
                config.DrawDebug();
            }
        }*/
    }

    /*[Serializable]
    public class BrushConfig
    {
        public Vector2Int brushNum;
        public List<Vector4> positionsAndAngles;

        public bool debug = false;
        public Color debugColor = Color.magenta;

        public void DrawDebug()
        {
            if (!debug)
                return;
            
            Gizmos.color = debugColor;
            foreach (var position in positionsAndAngles)
            {
                Vector3[] points = new Vector3[3]
                {
                    new  Vector3(position.x, position.y, 0f),
                    position.z != 0f ? new Vector3(position.x, position.y, 0f) + (Vector3)ZlipUtilities.DegreeToVector2(position.z) * 0.5f : new  Vector3(position.x, position.y, 0f),
                    position.w != 0f ? new  Vector3(position.x, position.y, 0f) + (Vector3)ZlipUtilities.DegreeToVector2(position.w) * 0.5f : new  Vector3(position.x, position.y, 0f),
                };
                
                Gizmos.DrawSphere(new Vector3(position.x, position.y, 0f), 0.05f);
                Gizmos.DrawLineStrip(new ReadOnlySpan<Vector3>(points), true);
            }
        }
    }*/

    [Serializable]
    public enum CatDirection
    {
        Front,
        Right,
        Back,
        Left
    }
}