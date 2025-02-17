import { useState } from "react";

// creates a square prop to be used
function Square({value, onSquareClick}){       
    return (
        <button 
            className="square"
            // sets the background to the passed in value
            style={{backgroundColor: value}}
            // puts addeds the onSquareClick event to onclick for the button
            onClick={onSquareClick}
            >
        </button>
    );
}

export default function gameBoard(){
    
    // Handles the turn order for the game
    const [redIsNext, setIsNext] = useState(true);
    // an array to hold the square buttons
    const [squares, setSquares] = useState(Array(42).fill(null));
    
    // Handles what happens on the click
    function handleClick(i) {
        // if the game isn't over
        if(!winner){
            // makes a copy of squares array
            const nextSquares = squares.slice();

            // Counters to use to find lowest possible play in a column
            let counter = i;
            let lastNumber = 0;

            // Finds the lowest place in a column
            while(counter < squares.length){
                lastNumber = counter;
                counter += 7;
        };
         // loops through from the lowest place looking up looking for the first possible play
        for(let i = lastNumber; i >= 0; i -= 7){
            // Checks if the the square has been played on
            if(!nextSquares[i]){
                // Change the color of the square depending on redIsNext
                if(redIsNext){
                    nextSquares[i] = "red";
                } else {
                    nextSquares[i] = "blue";
                }
                // Sets nextASquares for the updated board
                setSquares(nextSquares);
                // Switch is redIsNext from what it is not
                setIsNext(!redIsNext);
                break;
            }
        }
        }
        
    }
    // Check if someone won
    const winner = calculateWinner(squares);
    // Used to display a message to the user
    let status;
    // Depending on the winner condition displays the following 
    if(winner == "tie"){
        status = "its a draw";
    }
    else if (winner){
        status = "Winner: " + winner;
    } else {
        // Updates the status and displays the next players turn
        status = "Next player: " + (redIsNext ? "red" : "blue");
    }
    // returns the game board html to display to the user
    return(
        <>
            <div className="status">{status}</div>
            <div className="board-row">
                <Square value={squares[0]} onSquareClick={() => handleClick(0)}/> 
                <Square value={squares[1]} onSquareClick={() => handleClick(1)}/>
                <Square value={squares[2]} onSquareClick={() => handleClick(2)}/>
                <Square value={squares[3]} onSquareClick={() => handleClick(3)}/> 
                <Square value={squares[4]} onSquareClick={() => handleClick(4)}/>
                <Square value={squares[5]} onSquareClick={() => handleClick(5)}/>
                <Square value={squares[6]} onSquareClick={() => handleClick(6)}/>
            </div>
            <div className="board-row">
                <Square value={squares[7]} onSquareClick={() => handleClick(7)}/>
                <Square value={squares[8]} onSquareClick={() => handleClick(8)}/>
                <Square value={squares[9]} onSquareClick={() => handleClick(9)}/>
                <Square value={squares[10]} onSquareClick={() => handleClick(10)}/> 
                <Square value={squares[11]} onSquareClick={() => handleClick(11)}/>
                <Square value={squares[12]} onSquareClick={() => handleClick(12)}/>
                <Square value={squares[13]} onSquareClick={() => handleClick(13)}/>
            </div>
            <div className="board-row">
                <Square value={squares[14]} onSquareClick={() => handleClick(14)}/>
                <Square value={squares[15]} onSquareClick={() => handleClick(15)}/>
                <Square value={squares[16]} onSquareClick={() => handleClick(16)}/>
                <Square value={squares[17]} onSquareClick={() => handleClick(17)}/> 
                <Square value={squares[18]} onSquareClick={() => handleClick(18)}/>
                <Square value={squares[19]} onSquareClick={() => handleClick(19)}/>
                <Square value={squares[20]} onSquareClick={() => handleClick(20)}/>
            </div>
            <div className="board-row">
                <Square value={squares[21]} onSquareClick={() => handleClick(21)}/>
                <Square value={squares[22]} onSquareClick={() => handleClick(22)}/>
                <Square value={squares[23]} onSquareClick={() => handleClick(23)}/>
                <Square value={squares[24]} onSquareClick={() => handleClick(24)}/> 
                <Square value={squares[25]} onSquareClick={() => handleClick(25)}/>
                <Square value={squares[26]} onSquareClick={() => handleClick(26)}/>
                <Square value={squares[27]} onSquareClick={() => handleClick(27)}/>
            </div>
            <div className="board-row">
                <Square value={squares[28]} onSquareClick={() => handleClick(28)}/>
                <Square value={squares[29]} onSquareClick={() => handleClick(29)}/>
                <Square value={squares[30]} onSquareClick={() => handleClick(30)}/>
                <Square value={squares[31]} onSquareClick={() => handleClick(31)}/> 
                <Square value={squares[32]} onSquareClick={() => handleClick(32)}/>
                <Square value={squares[33]} onSquareClick={() => handleClick(33)}/>
                <Square value={squares[34]} onSquareClick={() => handleClick(34)}/>
            </div>
            <div className="board-row">
                <Square value={squares[35]} onSquareClick={() => handleClick(35)}/>
                <Square value={squares[36]} onSquareClick={() => handleClick(36)}/>
                <Square value={squares[37]} onSquareClick={() => handleClick(37)}/>
                <Square value={squares[38]} onSquareClick={() => handleClick(38)}/> 
                <Square value={squares[39]} onSquareClick={() => handleClick(39)}/>
                <Square value={squares[40]} onSquareClick={() => handleClick(40)}/>
                <Square value={squares[41]} onSquareClick={() => handleClick(41)}/>
            </div>
        </>
    );
};

