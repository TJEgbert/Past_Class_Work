//
// Created by Trevor on 11/13/2022.
//

#ifndef EXPRESSIONTREE_H
#define EXPRESSIONTREE_H
#include <iostream>
#include <string>
#include <math.h>

struct Node
{
    std::string data;
    Node *left;
    Node *right;
};


class ExpressionTree
{

public:

    ExpressionTree();  //default constructor creates an empty expression tree
    ExpressionTree(std::string expr); //Creates an expression tree from the given string expression
    void setExpression(std::string expr); //Clears the expression tree and stores the given expression in a new tree
    int getResult(); //return the results of evaluating the expression tree
    void printParseTreeInOrder(std::ostream& out); //outputs the tree to the ostream& using an in-order traversal
    void printParseTreePostOrder(std::ostream& out); //outputs the tree to the ostream& using post-order traversal
    ExpressionTree(const ExpressionTree& copy);
    ExpressionTree& operator=(const ExpressionTree& copy);
    ~ExpressionTree();

private:

    Node *root_;
    int currPos_;
    std::string expr_;
    void insert(Node *curr);
    int results(Node *curr);
    void deleteTree(Node *curr);
    void postOrder(std::ostream& out, Node *curr);
    void inOrder(std::ostream& out, Node *curr);

};

/**
 * @brief: Default constructor for Expression Tree sets the private variabls for the class
 */
ExpressionTree::ExpressionTree()
{
    root_ = nullptr;
    currPos_ = 0;
    expr_ = "";
}

/**
 * @brief: None default constructor takes a string sets up the root node and sets expr_ = expr and calls the insert()
 * to create the tree
 * @param expr std::string a math expression the user wants to solve
 */
ExpressionTree::ExpressionTree(std::string expr)
{
    root_ = new Node;
    root_->left = nullptr;
    root_->right = nullptr;
    root_->data = "";
    currPos_ = 0;
    expr_ = expr;
    insert(root_);
}

/**
 * @brief: A copy constructor sets up the expression tree and copies the expr_ from the other object and uses insert
 * @param copy ExpressionTree object that the user wants to copy
 */
ExpressionTree::ExpressionTree(const ExpressionTree &copy)
{

    root_ = new Node;
    root_->left = nullptr;
    root_->right = nullptr;
    root_->data = "";
    currPos_ = 0;
    expr_ = copy.expr_;
    insert(root_);
}

/**
 * @brief: A copy constructor sets up the expression tree and copies the expr_ from the other object and uses insert
 * @param copy ExpressionTree object that the user wants to copy
 */
ExpressionTree &ExpressionTree::operator=(const ExpressionTree &copy)
{
    root_ = new Node;
    root_->left = nullptr;
    root_->right = nullptr;
    root_->data = "";
    currPos_ = 0;
    expr_ = copy.expr_;
    insert(root_);
}

/**
 * @brief: The destructor for the class it calls the deleteTree help function
 */
ExpressionTree::~ExpressionTree()
{
    deleteTree(root_);
}

/**
 * @brief: helper function for destructor does recursive call on the curr->right and curr->left deleting the node
 * @param curr Node Node that the function runs the operations on
 */
void ExpressionTree::deleteTree(Node *curr)
{
    if(curr != nullptr)
    {
        deleteTree(curr->left);
        deleteTree(curr->right);
        delete curr;
    }
}

/**
 * @brief: A recursive function the loops through the expr_ parsing it into the ExpressionTree
 * @param curr Node that the function runs the operations on
 */
void ExpressionTree::insert(Node *curr)
{

    // Makes sure that currPos_ doesn't go out of bounds if it does it returns
    if(currPos_ < 0 || currPos_ > expr_.size())
    {
        return;
    }
    else
    {
        /**
         * If the character in the string is "(" creates a new node points curr->left to the new node and calls insert
         * on the new node
         */
        if(expr_[currPos_] == '(')
        {
            auto temp = new Node;
            temp->left = nullptr;
            temp->right = nullptr;
            temp->data = "";
            curr->left = temp;
            currPos_++;
            insert(curr->left);
        }

    }
    /**
     * if curr->left = nullptr is checks if the current character is a number if it is it loops through adding it the
     * current node data until it doesn't hit a number when it does it returns
     */
    if(curr->left == nullptr)
    {
        if(std::isdigit(expr_[currPos_]) != 0)
        {
            while (std::isdigit(expr_[currPos_]) != 0)
            {
                curr->data += expr_[currPos_];
                currPos_++;
            }
            return;
        }
    }
    /**
     *  If the character in the string is a math operator it creates a new node and points the curr->right
     *  to the new node and calls insert on the new node
     */
    else if(expr_[currPos_] == '+' || expr_[currPos_] == '/' || expr_[currPos_] == '*' || expr_[currPos_] == '-'
            || expr_[currPos_] == '^')
    {
        curr->data = expr_[currPos_];
        auto temp = new Node;
        temp->right = nullptr;
        temp->left = nullptr;
        temp->data = "";
        curr->right = temp;
        currPos_++;
        insert(curr->right);
    }

    // If the current character is ")" it increases the currPos by one and returns
    if(expr_[currPos_] == ')')
    {
        currPos_++;
        return;
    }
}

