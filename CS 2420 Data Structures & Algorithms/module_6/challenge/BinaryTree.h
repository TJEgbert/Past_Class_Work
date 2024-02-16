#ifndef BINARY_TREE_H
#define BINARY_TREE_H

template <class Type>
struct Node {
    Type item;
    Node<Type> *left;
    Node<Type> *right;
};

template <class Type>
class BinaryTree
{
    public:
        BinaryTree();
        ~BinaryTree();
        void insert(Type item);
        void preOrder();
        void inOrder();
        void postOrder();
        int nodeCount();
        Node<Type>*find(Type item);
        Node<Type>*findRightMostNode(Node<Type> *find);
        void remove(Type item);
        int  height();
        int leavesCount();

        BinaryTree(const BinaryTree& b);
        BinaryTree& operator=(const BinaryTree& b);


    protected:
        Node<Type> *root;

    private:
        void destroy(Node<Type> * curr);
        void insert(Type item, Node<Type> * curr);
        void preOrder(Node<Type> *curr);
        void postOrder(Node<Type> *curr);
        void inOrder(Node<Type> * curr);
        int nodeCount(Node<Type> * curr);
        int leavesCount(Node<Type> * curr);
        Node<Type>*find(Type item, Node<Type> *curr);
        Node<Type>* remove(Type item, Node<Type>*curr);
        int height(int level, Node<Type>*curr);

        void copyTree(Node<Type>* curr);
};

/**
 * @brief: Default constructor for the BinaryTree class sets the root = nullptr
 * @tparam Type any data type the can be used with = < >
 */
template <class Type>
BinaryTree<Type>::BinaryTree()
{
    root = nullptr;
}

/**
 * @brief: Destructor for BinaryTree calls the destroy helper function
 * @tparam Type any data type the can be used with = < >
 */
template <class Type>
BinaryTree<Type>::~BinaryTree()
{
    destroy(root);
}

/**
 * @brief: Copy constructor for BinaryTree calls the copyTree helper function
 * @tparam Type any data type the can be used with = < >
 * @param b the BinaryTree object you want to copy
 */
template <class Type>
BinaryTree<Type>::BinaryTree(const BinaryTree<Type> &b)
{
    copyTree(b.root);
}

/**
 * @brief: Copy constructor for BinaryTree calls the copyTree helper function
 * @tparam Type any data type the can be used with = < >
 * @param b the BinaryTree object you want to copy
 * @return the updated the BinaryTree object
 */
template <class Type>
BinaryTree<Type> &BinaryTree<Type>::operator=(const BinaryTree<Type> &b)
{
    copyTree(b.root);
    return *this;
}

/**
 * @brief: Calls the insert function with the curr->item and then recursive call to itself on the curr node left and
 * right
 * @tparam Type any data type the can be used with = < >
 * @param curr the node that is that the item getting copy and calling the next on
 */
template <class Type>
void BinaryTree<Type>::copyTree(Node<Type> *curr)
{
    if(curr)
    {
        insert(curr->item);
        copyTree(curr->left);
        copyTree(curr->right);
    }
}

/**
 * @brief: Delete the BinaryTree by recursive calling it on the left and right node.  Then deletes the current node
 * @tparam Type any data type the can be used with = < >
 * @param curr the node you are calling left and right on and deleting
 */
template <class Type>
void BinaryTree<Type>::destroy(Node<Type> * curr)
{
    if(curr != nullptr)
    {
        destroy(curr->left);
        destroy(curr->right);
        delete curr;
    }
}

/**
 * @brief: If the root is equal to nullptr it sets the root to a new Node and insert the item and sets the left and
 * right to nullptr.  Else it calls the helper function for insert
 * @tparam Type any data type the can be used with = < >
 * @param item item you want to insert into the BinaryTree
 */
template <class Type>
void BinaryTree<Type>::insert(Type item)
{
    if(root == nullptr)
    {
        root = new Node<Type>;
        root->item = item;
        root->left = nullptr;
        root->right = nullptr;
    }
    else
    {
        insert(item, root);
    }
}

/**
 * @brief: The helper function for insert function.  It checks the binary tree to find where to insert the new node and
 * the item.  It does a cursive call if the curr node pointer doesn't meet the if statements
 * @tparam Type any data type the can be used with = < >
 * @param item the data you want to insert into the BinaryTree
 * @param curr the node that is being checked if pointer meet the requirements to insert the new node
 */
template <class Type>
void BinaryTree<Type>::insert(Type item, Node<Type> * curr)
{
    // Checks if the item is less the curr->item
    if(item < curr->item)
    {
        // if so it checks to see if the curr->left is empty if so it creates a new node and insert the item
        if(curr->left == nullptr)
        {
            auto temp = new Node<Type>;
            temp->item = item;
            temp->right = nullptr;
            temp->left = nullptr;
            curr->left = temp;
        }
        else
        {
            // Does a recursive call to left node to check it
            insert(item, curr->left);
        }// Ends the inner if
    }// Ends the outer if
    else
    {
        // if item is greater it checks the right pointer to see if its nullptr
        if(curr->right == nullptr)
        {
            // if so it creates a new node and points to it and inserts the item
            auto temp = new Node<Type>;
            temp->item = item;
            temp->right = nullptr;
            temp->left = nullptr;
            curr->right = temp;
        }
        else
        {
            insert(item, curr->right);
        }
    }
}//ends insert

