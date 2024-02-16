/**
 * Trevor Egbert
 * CS 2130
 * Program - Relations: Properties and Closures
 * Dr. Hunson
 * Due: 8/1/2023
 * Filename: main.cpp
 * Version: 1.0
 * Student discussions: None
 * Shows the relations between the user entered matrices using boolean matrices
 */
#include <iostream>

/**
 * @brief takes in a 2d array and fills it with zero
 * @param array: the array the user wants to fill
 */
void all_zero(int (&array)[10][10])
{
    for (auto & i : array)
    {
        for (int & j : i)
        {
            j = 0;
        }
    }

}

/**
 * @brief Asks the user for inputs and stores a 1 in the location
 * @param array: the place the user wants to store 1 in
 * @return int size: the size of the matrix
 */
int read_input(int (&array)[10][10])
{

    int x = 1;
    int y = 1;
    int size = 0;

    while(x != 0 && y!= 0)
    {
        std::cin >> x >> y;

        // makes sure the inputs between 0 and 10
        while(x < 0 || x > 10 || y < 0 || y > 10)
        {
            std::cout << "Error: Please input numbers 1-9" << std::endl;
            std::cin >> x >> y;
        }

        // loads the 1 into the correct location
        if(x > 0 && y > 0)
        {
            array[x-1][y-1] = 1;
        }
        else
        {
            // breaks if the input is 0 0
            break;
        }

        // update size
        if(size < x)
        {
            size = x;
        }
        if(size < y)
        {
            size = y;
        }
    }
    return size;
};

/**
 * @brief prints the passed in array
 * @param array: the array the user wants to print
 * @param size: the size of used array
 */
void print_array(int (&array)[10][10], int size)
{
    for (int i = 0; i < size; ++i)
    {
        for (int j = 0; j < size; ++j)
        {
            std::cout << array[i][j] << " ";
        }
        std::cout << std::endl;
    }
}

/**
 * @breif Does the meet boolean matrices on array_a, and array_b and stores
 * in array_c
 * @param array_a: one of the arrays to preform the meet on
 * @param array_b: the other array to preform the meet on
 * @param array_c: the array the results are stored in
 * @param size: the size of the array
 */
void meet(int (&array_a)[10][10], int (&array_b)[10][10],
          int (&array_c)[10][10], int size)
{
    all_zero(array_c);
    for (int i = 0; i < size; ++i)
    {
        for (int j = 0; j < size; ++j)
        {
            // if at location i,j = 1 in both arrays
            if(array_a[i][j] == 1 && array_b[i][j] == 1)
            {
                array_c[i][j] = 1;
            }
        }
    }

}

/**
 * @breif Does the join boolean matrices on array_a, and array_b and stores
 * in array_c
 * @param array_a: one of the arrays to preform the join on
 * @param array_b: the other array to preform the join on
 * @param array_c: the array the results are stored in
 * @param size: the size of the array
 */
void join(int (&array_a)[10][10], int (&array_b)[10][10]
          ,int (&array_c)[10][10], int size)
{
    all_zero(array_c);
    for (int i = 0; i < size; ++i)
    {
        for (int j = 0; j < size; ++j)
        {
            // if either of the arrays at location j,i = 1
            if(array_a[i][j] == 1 || array_b[i][j] == 1)
            {
                array_c[i][j] = 1;
            }
        }
    }

}

/**
 * @breif Gets the boolean product from array_a, and array_b and stores in
 * array_c
 * @param array_a: one of the arrays to preform the boolean_product on
 * @param array_b: the other array to preform the boolean_product on
 * @param array_c: the array the results are stored in
 * @param size: the size of the array
 */
void boolean_product(int (&array_a)[10][10], int (&array_b)[10][10]
                     ,int (&array_c)[10][10], int size)
{
    all_zero(array_c);
    for (int i = 0; i < size; ++i)
    {
        for (int j = 0; j < size; ++j)
        {
            for (int k = 0; k < size; ++k)
            {
                // stores the result by doing (array_c)[i][j]
                // or (array_a[i][k] and array_b[k][j])
                array_c[i][j] = (array_c)[i][j] |
                        (array_a[i][k] & array_b[k][j]);
            }
        }
    }

}

/**
 * @brief figures out the complement of array_a and returns the result in
 * array_c
 * @param array_a: the array the user wants to know the complement for
 * @param array_c: the array that stores the result
 * @param size: the size of array a
 */
