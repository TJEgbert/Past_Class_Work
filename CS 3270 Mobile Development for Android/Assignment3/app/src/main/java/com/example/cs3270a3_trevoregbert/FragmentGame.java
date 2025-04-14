package com.example.cs3270a3_trevoregbert;

import android.os.Bundle;

import androidx.fragment.app.Fragment;
import androidx.lifecycle.ViewModelProvider;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.TextView;

import java.util.Random;


/**
 * A simple {@link Fragment} subclass.
 * create an instance of this fragment.
 */
public class FragmentGame extends Fragment {

    // Used to communicate with the other fragment
    private GameViewModel viewModel;
    // Used to display the players choice
    private TextView playerDisplay;
    // Used to display the computer choice
    private TextView computerDisplay;
    // Used to display who's won the game
    private TextView winnerDisplay;
    // Holds the option the computer has to choose from
    private final String[] computerAnswers = {"rock", "paper", "scissors"};


    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Gets the viewModel
        viewModel = new ViewModelProvider(requireActivity()).get(GameViewModel.class);
        // Creates the view
        View view = inflater.inflate(R.layout.fragment_game, container, false);

        // Gets the TextViews used to updated the display
        playerDisplay = view.findViewById(R.id.player_pick);
        computerDisplay = view.findViewById(R.id.computer_pick);
        winnerDisplay = view.findViewById(R.id.game_status);

        // Gets the button for rock
        Button btnRock = view.findViewById(R.id.btnRock);
        // Listens for if the user clicks the rock button and sets winner in the viewModel
        btnRock.setOnClickListener(v -> viewModel.setWinner(gameLogic("rock")));

        // Gets the button for paper
        Button btnPaper = view.findViewById(R.id.btnPaper);
        // Listens for if the user clicks the paper button and sets winner in the viewModel
        btnPaper.setOnClickListener(v -> viewModel.setWinner(gameLogic("paper")));

        // Gets the button for scissors
        Button btnScissors = view.findViewById(R.id.btnScissors);
        // Listens for if the user clicks the paper button and sets winner in the viewModel
        btnScissors.setOnClickListener(v -> viewModel.setWinner(gameLogic("scissors")));

        return view;
    }

    /**
     * Handles the game logic for rock, paper, scissors
     * @param playerChoice : the name of the action the user chose
     * @return winner: the winner of the rock, paper, scissor game
     */
    private String gameLogic(String playerChoice)
    {
        // Set up variables to be used in function
        String winner;
        // Creates a random number generator and get a number from 0-2
        Random ranGenerator = new Random();
        int index = ranGenerator.nextInt(computerAnswers.length);
        // Uses the generated number to get the computers choice
        String computerChoice = computerAnswers[index];
        // Updates the display
        updateDisplay(playerChoice, computerChoice);

        // If the game was a tie
        if(playerChoice.equals(computerChoice))
        {
            winner = "tie";
        }
        // If the player wins
        else if ((playerChoice.equals("rock") && computerChoice.equals("scissors")) ||
                (playerChoice.equals("paper") && computerChoice.equals("rock")) ||
                (playerChoice.equals("scissors") && computerChoice.equals("paper")))
        {
            winner = "player";

        }
        else // computer wins
        {
            winner = "computer";
        }
        // Updates who won message
        updateWinner(winner);

        return winner;
    }

    /**
     * Updates the display of the players and computers choice
     * @param player: Players choice
     * @param computer: Computers choice
     */
    private void updateDisplay(String player, String computer)
    {
        // Updates the corresponding TextViews
        playerDisplay.setText(player.toUpperCase());
        computerDisplay.setText(computer.toUpperCase());
    }

    /**
     * Updates the winner TextView
     * @param whoWon: The person who won at rock, paper, scissors
     */
    private void updateWinner(String whoWon)
    {
        // Gets the message variable ready
        String message;
        // Checks who has won
        switch (whoWon)
        {
            case "player":
                message = "YOU WIN";
                break;
            case "computer":
                message = "YOU LOSE";
                break;
            default:
                message = "TIE";
        }
        // Updates the winner display TextView
        winnerDisplay.setText(message);
    }
}