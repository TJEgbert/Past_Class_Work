package com.example.cs3270a4_trevoregbert;

import android.os.Bundle;

import androidx.fragment.app.Fragment;
import androidx.lifecycle.Observer;
import androidx.lifecycle.ViewModelProvider;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import java.util.Locale;

/**
 * A simple {@link Fragment} subclass.
 * create an instance of this fragment.
 */
public class TotalsFragment extends Fragment {

    // Holds TextView used to display the total amount
    private TextView totalDisplay;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Creates the view
        View view = inflater.inflate(R.layout.fragment_totals, container, false);
        // Get the AppViewModel for this app
        AppViewModel viewModel = new ViewModelProvider(requireActivity()).get(AppViewModel.class);

        // Gets the TextView
        totalDisplay = view.findViewById(R.id.total_label);

        // Sets up the observer to call UpdateAmount
        final Observer<Double> amountObserver = this::UpdateAmount;
        // Watches for when getTotal is called
        viewModel.getTotal().observe(getViewLifecycleOwner(), amountObserver);

        return view;
    }

    /**
     * Update the display to show the total amount from modelView
     */
    private void UpdateAmount(Double amount)
    {
        String displayAmount = "$" + String.format(Locale.US,"%.2f", amount);
        totalDisplay.setText(displayAmount);
    }
}