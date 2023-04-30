using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCrackToLifeGoal
{
    public class UnionFind
    {
        private int[] parent;
        

        public UnionFind(int n)
        {
            parent = new int[n];
            for (int i = 0; i < n; i++)
            {
                parent[i] = i;
            }
        }

        public int Find(int x)
        {
            if (parent[x] != x) parent[x] = Find(parent[x]);
            return parent[x];
        }

        public void Union(int val1, int val2)
        {
            parent[Find(val1)] = parent[Find(val2)];
        }
    }
    public class UnionFindCharacter
    {
        private char[] parent;

        public UnionFindCharacter()
        {
            parent = new char[26];
            for (int i = 0; i < 26; i++)
            {
                parent[i] = Convert.ToChar('a' +i);
            }
        }

        public Char Find(char x)
        {
            var index = x - 'a';
            if (parent[x - 'a'] != x) parent[x-'a'] = Find(parent[x-'a']);
            return parent[x - 'a'];
        }

        public void Union(Char val1, Char val2)
        {
            parent[Find(val1)-'a'] = parent[Find(val2) - 'a'];
        }
    }
}
