package com.example.cs3270a4_trevoregbert;

import android.os.Bundle;

import androidx.fragment.app.Fragment;
import androidx.lifecycle.ViewModelProvider;

import android.text.Editable;
import android.text.TextWatcher;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;

/**
 * A simple {@link Fragment} subclass.
 * create an instance of this fragment.
 */
public class ItemsFragment extends Fragment {

    // Holds EditText for the first item
    private EditText item1;
    // Holds EditText for the second item
    private EditText item2;
    // Holds EditText for the third item
    private EditText item3;
    // Holds EditText for the fourth item
    private EditText item4;
    // Holds the AppViewModel
    private AppViewModel viewModel;


    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Creates the view
        View view = inflater.inflate(R.layout.fragment_items, container, false);
        // Get the AppViewModel for this app
        viewModel = new ViewModelProvider(requireActivity()).get(AppViewModel.class);

        // Get the EditTexts for the corresponding private variables
        item1 = view.findViewById(R.id.item1);
        item2 = view.findViewById(R.id.item2);
        item3 = view.findViewById(R.id.item3);
        item4 = view.findViewById(R.id.item4);

        // Adds TextChangedListener to item1
        item1.addTextChangedListener(new TextWatcher() {
            // When text changes in the EditText
            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {
                calculateAmount();
            }

            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {
            }

            @Override
            public void afterTextChanged(Editable s) {
            }
        });

        // Adds TextChangedListener to item2
        item2.addTextChangedListener(new TextWatcher() {
            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {
                calculateAmount();
            }

            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {
            }

            @Override
            public void afterTextChanged(Editable s) {
            }
        });

        // Adds TextChangedListener to item3
        item3.addTextChangedListener(new TextWatcher() {
            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {
                calculateAmount();
            }

            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {
            }

            @Override
            public void afterTextChanged(Editable s) {
            }
        });

        // Adds TextChangedListener to item4
        item4.addTextChangedListener(new TextWatcher() {
            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {
                calculateAmount();
            }

            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {
            }

            @Override
            public void afterTextChanged(Editable s) {
            }
        });

        return view;
    }

    /**
     * Calculates the total amount entered into the item displays
     */
    private void calculateAmount() {
        double itemTotal = 0;
        if (isNumber(String.valueOf(item1.getText()))) {
            itemTotal += Double.parseDouble(String.valueOf(item1.getText()));
        }
        if (isNumber(String.valueOf(item2.getText()))) {
            itemTotal += Double.parseDouble(String.valueOf(item2.getText()));
        }
        if (isNumber(String.valueOf(item3.getText()))) {
            itemTotal += Double.parseDouble(String.valueOf(item3.getText()));
        }
        if (isNumber(String.valueOf(item4.getText()))) {
            itemTotal += Double.parseDouble(String.valueOf(item4.getText()));
        }

        viewModel.setItemTotal(itemTotal);
    }

    /**
     * Checks if a string is a number of not
     *
     * @param str: The string to check if its a number
     */
    public static boolean isNumber(String str) {
        try {
            Double.parseDouble(str);
            return true;
        } catch (NumberFormatException e) {
            return false;
        }
    }
}