package com.example.cs3270a7_trevoregbert;

import android.app.AlertDialog;
import android.app.Dialog;
import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.ActionBar;
import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;
import androidx.core.view.MenuHost;
import androidx.core.view.MenuProvider;
import androidx.fragment.app.DialogFragment;

import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.view.Window;
import android.widget.TextView;

import com.example.cs3270a7_trevoregbert.db.AppDatabase;
import com.example.cs3270a7_trevoregbert.db.Course;


public class CourseDetailsFragment extends DialogFragment {

    // Holds the view
    private View view;
    // Holds the textview components from the layout
    private TextView textCourseNumber, textCourseName,
            textCourseCode, textStartAt, textEndAt;

    // The course to show the details about
    private Course course;

    // The database id of the course
    private int course_pk;


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        view = inflater.inflate(R.layout.fragment_course_details, container, false);

        // Load components from layout
        Toolbar toolbar = view.findViewById(R.id.detail_course_toolbar);
        textCourseNumber = view.findViewById(R.id.detail_text_course_id);
        textCourseName = view.findViewById(R.id.detail_text_course_name);
        textCourseCode = view.findViewById(R.id.detail_text_course_code);
        textStartAt = view.findViewById(R.id.detail_text_start_at);
        textEndAt = view.findViewById(R.id.detail_text_end_at);

        // Get the bundle
        Bundle bundle = this.getArguments();
        // Checks if data was sent
        if (bundle != null) {
            // Gets the course database ID
            course_pk = bundle.getInt("course_pk");
            // Creates a thread
            new Thread(() -> {
                // Gets the course from the database
                course = AppDatabase.getInstance(getContext())
                        .courseDAO()
                        .getByID(course_pk);
                // Update UI elements
                textCourseNumber.setText(course.getCourse_number());
                textCourseName.setText(course.getName());
                textCourseCode.setText(course.getCourse_code());
                textStartAt.setText(course.getStart_at());
                textEndAt.setText(course.getEnd_at());
            }).start();
        }

        // Sets toolbar to the ActionBar for the fragment
        ((AppCompatActivity) requireActivity()).setSupportActionBar(toolbar);
        ActionBar actionBar = ((AppCompatActivity) requireActivity()).getSupportActionBar();
        assert actionBar != null;
        actionBar.setHomeButtonEnabled(true);

        // Creating the Menu provider to handle menu options
        MenuProvider provider = new MenuProvider() {
            @Override
            public void onCreateMenu(@NonNull Menu menu, @NonNull MenuInflater menuInflater) {
                // Clears the menu and inflates a new one from menu_course_details
                menu.clear();
                requireActivity().getMenuInflater().inflate(R.menu.menu_course_details, menu);
            }

            @Override
            public boolean onMenuItemSelected(@NonNull MenuItem menuItem) {
                // If the edit button is pressed
                if (menuItem.getItemId() == R.id.menu_edit) {
                    // Creates a bundle with the course database id
                    Bundle bundle = new Bundle();
                    bundle.putInt("course_pk", course.getCid());

                    // Creates NewCourseDialog and adds the bundle to the arguments
                    NewCourseDialog courseEditFragment = new NewCourseDialog();
                    courseEditFragment.setArguments(bundle);

                    // Get the activity and updates content container with the new fragment
                    AppCompatActivity activity = (AppCompatActivity) view.getContext();
                    activity.getSupportFragmentManager()
                            .beginTransaction()
                            .add(android.R.id.content, courseEditFragment)
                            .addToBackStack(null)
                            .commit();

                    // Dismisses the dialogFragment
                    dismiss();
                    // Takes the menu input
                    return true;
                } else if (menuItem.getItemId() == R.id.menu_delete) {
                    // If the delete button is pressed

                    // Asks user if there are sure they want to delete the course
                    new AlertDialog.Builder(getContext())
                            .setTitle("Delete Confirmation")
                            .setMessage("Do you really want to delete")
                            .setIcon(android.R.drawable.ic_dialog_alert)
                            .setPositiveButton("Yes", (dialogInterface, i) -> {
                                new Thread(() -> AppDatabase.getInstance(getContext())
                                        .courseDAO()
                                        .delete(course)).start();
                                // Dismisses the dialogFragment
                                dismiss();

                            })
                            .setNegativeButton("No", null).show();
                    // Takes the menu input
                    return true;
                }
                else
                {
                    // Dismisses the dialogFragment
                    dismiss();
                    // Takes the menu input
                    return true;
                }
            }
        };
        // Gets the MenuHost
        MenuHost host = requireActivity();
        // Finishes setting up the menu
        host.addMenuProvider(provider, getViewLifecycleOwner());
        actionBar.setHomeAsUpIndicator(android.R.drawable.ic_menu_close_clear_cancel);
        actionBar.setDisplayHomeAsUpEnabled(true);

        return view;
    }

    @NonNull
    @Override
    public Dialog onCreateDialog(@Nullable Bundle savedInstanceState) {

        Dialog dialog = super.onCreateDialog(savedInstanceState);
        dialog.requestWindowFeature(Window.FEATURE_NO_TITLE);
        return dialog;
    }


}