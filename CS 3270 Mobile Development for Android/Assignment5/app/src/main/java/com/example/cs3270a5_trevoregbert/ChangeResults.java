package com.example.cs3270a5_trevoregbert;

import android.app.AlertDialog;
import android.os.Bundle;

import androidx.fragment.app.Fragment;
import androidx.lifecycle.Observer;
import androidx.lifecycle.ViewModelProvider;

import android.os.CountDownTimer;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import java.util.Locale;
import java.util.Random;

/**
 * A simple {@link Fragment} subclass.
 * create an instance of this fragment.
 */
public class ChangeResults extends Fragment {

    // Holds the CountDownTimer
    private CountDownTimer timer;
    // Holds the textView used to display the change to be made
    private TextView changeDisplay;
    // Holds the textView used to display the change that as been made
    private TextView madeChangeDisplay;
    // Holds the apps ViewModel
    private AppViewModel viewModel;
    // Holds the dollar range of the possible change that can be made
    private int dollarRange;
    //  Holds the change that is being made
    private double changeAmount;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        dollarRange = 100;
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View view = inflater.inflate(R.layout.fragment_change_results, container, false);
        // Gets the view model of the app
        viewModel = new ViewModelProvider(requireActivity()).get(AppViewModel.class);

        // Get the TextViews for display
        changeDisplay = view.findViewById(R.id.change_display);
        madeChangeDisplay = view.findViewById(R.id.made_change_display);

        // Creates the needed observers
        final Observer<Double> changeTotalObserver = this::updateTotalDisplay;
        final Observer<Integer> dollarRangeObserver = this::setDollarRange;
        final Observer<Boolean> restObserver = this::resetTimer;
        final Observer<Boolean> newAmountObserver = this::newAmount;

        // Adding the observers functions from viewModels
        viewModel.getDollarAmount().observe(getViewLifecycleOwner(), dollarRangeObserver);
        viewModel.getReset().observe(getViewLifecycleOwner(), restObserver);
        viewModel.getNewAmount().observe(getViewLifecycleOwner(), newAmountObserver);
        viewModel.getMadeChange().observe(getViewLifecycleOwner(), changeTotalObserver);

        // Gets the textView for the timer
        TextView timerDisplay = view.findViewById(R.id.remaining_time_display);
        // Creates new timer
        timer = new CountDownTimer(30000, 1000) {
            // Updates the timer display every tick
            @Override
            public void onTick(long millisUntilFinished) {
                String text = String.valueOf(millisUntilFinished / 1000);
                timerDisplay.setText(text);
            }

            @Override
            public void onFinish() {
                // Display an alert once the timer is done
                alertMessage("You should try again", "You took to long");
            }
        };

        updateChangeAmount();
        return view;
    }

    @Override
    public void onStop() {
        super.onStop();
        timer.cancel();
    }

    /**
     * Gets called when a new amount button is clicked
     */
    private void newAmount(boolean flip) {
        updateChangeAmount();
        resetTimer(true);
    }

    /**
     * Used to get a new change amount and update display
     */
    private void updateChangeAmount() {
        timer.cancel();
        // Get a new random change amount
        Random rand = new Random();
        int dollarAmount = rand.nextInt(dollarRange);
        double coins = rand.nextDouble();
        changeAmount = Math.floor((dollarAmount + coins) * 100) / 100;

        // Zero our change made in viewModel
        viewModel.zeroChangeMade();
        // Update displays
        String formattedChange = "$" + formatDouble(changeAmount);
        changeDisplay.setText(formattedChange);

        // Restart timer
        timer.start();
    }

    /**
     * Handles the update total change made
     */
    private void updateTotalDisplay(double amount) {
        // Gets the string representation of amount and update the display
        String total = formatDouble(amount);
        String displayTotal = "$" + total;
        madeChangeDisplay.setText(displayTotal);

        // Checks if the player has made correct change
        if (Double.parseDouble(total) == changeAmount) {
            viewModel.gameWon();
            alertMessage("You did it!", "You were able to make the correct change");
            timer.cancel();
        } else if (Double.parseDouble(total) > changeAmount) {
            // If player goes over the amount
            alertMessage("That's to much change", "you should try again");
            timer.cancel();
        }
    }

    /**
     * Create an alert from the passed in variables
     *
     * @param title:   The title of the alert
     * @param message: THe message for the alert
     */
    private void alertMessage(String title, String message) {
        AlertDialog.Builder builder = new AlertDialog.Builder(getActivity());
        builder.setMessage(message)
                .setTitle(title)
                .setPositiveButton("Ok", (dialog, which) -> {
                    updateChangeAmount();
                    timer.start();
                });
        AlertDialog dialog = builder.create();
        dialog.show();
    }

    /**
     * Formats the passed in double to to two decimal places
     *
     * @param num: formated with two decimal places
     */
    private String formatDouble(double num) {
        return String.format(Locale.US, "%.2f", num);
    }

    /**
     * Update the dollar range and calls updateChangeAmount
     *
     * @param value: the new dollar range
     */
    private void setDollarRange(int value) {
        dollarRange = value;
        timer.cancel();
        updateChangeAmount();
    }

    /**
     * Stops and then starts the timer
     */
    private void resetTimer(boolean flip) {
        timer.cancel();
        timer.start();
    }
}