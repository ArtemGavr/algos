using System;

namespace ATSDLab2
{
    public class Node
    {
        public int data;
        public Node left;
        public Node right;

        public Node(int data)
        {
            this.data = data;
        }

        public Node() { }
    }

    class BalancedBinarySearchTree
    {
        Node root;

        public BalancedBinarySearchTree(){}

        public bool IsEmpty()
        {
            return root == null;
        }

        public bool IsFull()
        {
            return root != null;
        }

        public int Size()
        {
            return SizeRec(root);
        }
        private int SizeRec(Node current)
        {
            if (current == null)
                return 0;
            else
                return SizeRec(current.left) + SizeRec(current.right) + 1;
        }

        public void AddItem(int data)
        {
            Node node = new Node(data);
            if (root == null)
            {
                root = node;
            }
            else
            {
                root = RecursiveAddItem(root, node);
            }
        }
        private Node RecursiveAddItem(Node current, Node node)
        {
            if (current == null)
            {
                current = node;
                return current;
            }
            else if (node.data < current.data)
            {
                current.left = RecursiveAddItem(current.left, node);
                current = Balance(current);
            }
            else if (node.data > current.data)
            {
                current.right = RecursiveAddItem(current.right, node);
                current = Balance(current);
            }
            return current;
        }

        private Node Balance(Node current)
        {
            int difference = Difference(current);
            if (difference > 1)
            {
                if (Difference(current.left) > 0)
                {
                    current = RotateRight(current);
                }
                else
                {
                    current = RotateLR(current);
                }
            }
            else if (difference < -1)
            {
                if (Difference(current.right) > 0)
                {
                    current = RotateRL(current);
                }
                else
                {
                    current = RotateLeft(current);
                }
            }
            return current;
        }

        private int max(int l, int r)
        {
            return l > r ? l : r;
        }
        private int GetHeight(Node current)
        {
            int height = 0;
            if (current != null)
            {
                int l = GetHeight(current.left);
                int r = GetHeight(current.right);
                int m = max(l, r);
                height = m + 1;
            }
            return height;
        }
        private int Difference(Node current)
        {
            int l = GetHeight(current.left);
            int r = GetHeight(current.right);
            int height = l - r;
            return height;
        }

        private Node RotateLeft(Node parent)
        {
            Node pivot = parent.right;
            parent.right = pivot.left;
            pivot.left = parent;
            return pivot;
        }
        private Node RotateRight(Node parent)
        {
            Node pivot = parent.left;
            parent.left = pivot.right;
            pivot.right = parent;
            return pivot;
        }
        private Node RotateLR(Node parent)
        {
            Node pivot = parent.left;
            parent.left = RotateLeft(pivot);
            return RotateRight(parent);
        }
        private Node RotateRL(Node parent)
        {
            Node pivot = parent.right;
            parent.right = RotateRight(pivot);
            return RotateLeft(parent);
        }

        public void DeleteItem(int key)
        {
            root = RecursiveDeleteItem(root, key);
        }
        private Node RecursiveDeleteItem(Node current, int key)
        {

            if (current == null)
            { return null; }
            else
            {
                if (key < current.data)
                {
                    current.left = RecursiveDeleteItem(current.left, key);
                    //if (Difference(current) < -1)
                    //{
                    //    if (Difference(current.right) <= 0)
                    //    {
                    //        current = RotateLeft(current);
                    //    }
                    //    else
                    //    {
                    //        current = RotateRL(current);
                    //    }
                    //}
                    current = Balance(current);
                }
                else if (key > current.data)
                {
                    current.right = RecursiveDeleteItem(current.right, key);
                    //if (Difference(current) > 1)
                    //{
                    //    if (Difference(current.left) >= 0)
                    //    {
                    //        current = RotateRight(current);
                    //    }
                    //    else
                    //    {
                    //        current = RotateLR(current);
                    //    }
                    //}
                    current = Balance(current);
                }
                else
                {
                    if (current.right != null)
                    {
                        Node parent = current.right;
                        while (parent.left != null)
                        {
                            parent = parent.left;
                        }
                        current.data = parent.data;
                        current.right = RecursiveDeleteItem(current.right, parent.data);
                        //if (Difference(current) > 1)
                        //{
                        //    if (Difference(current.left) >= 0)
                        //    {
                        //        current = RotateRight(current);
                        //    }
                        //    else { current = RotateLR(current); }
                        //}
                        current = Balance(current);
                    }
                    else
                    {
                        return current.left;
                    }
                }
            }
            return current;
        }

        public bool Find(int key)
        {
            if (RecursiveFind(key, root) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private Node RecursiveFind(int key, Node current)
        {
            if (current == null)
            {
                return null;
            }
            if (key < current.data)
            {
                return RecursiveFind(key, current.left);
            }
            else
            {
                if (key == current.data)
                {
                    return current;
                }
                else
                    return RecursiveFind(key, current.right);
            }

        }
      
        public void PrintTree_Preorder()
        {
            if (IsEmpty())
                Console.WriteLine("Tree is empty");
            else
            {
                RecursivePrintTree_Preorder(root);
                Console.WriteLine();
            }
        }
        private void RecursivePrintTree_Preorder(Node current)
        {
            if (current != null)
            {
                Console.Write(current.data + " ");
                RecursivePrintTree_Preorder(current.left);
                RecursivePrintTree_Preorder(current.right);
            }
        }

        public void PrintTree_Inorder()
        {
            if (IsEmpty())
                Console.WriteLine("Tree is empty");
            else
            {
                RecursivePrintTree_Inorder(root);
                Console.WriteLine();
            }
        }
        private void RecursivePrintTree_Inorder(Node current)
        {
            if (current != null)
            {
                RecursivePrintTree_Inorder(current.left);
                Console.Write(current.data + " ");
                RecursivePrintTree_Inorder(current.right);
            }
        }

        public void PrintTree_Postorder()
        {
            if (IsEmpty())
                Console.WriteLine("Tree is empty");
            else
            {
                RecursivePrintTree_Postorder(root);
                Console.WriteLine();
            }
        }
        private void RecursivePrintTree_Postorder(Node current)
        {
            if (current != null)
            {
                RecursivePrintTree_Postorder(current.left);
                RecursivePrintTree_Postorder(current.right);
                Console.Write(current.data + " ");
            }
        }

        public int SumKeys()
        {
            int answer = 0;
            answer = SumKeysReccursive(root);
            return answer; 
        }

        private int SumKeysReccursive(Node current)
        {
            if (current == null)
            {
                return 0;
            }
            else 
            {
                if (current.right != null) 
                    return (SumKeysReccursive(current.right) + SumKeysReccursive(current.left) + current.right.data);
                else return (SumKeysReccursive(current.right) + SumKeysReccursive(current.left) );
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BalancedBinarySearchTree bb = new BalancedBinarySearchTree();
            bb.AddItem(3);
            bb.AddItem(6);
            bb.AddItem(2);
            bb.AddItem(1);
            bb.AddItem(0);
            bb.AddItem(-1);
            bb.AddItem(7);
            bb.AddItem(8);
            bb.AddItem(-2);
            bb.AddItem(-3);
            bb.AddItem(-4);
            bb.AddItem(4);
            // bb.PrintTree_Preorder();
            // bb.DeleteItem(3);
            bb.PrintTree_Preorder();
            Console.WriteLine(bb.SumKeys());
        }
    }
}