/**
 * @brief Calls the helper function preOrder to output the items formatted
 * @tparam Type any data type the can be used with = < >
 */
template <class Type>
void BinaryTree<Type>::preOrder()
{
    std::cout << "Pre Order: ";
    preOrder(root);
}

/**
 * @brief: it outputs the items in the internal node, left and then the right.  Does a recursive call to the left and
 * right node
 * @tparam Type any data type the can be used with = < >
 * @param curr the node that is getting the item printed out and its left and right node is being called on
 */
template <class Type>
void BinaryTree<Type>::preOrder(Node<Type> *curr)
{
    if(curr)
    {
        std::cout << curr->item << " ";
        preOrder(curr->left);
        preOrder(curr->right);
    }
}

/**
 * @breif: Calls the helper function inOrder to output the items formatted
 * @tparam Type any data type the can be used with = < >
 */
template <class Type>
void BinaryTree<Type>::inOrder()
{
    std::cout << "In Order: ";
    inOrder(root);
}

/**
 * @brief: Formats the items in left internal and right nodes and then does a recursive call on the left and right node
 * @tparam Type any data type the can be used with = < >
 * @param curr the item that is being outputted and its left and right node recursive called
 */
template <class Type>
void BinaryTree<Type>::inOrder(Node<Type> *curr)
{
    if(curr)
    {
        inOrder(curr->left);
        std::cout << curr->item << " ";
        inOrder(curr->right);
    }
}

/**
 * @brief: Calls the helper function postOrder to output the items formatted
 * @tparam Type any data type the can be used with = < >
 */
template <class Type>
void BinaryTree<Type>::postOrder()
{
    std::cout << "Post Order: ";
    postOrder(root);
}

/**
 * @brief Formats the items left right and internal.  Then does a recursive call on left and right nodes
 * @tparam Type any data type the can be used with = < >
 * @param curr the item that is being outputted and its left and right node recursive called
 */
template <class Type>
void BinaryTree<Type>::postOrder(Node<Type> *curr)
{
    if(curr)
    {
        postOrder(curr->left);
        postOrder(curr->right);
        std::cout << curr->item << " ";
    }
}


/**
 * @brief: Returns the number of nodes in the BinaryTree calls the helper function nodeCount to do so
 * @tparam Type any data type the can be used with = < >
 * @return int: the total number if nodes in the BinaryTree
 */
template <class Type>
int BinaryTree<Type>::nodeCount()
{
    return nodeCount(root);
}

/**
 * @brief: Does a count of the nodes in the binary tree by adding 1 with every node.  It does a cursive call on the
 * left and right node.  Then it adds the results together
 * @tparam Type any data type the can be used with = < >
 * @param curr the node that is used to call the recursive call its left and right node
 * @return int the number of nodes in the BinaryTree
 */
template <class Type>
int BinaryTree<Type>::nodeCount(Node<Type> *curr)
{
    if(curr)
    {
        return 1 + nodeCount(curr->left) + nodeCount(curr->right);
    }
    return 0;
}

/**
 * @brief: Returns the number of leave nodes in the BinaryTree.  Calls the helper function leavesCount
 * @tparam Type any data type the can be used with = < >
 * @return int the total number of leave Nodes
 */
template <class Type>
int BinaryTree<Type>::leavesCount()
{
    int total = leavesCount(root);
    return total;
}

/**
 * @brief: Returns one everytime the node left and right pointer are equal to nullptr if not does a recursive call
 * on the left and right node and those counts together
 * @tparam Type any data type the can be used with = < >
 * @param curr the nodes that is being checked if its a leave node if not it calls its left and right node
 * @return int the total number of leave nodes
 */
template <class Type>
int BinaryTree<Type>::leavesCount(Node<Type> *curr)
{

    if(curr)
    {
        if(curr->left == nullptr && curr->right == nullptr)
        {
            return 1;
        }
        else
        {
            return leavesCount(curr->left) + leavesCount(curr->right);
        }
    }

}

/**
 * @brief It returns the node found from the helper function find
 * @tparam Type any data type the can be used with = < >
 * @param item the item the user wants to find in the BinaryTree
 * @return Node: the node containing the item if found
 */
template <class Type>
Node<Type>*BinaryTree<Type>::find(Type item)
{
    return find(item, root);
}

/**
 * @brief: It checks to see if the curr node item equal to item if so it returns the node.  If its less then the item
 * it calls find on the right node curr node. If its greater is calls find and the left nod of curr node else returns
 * nullptr
 * @tparam Type any data type the can be used with = < >
 * @param item the item the user wants to find
 * @param curr the node that is being checked and left or right node being called if needed
 * @return the node that contains the item there looking for
 */