void complement(int (&array_a)[10][10], int(&array_c)[10][10], int size)
{
    all_zero(array_c);
    for (int i = 0; i < size; ++i)
    {
        for (int j = 0; j < size; ++j)
        {
            if(array_a[i][j] == 0)
            {
                array_c[i][j] = 1;
            }
        }
    }

}

/**
 * @brief Transposes array_a and returns the result in array_c
 * @param array_a: the array the user wants to transpose
 * @param array_c: the array that stores the result
 * @param size: the size of array a
 */
void transpose(int (&array_a)[10][10], int(&array_c)[10][10], int size)
{
    all_zero(array_c);
    for (int i = 0; i < size; ++i)
    {
        for (int j = 0; j < size; ++j)
        {
            array_c[j][i] = array_a[i][j];
        }
    }
}

/**
 * @brief figures out if the passed in array is reflexive
 * @param array_a: the array the user wants to see is reflexive
 * @param size: size of the passed in array
 * @return the corresponding boolean if its true or false
 */
bool isReflexive(int (&array_a)[10][10], int size)
{
    bool reflexive = true;
    for (int i = 0; i < size; ++i)
    {
        if(array_a[i][i] == 0)
        {
            reflexive = false;
        }
    }
    return reflexive;
}

/**
 * @brief figures out if the passed in array is symmetric
 * @param array_a: the array the user wants to see is symmetric
 * @param size: size of the passed in array
 * @return the corresponding boolean if its true or false
 */
bool isSymmetric(int (&array_a)[10][10], int size)
{
    bool symmetric = true;
    for (int i = 0; i < size; ++i)
    {
        for (int j = 0; j < size; ++j)
        {
            if(array_a[i][i] != array_a[i][j])
            {
                symmetric = false;
            }
        }
    }
    return symmetric;
}

/**
 * @brief figures out if the passed in array is antisymmetric
 * @param array_a: the array the user wants to see is antisymmetric
 * @param size: size of the passed in array
 * @return the corresponding boolean if its true or false
 */
bool isAntisymmetric(int (&array_a)[10][10], int size)
{
    bool antisymmetric = true;
    for (int i = 0; i < size; ++i)
    {
        for (int j = 0; j < size; ++j)
        {
            if(i != j && (array_a[i][j] && array_a[j][i]))
            {
                antisymmetric = false;
            }
        }
    }
    return antisymmetric;
}

/**
 * @brief figures out if the passed in array is transitive
 * @param array_a: the array the user wants to see is transitive
 * @param size: size of the passed in array
 * @return the corresponding boolean if its true or false
 */
bool isTransitive(int (&array_a)[10][10], int size)
{
    bool transitive = true;
    for (int i = 0; i < size; ++i)
    {
        for (int j = 0; j < size; ++j)
        {
            for (int k = 0; k < size; ++k)
            {
                if(array_a[j][k] == 1 && array_a[i][k] == 0)
                {
                    transitive = false;
                }
            }
        }
    }
    return transitive;
}

/**
 * @brief It makes a copy of array_a and stores array_c and makes
 * it the reflexive closure of array_a
 * @param array_a: the array that user wants to find the reflexive closure for
 * @param array_c: the array that the user wants to store the reflexive closure
 * @param size: the size of the array_a
 */
void reflexiveClosure(int (&array_a)[10][10], int(&array_c)[10][10], int size)
{
    for (int i = 0; i < size; ++i)
    {
        for (int j = 0; j < size; ++j)
        {
            array_c[i][j] = array_a[i][j];
        }
    }
    for (int i = 0; i < size; ++i)
    {
        array_c[i][i] = 1;
    }
}

/**
 * @brief It makes a copy of array_a and stores array_c and makes it
 * the symmetric closure of array_a
 * @param array_a: the array that user wants to find the symmetric closure for
 * @param array_c: the array that the user wants to store the symmetric closure
 * @param size: the size of the array_a
 */
void symmetricClosure(int (&array_a)[10][10], int(&array_c)[10][10], int size)
{
    for (int i = 0; i < size; ++i)
    {
        for (int j = 0; j < size; ++j)
        {
            array_c[i][j] = array_a[i][j];
        }
    }
    for (int i = 0; i < size; ++i)
    {
        for (int j = 0; j < size; ++j)
        {
            if(array_c[i][j] == 1)
            {
                array_c[j][i] = 1;
            }
        }
    }
}

