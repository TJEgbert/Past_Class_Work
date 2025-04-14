package com.example.cs3270a7_trevoregbert;

import android.os.Bundle;
import androidx.fragment.app.Fragment;

import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;

import com.example.cs3270a7_trevoregbert.db.AppDatabase;
import com.example.cs3270a7_trevoregbert.db.Course;
import com.google.android.material.textfield.TextInputEditText;

import java.util.List;
import java.util.Objects;

public class CourseEditFragment extends Fragment {

    // Attributes to hold all the different TextInputEditText
    private TextInputEditText textCourseNumber, textCourseName,
            textCourseCode, textStartAt, textEndAt;

    // Attribute that holds the view
    private View view;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        view = inflater.inflate(R.layout.fragment_course_edit, container, false);

        return view;
    }

    @Override
    public void onResume() {
        super.onResume();

        // Loads all attributes with there layout components
        textCourseNumber = view.findViewById(R.id.text_course_id);
        textCourseName = view.findViewById(R.id.text_course_name);
        textCourseCode = view.findViewById(R.id.text_course_code);
        textStartAt = view.findViewById(R.id.text_start_at);
        textEndAt = view.findViewById(R.id.text_end_at);
        Button btnSave = view.findViewById(R.id.submit_button);

        // Sets up the button onClickListener
        btnSave.setOnClickListener(v -> {
            final String cNumber = Objects.requireNonNull(textCourseNumber.getText()).toString();
            final String cName = Objects.requireNonNull(textCourseName.getText()).toString();
            final String cCode = Objects.requireNonNull(textCourseCode.getText()).toString();
            final String cStart = Objects.requireNonNull(textStartAt.getText()).toString();
            final String cEnd = Objects.requireNonNull(textEndAt.getText()).toString();

            // Sets TextInputEditText to empty strings
            textCourseCode.setText("");
            textCourseNumber.setText("");
            textCourseName.setText("");
            textCourseCode.setText("");
            textStartAt.setText("");
            textEndAt.setText("");

            // Creates a new thread
            new Thread(() -> {
                /*.getInstance: Gets the instance of the database
                   .courseDAO: Gets the course table
                   .insert: insert a new Course object into the database */
                AppDatabase.getInstance(getContext())
                        .courseDAO()
                        .insert(new Course(cNumber, cName, cCode, cStart, cEnd));

                /*.getInstance: Gets the instance of the database
                   .courseDAO: Gets the course table
                   .getAll: insert a new Course object into the database */
                List<Course> courses = AppDatabase.getInstance(getContext())
                        .courseDAO()
                        .getAll();

                Log.d("Course", "_____________Start_____________________");
                for (Course c:courses)
                {
                    Log.d("Course", c.toString());
                }
                Log.d("Course", "______________End_____________________");
            }).start();
        });


    }
}