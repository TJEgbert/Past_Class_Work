package com.example.cs3270a7_trevoregbert;

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

import com.example.cs3270a7_trevoregbert.db.AppDatabase;
import com.example.cs3270a7_trevoregbert.db.Course;
import com.google.android.material.textfield.TextInputEditText;

import java.util.Objects;


public class NewCourseDialog extends DialogFragment {

    // Holds the view
    View view;
    // Holds the ToolBar from the layout
    Toolbar toolbar;
    // Holds the TextView components from the layout
    private TextInputEditText textCourseNumber, textCourseName,
            textCourseCode, textStartAt, textEndAt;

    // Holds editing course
    private Course course;


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        view = inflater.inflate(R.layout.fragment_new_course_dialog, container, false);

        // Get the components from the layout
        toolbar = view.findViewById(R.id.new_course_toolbar);
        textCourseNumber = view.findViewById(R.id.new_text_course_id);
        textCourseName = view.findViewById(R.id.new_text_course_name);
        textCourseCode = view.findViewById(R.id.new_text_course_code);
        textStartAt = view.findViewById(R.id.new_text_start_at);
        textEndAt = view.findViewById(R.id.new_text_end_at);

        // Set up the toolbar as ActionBar for the fragment
        ((AppCompatActivity) requireActivity()).setSupportActionBar(toolbar);
        ActionBar actionBar = ((AppCompatActivity) requireActivity()).getSupportActionBar();
        assert actionBar != null;
        actionBar.setHomeButtonEnabled(true);

        // Creating the Menu provider to handle menu options
        MenuProvider provider = new MenuProvider() {
            @Override
            public void onCreateMenu(@NonNull Menu menu, @NonNull MenuInflater menuInflater) {
                // Clears the menu and inflates a new one from menu_create_dialog
                menu.clear();
                menuInflater.inflate(R.menu.menu_create_dialog, menu);
            }

            @Override
            public boolean onMenuItemSelected(@NonNull MenuItem menuItem) {
                // If the save button is pressed
                if (menuItem.getItemId() == R.id.menu_save) {
                    // Creates a new thread
                    new Thread(() -> {
                        // If the user creating a new course
                        if (course == null) {
                            // Create a new course object
                            Course tempCourse = new Course(
                                    Objects.requireNonNull(textCourseNumber.getText()).toString(),
                                    Objects.requireNonNull(textCourseName.getText()).toString(),
                                    Objects.requireNonNull(textCourseCode.getText()).toString(),
                                    Objects.requireNonNull(textStartAt.getText()).toString(),
                                    Objects.requireNonNull(textEndAt.getText()).toString()
                            );
                            // Adds the course to the database
                            AppDatabase.getInstance(getContext())
                                    .courseDAO()
                                    .insert(tempCourse);
                        } else // User is editing a fragment
                        {
                            // Updates the course with the new entered information
                            course.setCourse_number(Objects.requireNonNull(textCourseNumber.getText()).toString());
                            course.setName(Objects.requireNonNull(textCourseName.getText()).toString());
                            course.setCourse_code(Objects.requireNonNull(textCourseCode.getText()).toString());
                            course.setStart_at(Objects.requireNonNull(textStartAt.getText()).toString());
                            course.setEnd_at(Objects.requireNonNull(textEndAt.getText()).toString());
                            // Updates course in database
                            AppDatabase.getInstance(getContext())
                                    .courseDAO()
                                    .update(course);
                        }
                    }).start();
                }
                // Dismiss DialogFragment
                dismiss();
                // Takes the menu control
                return true;
            }
        };

        // Finishes setting up menu
        MenuHost host = requireActivity();
        host.addMenuProvider(provider, getViewLifecycleOwner());
        actionBar.setHomeAsUpIndicator(android.R.drawable.ic_menu_close_clear_cancel);
        actionBar.setDisplayHomeAsUpEnabled(true);

        // Get the bundle
        Bundle bundle = this.getArguments();

        // If there is a bundle
        if (bundle != null) {
            // Changes title of the toolbar
            toolbar.setTitle("Edit Course");
            // Creates a nwe thread
            new Thread(() -> {
                // Get the course from the database
                course = AppDatabase.getInstance(getContext())
                        .courseDAO()
                        .getByID(bundle.getInt("course_pk"));

                // Updates the UI withe the course information
                requireActivity().runOnUiThread(() -> {
                    textCourseNumber.setText(course.getCourse_number());
                    textCourseName.setText(course.getName());
                    textCourseCode.setText(course.getCourse_code());
                    textStartAt.setText(course.getStart_at());
                    textEndAt.setText(course.getEnd_at());
                });
            }).start();
        }
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