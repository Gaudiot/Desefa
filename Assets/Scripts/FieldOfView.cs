using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [Range(0,10)]
    public float viewRadius;
    [Range(0,360)]
    public float viewAngle;

    public float meshResolution;

    public MeshFilter viewMeshFilter;
    Mesh viewMesh;

    void Start(){
        viewMesh = new Mesh();
        viewMesh.name = "View Mesh";
        viewMeshFilter.mesh = viewMesh;
    }

    void Update() {
        DrawFieldOfView ();
    }

    void DrawFieldOfView() {
        int stepCount = Mathf.RoundToInt(viewAngle * meshResolution);
        float stepAngleSize = viewAngle / stepCount;
        List<Vector3> viewPoints = new List<Vector3> ();
        for (int i = 0; i <= stepCount; i++){
            float angle = transform.eulerAngles.z - viewAngle / 2 + stepAngleSize * i;
            ViewCastInfo newViewCast = ViewCast (angle);
            viewPoints.Add(newViewCast.point);
        }

        int vertexCount = viewPoints.Count + 1;
        Vector3[] vertices = new Vector3[vertexCount];
        int[] triangles = new int[(vertexCount-2)*3];

        vertices[0] = Vector3.zero;
        for (int i=0; i< vertexCount-1; i++){
            vertices[i+1] = transform.InverseTransformPoint(viewPoints [i]);

            if (i < vertexCount-2){
                triangles[i*3] = 0;
                triangles[i * 3 + 1] = i + 1;
                triangles[i * 3 + 2] = i + 2;
            }
        }

        viewMesh.Clear ();
        viewMesh.vertices = vertices;
        viewMesh.triangles = triangles;
        viewMesh.RecalculateNormals ();
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal){
        if (!angleIsGlobal){
            angleInDegrees += transform.eulerAngles.z;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad),Mathf.Cos(angleInDegrees * Mathf.Deg2Rad),0);
    }

    ViewCastInfo ViewCast(float globalAngle){
        Vector3 dir = DirFromAngle(globalAngle, true);

        return new ViewCastInfo (false, transform.position + dir * viewRadius, viewRadius, globalAngle);
    }

    public struct ViewCastInfo {
        public bool hit;
        public Vector3 point;
        public float dst;
        public float angle;

        public ViewCastInfo(bool _hit, Vector3 _point, float _dst, float _angle){
            hit = _hit;
            point = _point;
            dst = _dst;
            angle = _angle;
        }
    }
}
