package com.example.cs3270a5_trevoregbert;

import android.os.Bundle;

import androidx.fragment.app.Fragment;
import androidx.lifecycle.ViewModelProvider;


import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

/**
 * A simple {@link Fragment} subclass.
 * create an instance of this fragment.
 */
public class ChangeButtons extends Fragment{

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View view = inflater.inflate(R.layout.fragment_change_buttons, container, false);
        // Gets the viewModel for the app
        AppViewModel viewModel = new ViewModelProvider(requireActivity()).get(AppViewModel.class);

        // Creates a listener that check what button is pressed
        View.OnClickListener listener = v -> {
            if (v.getId() == R.id.btn_50)
            {
                viewModel.updateChangeMade(50.00);
            }
            else if (v.getId() == R.id.btn_20)
            {
                viewModel.updateChangeMade(20.00);
            }
            else if (v.getId() == R.id.btn_10)
            {
                viewModel.updateChangeMade(10.00);
            }
            else if (v.getId() == R.id.btn_5)
            {
                viewModel.updateChangeMade(5.00);
            }
            else if (v.getId() == R.id.btn_1)
            {
                viewModel.updateChangeMade(1.00);
            }
            else if (v.getId() == R.id.btn_c50)
            {
                viewModel.updateChangeMade(0.50);
            }
            else if (v.getId() == R.id.btn_c25)
            {
                viewModel.updateChangeMade(0.25);
            }
            else if (v.getId() == R.id.btn_c10)
            {
                viewModel.updateChangeMade(0.10);
            }
            else if (v.getId() == R.id.btn_c05)
            {
                viewModel.updateChangeMade(0.05);
            }
            else if (v.getId() == R.id.btn_c01)
            {
                viewModel.updateChangeMade(0.01);
            }

        };

        // Adds the listener to each button
        view.findViewById(R.id.btn_50).setOnClickListener(listener);
        view.findViewById(R.id.btn_20).setOnClickListener(listener);
        view.findViewById(R.id.btn_10).setOnClickListener(listener);
        view.findViewById(R.id.btn_5).setOnClickListener(listener);
        view.findViewById(R.id.btn_1).setOnClickListener(listener);
        view.findViewById(R.id.btn_c50).setOnClickListener(listener);
        view.findViewById(R.id.btn_c25).setOnClickListener(listener);
        view.findViewById(R.id.btn_c10).setOnClickListener(listener);
        view.findViewById(R.id.btn_c05).setOnClickListener(listener);
        view.findViewById(R.id.btn_c01).setOnClickListener(listener);

        return view;
    }



}