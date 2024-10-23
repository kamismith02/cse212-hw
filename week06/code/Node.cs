public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if (value > Data)
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        if (value == Data)
        {
            // Value found
            return true;
        }
        else if (value < Data && Left != null)
        {
            // Search in the left subtree
            return Left.Contains(value);
        }
        else if (value > Data && Right != null)
        {
            // Search in the right subtree
            return Right.Contains(value);
        }

        // Value not found
        return false;
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        // Base case: If both left and right are null, this is a leaf node, return 1.
        int leftHeight = Left != null ? Left.GetHeight() : 0;
        int rightHeight = Right != null ? Right.GetHeight() : 0;

        // Return 1 (the current node) plus the maximum height of the left and right subtrees.
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}