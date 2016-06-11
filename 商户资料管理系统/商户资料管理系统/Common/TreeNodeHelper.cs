using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 商户资料管理系统.YatServer;

namespace 商户资料管理系统.Common
{
    public class TreeNodeHelper
    {
        private static YatMingServiceClient _client = ServiceProvider.Clent;

        public static TreeNode InitializeTree(string TreeType)
        {
            TreeNode rootNode = new TreeNode("全部");
            List<TMerchantTypeDTO> result = _client.TMerchantTypeQueryAll().Where(t =>string.IsNullOrWhiteSpace(t.ParentId)).ToList();

            if (result != null && result.Count > 0)
            {
                result.ForEach(t =>
                {
                    TreeNode node = new TreeNode(t.MerchatType);
                    node.Name = t.MerchantId;
                    node.ToolTipText = t.MerchantDes;
                    node.ImageIndex = 0;
                    node.SelectedImageIndex = 1;
                    GetSubNode(ref node, t.MerchantId);
                    rootNode.Nodes.Add(node);
                });
            }
            return rootNode;
        }

        public static void InitializeMerchant(ref TreeNode rootNode)
        {
            TBaseInfoDTO[] result = _client.TBaseInfoQueryAll();
            if (result != null && result.Length > 0)
            {
                foreach (TBaseInfoDTO item in result)
                {
                    TreeNode pNode = new TreeNode();
                    FindParentNode(rootNode, item.MerchantId, ref pNode);
                    TreeNode tempNode = new TreeNode(item.MerchantName);
                    tempNode.Name = item.BaseInfoId;
                    tempNode.ToolTipText = item.MerchantBoss + ":" + item.MerchantTel;
                    tempNode.ImageIndex = 2;
                    tempNode.SelectedImageIndex = 3;
                    tempNode.Tag = item.BaseInfoId;
                    pNode.Nodes.Add(tempNode);
                }
            }
        }

        private static void FindParentNode(TreeNode rootNode, string id, ref TreeNode resultNode)
        {
            if (rootNode.Name == id)
                resultNode = rootNode;
            else
            {
                if (rootNode.Nodes[id] != null)
                    resultNode = rootNode.Nodes[id];

                foreach (TreeNode item in rootNode.Nodes)
                {
                    FindParentNode(item, id, ref resultNode);
                }
            }
        }

        private static void GetSubNode(ref TreeNode node, string pid)
        {
            TMerchantTypeDTO[] result = _client.TMerchantTypeGetByPid(pid);
            if (result != null && result.Length > 0)
            {
                foreach (TMerchantTypeDTO t in result)
                {
                    TreeNode sNode = new TreeNode(t.MerchatType);
                    sNode.Name = t.MerchantId;
                    sNode.ToolTipText = t.MerchantDes;
                    sNode.ImageIndex = 0;
                    sNode.SelectedImageIndex = 1;
                    GetSubNode(ref sNode, t.MerchantId);
                    node.Nodes.Add(sNode);
                }
            }
        }
    }
}