template <class Type>
Node<Type>*BinaryTree<Type>::find(Type item, Node<Type>*curr)
{
    if(curr)
    {
        if(curr->item == item)
        {
            return curr;
        }
        else if(curr->item < item)
        {
            find(item, curr->right);
        }
        else if(curr->item > item)
        {
            find(item, curr->left);
        }
    }
    else
    {
        return nullptr;
    }
}

/**
 * @brief: A recursive function that it will call itself until it finds a node that right point is equal to nullptr
 * @tparam Type any data type the can be used with = < >
 * @param curr the node that is being checked and than calls the right node of it
 * @return turns the right most node if the current path
 */
template <class Type>
Node<Type>*BinaryTree<Type>::findRightMostNode(Node<Type> *curr)
{

    if(curr)
    {
        if(curr->right == nullptr)
        {
            return curr;
        }
        else
        {
            findRightMostNode(curr->right);
        }
    }
}

/**
 * @brief deletes the node the user is trying to remove.  Calls the helper function to help with that
 * @tparam Type any data type the can be used with = < >
 * @param item the item the user wants to remove
 */
template <class Type>
void BinaryTree<Type>::remove(Type item)
{
    delete remove(item, root);
}

/**
 * @brief Finds the nodes that the user wants to remove.  It checks the current right and left pointer to see if its
 * equal to the item and updates the pointers accordingly
 * @tparam Type any data type the can be used with = < >
 * @param item the item the user wants to remove
 * @param curr the node that its pointers are being checked and updated if its found
 * @return Node that ths user wants to delete
 */
template <class Type>
Node<Type>* BinaryTree<Type>::remove(Type item, Node<Type>* curr)
{
    auto leftNode = curr->left;
    auto rightNode = curr->right;
    if(curr)
    {
        if(curr->item < item)
        {
            // Checks the right node item is equal to the item
            if(rightNode->item == item)
            {
                // if its right and left pointer are nullptr it updates curr rights pointer to null and return rightNode
                if(rightNode->right == nullptr && rightNode->left == nullptr)
                {
                    curr->right = nullptr;
                    return rightNode;
                }
                // if only the right is nullptr it updates the curr->right the rightNode->left and returns rightNode
                else if(rightNode->right == nullptr)
                {
                    curr->right = rightNode->left;
                    return rightNode;
                }
                // if only the left is nullptr updates the curr->right to rightNode->right and returns rightNode
                else if(leftNode->left == nullptr)
                {
                    curr->right == rightNode->right;
                    return rightNode;
                }
                else
                {
                    /**
                     * Else it makes copy of the right most node in the rightNode->left and copies the item and sets
                     * the copy to nullptr
                     */
                    auto copyNode = findRightMostNode(rightNode->left);
                    rightNode->item = copyNode->item;
                    copyNode = nullptr;
                    return copyNode;
                }
            }
            // Else it calls the remove on the curr->right node
            remove(item, curr->right);
        }
        else if(curr->item > item)
        {
            // Checks the left node item is equal to the item
            if(leftNode->item == item)
            {
                // if its right and left pointer are nullptr it updates curr left pointer to null and return leftNode
                if(leftNode->right == nullptr && leftNode->left == nullptr)
                {
                    curr->left = nullptr;
                    return leftNode;
                }
                // if only the right is nullptr it updates the curr->left the leftNode->left and returns leftNode
                else if(leftNode->right == nullptr)
                {
                    curr->left = leftNode->left;
                    return leftNode;
                }
                // if only the left is nullptr updates the curr->left to leftNode->right and returns leftNode
                else if(leftNode->left == nullptr)
                {
                    curr->left = leftNode->right;
                    return leftNode;
                }
                else
                {
                    /**
                        * Else it makes copy of the right most node in the leftNode and copies the item and sets
                        * the copy to nullptr
                    */
                    auto copyNode = findRightMostNode(leftNode);
                    leftNode->item = copyNode->item;
                    copyNode = nullptr;
                    return copyNode;
                }
            }

            // Else it calls the remove on the curr->left node
            remove(item, curr->left);
        }
        else
        {
            // if it's equal to the root it does the same thing as end if else statements
            auto copyNode = findRightMostNode(leftNode);
            curr->item = copyNode->item;
            copyNode = nullptr;
            return copyNode;
        }
    }

}

/**
 * @brief Returns the height of the BinaryTree by calling the helper function height
 * @tparam Type any data type the can be used with = < >
 * @return inn the height of the BinaryTree
 */
template <class Type>
int BinaryTree<Type>::height()
{
    return height(0, root);
}

/**
 * @brief It does a recursive call on the left and right of curr Node adding 1 + Max(rightHeight and leftHeight)
 * @tparam Type any data type the can be used with = < >
 * @param curr the node that the pointers are being called for
 * @return int the height of the BinaryTree
 */
template <class Type>
int BinaryTree<Type>::height(int level, Node<Type>*curr)
{
    if(curr)
    {
        int leftHeight = height(leftHeight, curr->left);
        int rightHeight = height(rightHeight, curr->right);
        return 1 + std::max(leftHeight, rightHeight);
    }
    return -1;
}

#endif // BINARY_TREE_H