/**
 * @brief: Gets the result of the ExpressionTree calls the result function on the root_ node
 * @return int the answer to the ExpressionTress expression
 */
int ExpressionTree::getResult()
{
    return results(root_);
}

/**
 * @brief: A helper function for getResults does recursive call to get the results if the ExpressionTree
 * @param curr the node that is being checked what contains for the arithmetic
 * @return the results of the arithmetic or the number from the node
 */
int ExpressionTree::results(Node *curr)
{
    // Checks to see the node is null and if the expr_ is empty if so it returns
    if(curr == nullptr || expr_.empty())
    {
        return 0;
    }
    else
    {
        /**
         * checks if the node data contains a math operator if it calls itself on the left and right and does the
         * associated with the math operator
         */
        if(curr->data == "+" || curr->data == "-" ||curr->data == "*" || curr->data == "/" || curr->data == "^")
        {
            if(curr->data == "+")
            {
                int left = results(curr->left);
                int right = results(curr->right);
                return left + right;
            }
            else if(curr->data == "-")
            {
                int left = results(curr->left);
                int right = results(curr->right);
                return left - right;
            }
            else if(curr->data == "*")
            {
                int left = results(curr->left);
                int right = results(curr->right);
                return left * right;
            }
            else if(curr->data == "/")
            {
                int left = results(curr->left);
                int right = results(curr->right);
                return left / right;
            }
            else if(curr->data == "^")
            {
                int left = results(curr->left);
                int right = results(curr->right);
                return std::pow(left, right);
            }
        }
        else
        {
            // returns the number of the current node
            return std::stoi(curr->data);
        }
    }
}

/**
 * @brief Checks to see if root_ is not null if so it calls deleteTree on the root the clear the ExpressionTree.  Sets
 * up the root node sets the private variables and call insert on the root_.  Else it does the same thing with calling
 * the deleteTree
 * @param expr std::string an expression that the user wants to solve
 */
void ExpressionTree::setExpression(std::string expr)
{
    if(root_ != nullptr)
    {
        deleteTree(root_);
        root_ = new Node;
        root_->right = nullptr;
        root_->left = nullptr;
        root_->data = "";
        currPos_ = 0;
        expr_ = expr;

        insert(root_);
    }
    else
    {
        root_ = new Node;
        root_->right = nullptr;
        root_->left = nullptr;
        root_->data = "";
        expr_ = expr;
        insert(root_);
    }

}

/**
 * @brief Friend function of printParseTreeInOrder Outputs the data from the tree in order. Does a cursive call t
 * o itself on the curr->left and curr->Right
 * @param out ostream the user wants to out put to
 * @param curr the node the the function is accessing the data from
 */
void ExpressionTree::inOrder(std::ostream &out, Node *curr)
{
    if(curr)
    {
        inOrder(out, curr->left);
        out << curr->data;
        inOrder(out, curr->right);
    }
}

/**
 * @brief: Calls the inOrder helper function on the get the tree in order
 * @param out ostream the user wants to output to
 */
void ExpressionTree::printParseTreeInOrder(std::ostream& out)
{
    inOrder(out, root_);
}

/**
 * @brief helper function to output the data left nod right node and internal node
 * @param out the ostream to output to
 * @param curr the curr node that the function is accessing the data from
 */
void ExpressionTree::postOrder(std::ostream &out, Node *curr)
{
    if(curr)
    {
        if(curr->left)
        {
            postOrder(out, curr->left);
            out << " ";
        }
        if(curr->right)
        {
            postOrder(out, curr->right);
            out << " ";
        }
        out << curr->data;
    }
}

/**
 * @brief: Calls the helper function postOrder on the root node
 * @param out ostream the user wants to output to
 */
void ExpressionTree::printParseTreePostOrder(std::ostream& out)
{
    postOrder(out, root_);
}



#endif //EXPRESSIONTREE_H
