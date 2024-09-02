using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MouseHover : MonoBehaviour
{
    public float circleRadius = 1f;
}

[CustomEditor(typeof(MouseHover))]
public class MouseHoverEditor : Editor
{
    private void OnSceneGUI()
    {
        var linkedObject = target as MouseHover;

        // Calculate the distance from the mouse to the object's position
        Vector3 mousePosition = Event.current.mousePosition;
        mousePosition.y = SceneView.currentDrawingSceneView.camera.pixelHeight - mousePosition.y; // Flip Y-axis
        Ray ray = SceneView.currentDrawingSceneView.camera.ScreenPointToRay(mousePosition);
        Plane plane = new Plane(Vector3.forward, linkedObject.transform.position);
        
        // cast a ray 
        if (plane.Raycast(ray, out float distance))
        {
            // gets world position of mouse 
            Vector3 worldMousePosition = ray.GetPoint(distance);
            float distanceToMouse = Vector3.Distance(worldMousePosition, linkedObject.transform.position);

            // If the mouse is outside the circle radius, draw the green disc tracks last clicked item
            if (distanceToMouse < linkedObject.circleRadius)
            {
                Handles.color = Color.green;
                Handles.DrawSolidDisc(linkedObject.transform.position, Vector3.forward, linkedObject.circleRadius / 4);

                // Mark the scene view as needing a repaint
                SceneView.RepaintAll();
            }
        }
    }
}