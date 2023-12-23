using UnityEngine;

public class Programma : MonoBehaviour
{
    public LineRenderer linerender;
    public void Risovat()
    {

        var graph = new Graph();

        var v1 = new Vertex(1);
        var v2 = new Vertex(2);
        var v3 = new Vertex(3);
        var v4 = new Vertex(4);
        var v5 = new Vertex(5);
        var v6 = new Vertex(6);

        graph.AddVertex(v1);
        graph.AddVertex(v2);
        graph.AddVertex(v3);
        graph.AddVertex(v4);
        graph.AddVertex(v5);
        graph.AddVertex(v6);

        graph.AddEdge(v1, v2);
        graph.AddEdge(v2, v3);
        graph.AddEdge(v2, v4);
        graph.AddEdge(v2, v6);
        graph.AddEdge(v3, v2);
        graph.AddEdge(v3, v4);
        graph.AddEdge(v3, v5);
        graph.AddEdge(v4, v2);
        graph.AddEdge(v4, v3);
        graph.AddEdge(v4, v5);
        graph.AddEdge(v4, v6);
        graph.AddEdge(v5, v3);
        graph.AddEdge(v5, v4);
        graph.AddEdge(v5, v6);
        graph.AddEdge(v6, v2);
        graph.AddEdge(v6, v4);
        graph.AddEdge(v6, v5);

        GetMatrix(graph);

        GetVariants(graph, linerender);
    }

    public void Remove()
    {
        linerender.positionCount = 0;
    }

    private static void GetVariants(Graph graph, LineRenderer line)
    {
        int final = 5;
        var matrix = graph.GetMatrix();
        int perelet = 0;
        int num = 0;
        int[] variants = new int[graph.VertexCount];
        int[] min = new int[2];
        GameObject GO;
        for (int q = 0; q < graph.VertexCount; q++)
        {
            variants[q] = 99;
        }
        for (int i = 0; i < graph.VertexCount;)
        {
            if (perelet != 0)
            {
                i = perelet;
            }
            for (int j = graph.VertexCount - 1; j > 0; j--)
            {
                Debug.Log(graph.VertexCount);
                for (int w = 0; w < graph.VertexCount; w++)
                {
                    if (matrix[i, w] != 0)
                        variants[w] = matrix[i, w];
                    else variants[w] = 99999;
                }
                min[1] = Mathf.Min(variants);
                if (matrix[i, j] == min[1])
                {
                    min[0] = j;
                    GO = GameObject.Find((i + 1).ToString());
                    if (i == final)
                    {
                        line.positionCount++;
                        line.SetPosition(num, GO.transform.position);
                        return;
                    }
                    perelet = j;
                    line.positionCount++;
                    line.SetPosition(num, GO.transform.position);


                    num++;
                    break;
                }
            }
            if (perelet == 0)
            {
                i++;
            }
        }
    }

    private static void GetMatrix(Graph graph)
    {
        var matrix = graph.GetMatrix();
        for (int i = 0; i < graph.VertexCount; i++)
        {
            for (int j = 0; j < graph.VertexCount; j++)
            {
            }
        }
    }
}
