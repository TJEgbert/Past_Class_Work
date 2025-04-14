package com.example.cs3270a4_trevoregbert;

import android.os.Bundle;

import androidx.fragment.app.Fragment;
import androidx.lifecycle.Observer;
import androidx.lifecycle.ViewModelProvider;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.SeekBar;
import android.widget.TextView;

import java.util.Locale;

/**
 * A simple {@link Fragment} subclass.
 * create an instance of this fragment.
 */
public class TaxFragment extends Fragment {

    // Holds the AppViewModel
    private AppViewModel viewModel;

    // Holds the Textview that displays the tax rate
    private TextView taxRateDisplay;
    //Holds the Textview that displays the total tax amount
    private TextView taxTotalDisplay;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Creates the view
        View view = inflater.inflate(R.layout.fragment_tax, container, false);

        // Get the AppViewModel for this app
        viewModel = new ViewModelProvider(requireActivity()).get(AppViewModel.class);
        // Gets the seekbar used to adjust tax rate
        SeekBar taxBar = view.findViewById(R.id.seek_bar);

        // Gets the TextViews
        taxRateDisplay = view.findViewById(R.id.tax_rate_percent);
        taxTotalDisplay = view.findViewById(R.id.tax_amount_display);

        // Sets up the observer to call updateTaxTotal
        final Observer<Double> taxAmountObserver = this::updateTaxTotal;
        // Watches for when getTaxTotal is called
        viewModel.getTaxTotal().observe(getViewLifecycleOwner(), taxAmountObserver);

        // Sets up the ChangeListener on the SeekBar
        taxBar.setOnSeekBarChangeListener(new SeekBar.OnSeekBarChangeListener() {
            // When the progress bar changes
            @Override
            public void onProgressChanged(SeekBar seekBar, int progress, boolean fromUser) {
                updateTaxInfo(progress);
            }

            @Override
            public void onStartTrackingTouch(SeekBar seekBar) {
            }

            @Override
            public void onStopTrackingTouch(SeekBar seekBar) {
            }
        });

        return view;
    }


    /**
     * Updates the taxRate display and calculate the new totals
     *
     * @param taxRate: The new tax rate
     */
    private void updateTaxInfo(int taxRate) {
        // Updates the taxRateDisplay
        String displayString = taxRate + ".00%";
        taxRateDisplay.setText(displayString);

        // Updates the tax rate in the view model
        viewModel.setTaxRate(taxRate);
    }

    /**
     * Updates the display to show the tax amount
     *
     * @param amount: The tax amount
     */
    private void updateTaxTotal(double amount) {
        String displayAmount = "$" + String.format(Locale.US, "%.2f", amount);
        taxTotalDisplay.setText(displayAmount);
    }
}