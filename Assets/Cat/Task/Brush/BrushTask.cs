using System;
using System.Collections.Generic;
using UnityEngine;
using Zlipacket.CoreZlipacket.Tools;
using Random = UnityEngine.Random;

namespace Cat.Task.Brush
{
    public class BrushTask : CatTask
    {
        [Header("Config")]
        public Vector2Int brushNumRange;
        public int brushNum;
        public List<BrushObject> brushObjects;
        
        [Header("Debug")]
        public bool debug;
        public Color debugColor = Color.magenta;
        public float debugRadius;
        public float angleLength;

        public override void Initialize()
        {
            brushNum = Random.Range(brushNumRange.x, brushNumRange.y + 1);
            List<BrushObject> activeBrushObjects = brushObjects.GetRandomSubset(brushNum);
            foreach (BrushObject brushObject in activeBrushObjects)
            {
                brushObject.Initialize();
                brushObject.onTaskCompleted.AddListener(OnTaskCompleted);
            }
        }

        public override void Show()
        {
            foreach (var brushObject in brushObjects)
            {
                if (brushObject.isActive && !brushObject.isCompleted)
                    brushObject.gameObject.SetActive(true);
                else
                {
                    brushObject.gameObject.SetActive(false);
                }
            }
        }

        public override void Hide()
        {
            foreach (var brushObject in brushObjects)
            {
                brushObject.gameObject.SetActive(false);
            }
        }

        public override void OnTaskCompleted()
        {
            base.OnTaskCompleted();
            
            Debug.Log(CheckTaskCompleted());
        }

        public override bool CheckTaskCompleted()
        {
            int completeBrushed = 0;

            foreach (BrushObject brushObject in brushObjects)
            {
                if (brushObject.isCompleted)
                    completeBrushed++;
            }
            /*Debug.Log("BrushCompleted: " + completeBrushed);
            Debug.Log("BrushNum: " + brushNum);*/
            
            if (completeBrushed >= brushNum)
                return true;
            
            return false;
        }

        public Vector2Int GetTaskProgress()
        {
            Vector2Int progress = Vector2Int.zero;

            foreach (BrushObject brushObject in brushObjects)
            {
                if (brushObject.isCompleted)
                    progress.x++;
                
                if (brushObject.isActive)
                    progress.y++;
            }
            
            return progress;
        }

        public void OnDrawGizmos()
        {
            if (!debug)
                return;
            
            Gizmos.color = debugColor;
            foreach (BrushObject brushObject in brushObjects)
            {
                Gizmos.DrawSphere(brushObject.transform.position, debugRadius);
                Gizmos.DrawLine(brushObject.transform.position, brushObject.transform.position +
                                                                (brushObject.brushAngle.x != 0
                                                                    ? (Vector3)ZlipUtilities.DegreeToVector2(
                                                                        brushObject.brushAngle.x, angleLength)
                                                                    : Vector3.zero));
                Gizmos.DrawLine(brushObject.transform.position, brushObject.transform.position + 
                                                                (brushObject.brushAngle.y != 0 
                                                                    ? (Vector3)ZlipUtilities.DegreeToVector2(brushObject.brushAngle.y, angleLength) 
                                                                    : Vector3.zero));
            }
        }
    }
}