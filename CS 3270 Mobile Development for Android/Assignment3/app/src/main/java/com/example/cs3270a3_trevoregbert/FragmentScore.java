package com.example.cs3270a3_trevoregbert;

import android.os.Bundle;

import androidx.fragment.app.Fragment;
import androidx.lifecycle.Observer;
import androidx.lifecycle.ViewModelProvider;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;


/**
 * A simple {@link Fragment} subclass.
 */
public class FragmentScore extends Fragment {

    // Used to display the number of games played
    private TextView gamesDisplay;
    // Used to display the number of times the computer has won
    private TextView computerDisplay;
    // Used to display the number of time the player has won
    private TextView playerDisplay;
    // Used to display the number of games tied
    private TextView tieDisplay;

    // Tracks the total number of games
    private int games = 0;
    // Tracks the number of times the computer has won
    private int computerWins = 0;
    // Tracks the number of times the player has won
    private int playerWins = 0;
    // Tracks the number of times a game was a tie
    private int tieGames = 0;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Stores the viewModel
        GameViewModel viewModel = new ViewModelProvider(requireActivity()).get(GameViewModel.class);
        // Creates the view
        View view = inflater.inflate(R.layout.fragment_score, container, false);

        // Sets up an observer to track the winner
        final Observer<String> winnerObserver = this::updateScoreBoard;
        // Watches to see if winner is updated in the viewModel
        viewModel.getWinner().observe(getViewLifecycleOwner(), winnerObserver);

        // Gets the TextViews used to updated the display
        gamesDisplay = view.findViewById(R.id.plays_counter);
        computerDisplay = view.findViewById(R.id.phone_wins);
        playerDisplay = view.findViewById(R.id.player_wins);
        tieDisplay = view.findViewById(R.id.tie_games);

        // Gets the reset button and sets up a listener
        Button btnReset = view.findViewById(R.id.btnReset);
        btnReset.setOnClickListener(v -> resetBoard());

        return view;
    }

    /**
     * Checks the winner and updates the totals accordingly
     *
     * @param winner: The player that won the game
     */
    private void updateScoreBoard(String winner) {
        switch (winner) {
            case "player":
                playerWins++;
                break;
            case "computer":
                computerWins++;
                break;
            default:
                tieGames++;
        }
        games++;
        updateDisplays();
    }

    /**
     * Updates all game stats related TextViews
     */
    private void updateDisplays() {
        gamesDisplay.setText(String.valueOf(games));
        computerDisplay.setText(String.valueOf(computerWins));
        playerDisplay.setText(String.valueOf(playerWins));
        tieDisplay.setText(String.valueOf(tieGames));
    }

    /**
     * Resets all game related trackers to zero
     */
    private void resetBoard() {
        games = 0;
        computerWins = 0;
        playerWins = 0;
        tieGames = 0;

        updateDisplays();

        // Sets up and display a toast letting the user now the game was reset
        int duration = Toast.LENGTH_SHORT;
        Toast.makeText(this.getContext() , "Game was reset", duration).show();
    }
}