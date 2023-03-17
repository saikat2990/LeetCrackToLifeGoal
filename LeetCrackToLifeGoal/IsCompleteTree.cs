using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using leetCrack;

namespace LeetCrackToLifeGoal
{
    internal class IsCompleteTree
    {
        public bool LastLayerData(TreeNode node, int Lastlayer, List<int> lastLayerData, int currentLayer)
        {
            currentLayer++;
            if (currentLayer < Lastlayer - 1 && (node.right == null || node.left == null))
            {
                lastLayerData.Clear();
                return false;
            }

            if (Lastlayer - 1 == currentLayer)
            {
                if (node.left != null)
                    lastLayerData.Add(node.left.val);
                else lastLayerData.Add(-1);
                if (node.right != null)
                    lastLayerData.Add(node.right.val);
                else lastLayerData.Add(-1);
            }

            if (node.right != null)
            {
                var data = LastLayerData(node.right, Lastlayer, lastLayerData, currentLayer);
                if (data == false) return false;
            }
            if (node.left != null) { var data = LastLayerData(node.left, Lastlayer, lastLayerData, currentLayer); if (data == false) return false; }
            return true;
        }

        public void TraverseData(TreeNode node, int layer, List<int> layerList)
        {
            layer++;
            layerList.Add(layer);
            if (node.right != null) TraverseData(node.right, layer, layerList);
            if (node.left != null) TraverseData(node.left, layer, layerList);

        }
        public bool IsCompleteTrees(TreeNode root)
        {
            if (root.right == null && root.left == null) return true;
            List<int> layerList = new List<int>();
            TraverseData(root, 0, layerList);
            foreach (int layer in layerList) { Console.WriteLine(layer); }
            layerList.Sort();
            layerList.Reverse();
            var lastKayerData = new List<int>();

            var firstElement = layerList.FirstOrDefault();
            var data = LastLayerData(root, firstElement, lastKayerData, 0);
            if (data == false) return false;
            if (lastKayerData.Count == 0) return false;
            foreach (var VARIABLE in lastKayerData)
            {
                Console.WriteLine(VARIABLE.ToString());
            }

            var tag = false;
            for (int i = 0; i < lastKayerData.Count; i++)
            {
                if (lastKayerData[i] == -1 && i != lastKayerData.Count - 1 && lastKayerData[i + 1] > 0)
                {
                    return false;
                }

                if (lastKayerData[i] > -1) tag = true;
            }

            if (!tag) return false;
            return true;
            Console.WriteLine(firstElement.ToString());


        }



    }
}
