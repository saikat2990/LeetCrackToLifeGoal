namespace LeetCrackToLifeGoal
{
    internal class FindItinerarys
    {
        public IList<string> FindItinerary(IList<IList<string>> tickets)
        {
            var graph = new Dictionary<string, List<string>>();
            var ans = new List<string>();
            for (int i = 0; i < tickets.Count; i++)
            {
                if (!graph.ContainsKey(tickets[i][0]))
                {
                    graph[tickets[i][0]] = new List<string>();
                }
                graph[tickets[i][0]].Add(tickets[i][1]);
            }

            foreach (var destinations in graph.Values)
            {
                destinations.Sort((a, b) => b.CompareTo(a));
            }

            void DFS(string tag)
            {
                while (graph.ContainsKey(tag) && graph[tag].Count > 0)
                {
                    var next = graph[tag][^1];
                    graph[tag].RemoveAt(graph[tag].Count - 1);
                    DFS(next);
                }
                ans.Add(tag);

            }
            DFS("JFK");
            ans.Reverse();
            return ans;
        }

    }
}