// Checks the winning copndintions
function calculateWinner(squares) {
    const lines = [
        // row 1 wins
      [0, 1, 2, 3],
      [1, 2, 3, 4],
      [2, 3, 4, 5],
      [3, 4, 5, 6],
      // row 2 wins
      [7, 8, 9, 10],
      [8, 9, 10, 11],
      [9, 10, 11, 12],
      [10, 11, 12, 13],
      // row 3 wins
      [14, 15, 16, 17],
      [15, 16, 17, 18],
      [16, 17, 18, 19],
      [17, 18, 19, 20],
      // row 4 wins
      [21, 22, 23, 24],
      [22, 23, 24, 25],
      [23, 24, 25, 26],
      [24, 25, 26, 27],
      // row 5 wins
      [28, 29, 30, 31],
      [29, 30, 31, 32],
      [30, 31, 32, 33],
      [31, 32, 33, 34],
      //row 6 wins
      [35, 36, 37, 38],
      [36, 37, 38, 39],
      [37, 38, 39, 40],
      [38, 39, 40, 41],

      // colum 1 wins
      [0, 7, 14, 21],
      [7, 14, 21, 28],
      [14, 21, 28, 35],
      // colum 2 wins
      [1, 8, 15, 22],
      [8, 15, 22, 29],
      [15, 22, 29, 36],
      // colum 3 wins
      [2, 9, 16, 23],
      [9, 16, 23, 30],
      [16, 23, 30, 37],
      // colum 4 wins
      [3, 10, 17, 24],
      [10, 17, 24, 31],
      [17, 24, 31, 38],     
      // colum 5 wins
      [4, 11, 18, 25],
      [11, 18, 25, 32],
      [18, 25, 32, 39], 
      // colum 6 wins
      [5, 12, 19, 26],
      [12, 19, 26, 33],
      [19, 26, 33, 40], 
      // colum 7 wins
      [6, 13, 20, 27],
      [13, 20, 27, 34],
      [20, 27, 34, 41],

      // Left to right dialong wins
      [14, 22, 30, 38],
      [7, 15, 23, 31],
      [15, 23, 31, 39],
      [0, 8, 16, 24],
      [8, 16, 24, 32],
      [16, 24, 32, 40],
      [2, 10, 18, 26],
      [10, 18, 26, 34],
      [3, 11, 19, 27],
      // Right to left dialong wins
      [21, 15, 9, 3],
      [28, 22, 16, 10],
      [22, 16, 10, 4],
      [35, 29, 23, 17],
      [29, 23, 17, 11],
      [23, 17, 11, 5],
      [37, 31, 25, 19],
      [31, 25, 19, 13],
      [38, 32, 26, 20]
    ];

    // Loops through possible win scenarios from the lines array
    for (let i = 0; i < lines.length; i++) {
      const [a, b, c, d] = lines[i];
      // Checks if any squares meet the scenarios
      if (squares[a] && squares[a] === squares[b] && squares[a] === squares[c] && squares[a] === squares[d]) {
        // returns square[a]
        return squares[a];
      }
    }
    // Checks to see if the board is always field
    if(squares[0] && squares[1] && squares[2] && squares[3] && squares[4] && squares[5] && squares[6]){
        // returns a tie
        return "tie";
    }
    //else
    return null;
  }