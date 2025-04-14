package com.example.cs3270a5_trevoregbert;

import android.os.Bundle;

import androidx.fragment.app.Fragment;
import androidx.lifecycle.Observer;
import androidx.lifecycle.ViewModelProvider;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.TextView;

/**
 * A simple {@link Fragment} subclass.
 * create an instance of this fragment.
 */
public class ChangeActions extends Fragment {
    // Holds the TextView to display number of successful change made
    private TextView winsDisplay;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View view = inflater.inflate(R.layout.fragment_change_actions, container, false);

        // Gets the TextView
        winsDisplay = view.findViewById(R.id.correct_display);

        // Gets the viewModel of the app
        AppViewModel viewModel = new ViewModelProvider(requireActivity()).get(AppViewModel.class);

        // Creates on observer that will updateWinDisplay
        final Observer<Integer> winTotalsObserver = this::updateWinDisplay;
        // Watches for when getWinsCount is called
        viewModel.getWinsCount().observe(getViewLifecycleOwner(), winTotalsObserver);

        // Gets the reset button and adds a listener
        Button resetButton = view.findViewById(R.id.reset_btn);
        resetButton.setOnClickListener(v -> viewModel.resetChange());

        // Gets the reset button and adds a listener
        Button newAmountButton = view.findViewById(R.id.newAmount_btn);
        newAmountButton.setOnClickListener(v -> viewModel.newAmount());

        return view;
    }


    /**
     * Used to update winsDisplay text
     *
     * @param wins: int the number of wins
     */
    private void updateWinDisplay(int wins) {
        winsDisplay.setText(String.valueOf(wins));
    }


}