/**
 * @brief It makes a copy of array_a and stores array_c and makes it
 * the transitive closure of array_a
 * @param array_a: the array that user wants to find the transitive closure for
 * @param array_c: the array that the user wants to store the transitive closure
 * @param size: the size of the array_a
 */
void transitiveClosure(int (&array_a)[10][10], int(&array_c)[10][10], int size)
{
    for (int i = 0; i < size; ++i)
    {
        for (int j = 0; j < size; ++j)
        {
            array_c[i][j] = array_a[i][j];
        }
    }
    for (int k = 0; k < size; ++k)
    {
        for (int i = 0; i < size; ++i)
        {
            for (int j = 0; j < size; ++j)
            {
                array_c[i][j] = array_c[i][j] | (array_c[i][k] & array_c[k][j]);
            }
        }
    }
}

int main() {

    // Sets the arrays
    int array_a[10][10];
    int array_b[10][10];
    int array_c[10][10];
    all_zero(array_a);
    all_zero(array_b);

    // Asks for input and prints out the matrix
    std::cout << "You may have up to a 10x10 matrix, entered as a set of ordered"
                 " pairs one ordered pair per line. For example, 1 3 results in"
                 " a 1 in row 1, column 3. Please enter the matrix as ordered"
                 " pairs x y (0 0 to end matrix input)" << std::endl;

    int size_a = read_input(array_a);

    std::cout << "\nArray A =" << std::endl;
    print_array(array_a, size_a);

    std::cout << std::endl;

    std::cout << "You may have up to a 10x10 matrix, entered as a set of ordered"
                 " pairs one ordered pair per line. For example, 1 3 results in"
                 " a 1 in row 1, column 3. Please enter the matrix as ordered"
                 " pairs x y (0 0 to end matrix input)" << std::endl;


    int size_b = read_input(array_b);

    std::cout << "\nArray B =" << std::endl;
    print_array(array_b, size_b);

    int used_size = 0;

    if(size_a >= size_b)
    {
        used_size = size_a;
    }
    else
    {
        used_size = size_b;
    }


    std::cout << "\nMeet of A and B:" << std::endl;
    meet(array_a,array_b,array_c, used_size);
    print_array(array_c, size_a);

    std::cout << "\nJoin of A and B:" << std::endl;
    join(array_a,array_b,array_c, used_size);
    print_array(array_c, size_a);

    std::cout << "\nBoolean Product of A and B:" << std::endl;
    boolean_product(array_a,array_b,array_c, used_size);
    print_array(array_c, size_a);

    std::cout << "\nThe complement of A:" << std::endl;
    complement(array_a,array_c, size_a);
    print_array(array_c, size_a);

    std::cout << "\nThe transpose of A:" << std::endl;
    transpose(array_a,array_c, size_a);
    print_array(array_c, size_a);

    std::cout << std::endl;


    bool answer = isReflexive(array_a, size_a);
    if(answer)
    {
        std::cout << "Relation A is reflexive" << std::endl;
    }
    else
    {
        std::cout << "Relation A is NOT reflexive" << std::endl;
    }



    answer = isSymmetric(array_a, size_a);
    if(answer)
    {
        std::cout << "Relation A is symmetric" << std::endl;
    }
    else
    {
        std::cout << "Relation A is NOT symmetric" << std::endl;
    }

    answer = isAntisymmetric(array_a, size_a);
    if(answer)
    {
        std::cout << "Relation A is antisymmetric" << std::endl;
    }
    else
    {
        std::cout << "Relation A is NOT antisymmetric" << std::endl;
    }

    answer = isTransitive(array_a, size_a);
    if(answer)
    {
        std::cout << "Relation A is transitive" << std::endl;
    }
    else
    {
        std::cout << "Relation A is NOT transitive" << std::endl;
    }

    std::cout << std::endl;

    std::cout << "The reflexive closure of A:" << std::endl;
    reflexiveClosure(array_a,array_c, size_a);
    print_array(array_c, size_a);

    std::cout << std::endl;

    std::cout << "The symmetric closure of A:" << std::endl;
    symmetricClosure(array_a,array_c, size_a);
    print_array(array_c, size_a);

    std::cout << std::endl;

    std::cout << "The symmetric closure of A:" << std::endl;
    transitiveClosure(array_a,array_c, size_a);
    print_array(array_c, size_a);

    return 0;
}
