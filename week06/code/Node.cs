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
        if(value == Data){
            return;
        }

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
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
        if(value == Data){
            return true;
        }
        if(value < Data){
            // Search in the left subtree
            return Left?.Contains(value) ?? false;
        }
        else{
            return Right?.Contains(value) ?? false; // we then Search in the left subtree
        }
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
         // Base case: If the node has no children, height is 1
        if (Left == null && Right == null)
            return 1;

        // Recursively get the height of left and right subtrees
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;

        // The height of the tree is 1 + max(left height, right height)
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}