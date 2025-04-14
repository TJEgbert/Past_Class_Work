package com.example.cs3270a5_trevoregbert;

import android.os.Bundle;
import android.text.InputType;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.appcompat.widget.Toolbar;
import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import androidx.lifecycle.ViewModelProvider;


public class MainActivity extends AppCompatActivity {

    // Holds a the ChangeButtons fragment
    private ChangeButtons changeButtons;
    // Holds a the ChangeActions fragment
    private ChangeActions changeActions;
    // Holds a the ChangeActions fragment
    private ChangeResults changeResults;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        Toolbar titleBar = findViewById(R.id.title_bar);
        setSupportActionBar(titleBar);


        // If there is no saved data
        if (savedInstanceState == null) {
            // Loads the fragments into there corresponding containers
            changeButtons = new ChangeButtons();
            changeActions = new ChangeActions();
            changeResults = new ChangeResults();
            // Loads fragments in there respective containers
            replaceFragment(R.id.change_results_container, changeResults);
            replaceFragment(R.id.change_buttons_container, changeButtons);
            replaceFragment(R.id.change_actions_container, changeActions);
        }
    }

    /**
     * Creates the menu for the option menu
     *
     * @param menu: the menu to loaded into the option menu
     */
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.main_menu, menu);
        return true;
    }

    /**
     * Handles when a menu option is clicked
     *
     * @param item: The option that was selected from the menu
     */
    @Override
    public boolean onOptionsItemSelected(MenuItem item) {

        // If the Zero current count is clicked
        if (item.getItemId() == R.id.zero_correct_Count) {
            // Zeros out wins count
            AppViewModel viewModel = new ViewModelProvider(this).get(AppViewModel.class);
            viewModel.zeroWinsCount();
        } // If set change max is clicked
        else if (item.getItemId() == R.id.set_max) {
            // Creates a new fragment
            SetMaxAdjustment fragment = new SetMaxAdjustment();
            // Passes in base three fragments
            fragment.setFragment(changeResults, changeButtons, changeActions);
            // Sets the new fragment in change results container
            replaceFragment(R.id.change_results_container, fragment);
        }

        return true;
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


    /**
     * A fragment containing the logic to update Max change amount
     */
    public static class SetMaxAdjustment extends Fragment {
        // Holds a the ChangeResults fragment to load when closed
        private ChangeResults results;
        // Holds a the ChangeButtons fragment to hide and show
        private ChangeButtons buttons;
        // Holds a the ChangeActions fragment to hide and show
        private ChangeActions actions;

        @Override
        public View onCreateView(@NonNull LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
            // Creates the layout of of the fragment
            LinearLayout parent = new LinearLayout(getActivity());
            parent.setOrientation(LinearLayout.VERTICAL);

            // Creates the contents for the  layout
            TextView title = new TextView(getActivity());
            title.setText(R.string.set_change_max);
            TextView subTitle = new TextView(getActivity());
            subTitle.setText(R.string.maximum_change_amount);
            EditText textField = new EditText(getActivity());
            textField.setInputType(InputType.TYPE_CLASS_NUMBER);
            Button save = getButton(textField);

            // Adds all the contents to the parent
            parent.addView(title);
            parent.addView(subTitle);
            parent.addView(textField);
            parent.addView(save);

            // Hides the actions and buttons fragments
            FragmentManager manger = requireActivity().getSupportFragmentManager();
            manger.beginTransaction()
                    .hide(actions)
                    .hide(buttons)
                    .commit();

            return parent;
        }

        /**
         * Creates a button to handle updated the Max Change amount
         *
         * @param textField: Used to get the amount to chang to
         */

        @NonNull
        private Button getButton(EditText textField) {
            // Creates the button and set its text
            Button save = new Button(getActivity());
            save.setText(R.string.save);
            // If the button is clicked
            save.setOnClickListener(v -> {
                // Gets the viewModel to update the max change amount
                AppViewModel viewModel = new ViewModelProvider(requireActivity()).get(AppViewModel.class);
                int amount = Integer.parseInt(String.valueOf(textField.getText()));
                viewModel.setDollarAmount(amount);
                // Display hidden fragments and puts the results fragment back
                FragmentManager manger = requireActivity().getSupportFragmentManager();
                manger.beginTransaction()
                        .show(actions)
                        .show(buttons)
                        .replace(R.id.change_results_container, results)
                        .commit();

            });
            return save;
        }

        /**
         * Sets the private variables
         *
         * @param results: the result fragment to switch back to
         * @param buttons: the buttons fragment to be hidden
         * @param actions: the actions fragment to be hidden
         */
        public void setFragment(ChangeResults results, ChangeButtons buttons, ChangeActions actions) {
            this.results = results;
            this.buttons = buttons;
            this.actions = actions;
        }
    }


}