package com.example.cs3270a4_trevoregbert;

import android.os.Bundle;

import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        // If there is no saved data
        if (savedInstanceState == null) {
            // Loads the fragments into there corresponding containers
            replaceFragment(R.id.TotalsContainer, new TotalsFragment());
            replaceFragment(R.id.TaxContainer, new TaxFragment());
            replaceFragment(R.id.ItemsContainer, new ItemsFragment());
        }
    }


    /**
     * Replace the container with a fragment
     *
     * @param container:   The id of the container
     * @param replacement: The fragment to be loaded into the container
     */

    private void replaceFragment(int container, Fragment replacement) {
        FragmentManager manager = getSupportFragmentManager();

        manager.beginTransaction()
                .replace(container, replacement)
                .commit();
    }
}