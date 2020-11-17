public class Solution
{
    private IList<IList<int>> _result;
    private int[] _lowest;
    private int[] _indexes;
    private List<List<int>> _edges;
    private int _id;

    public IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections)
    {
        _result = new List<IList<int>>();

        _lowest = new int[n];
        _indexes = new int[n];

        _edges = BuildEdges(n, connections);
        _id = 1;

        Dfs(0, -1);
        return _result;
    }

    private void Dfs(int current, int parent)
    {
        _indexes[current] = _id++;
        _lowest[current] = _indexes[current];

        foreach (var edge in _edges[current])
        {
            if (edge == parent) continue;
            if (_indexes[edge] == 0) Dfs(edge, current);
            ;

            _lowest[current] = Math.Min(_lowest[current], _lowest[edge]);

            if (_indexes[current] < _lowest[edge])
            {
                _result.Add(new List<int> {current, edge});
            }
        }
    }

    private static List<List<int>> BuildEdges(int n, IList<IList<int>> connections)
    {
        var edges = new List<List<int>>();
        for (int i = 0; i < n; i++)
        {
            edges.Add(new List<int>());
        }

        foreach (var connection in connections)
        {
            edges[connection[0]].Add(connection[1]);
            edges[connection[1]].Add(connection[0]);
        }

        return edges;
    }
}
