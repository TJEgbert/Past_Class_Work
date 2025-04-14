package com.example.cs3270a7_trevoregbert;

import android.os.Bundle;
import android.util.Log;
import android.view.View;

import com.example.cs3270a7_trevoregbert.db.AppDatabase;
import com.example.cs3270a7_trevoregbert.db.Course;
import com.google.android.material.floatingactionbutton.FloatingActionButton;

import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;
import androidx.fragment.app.FragmentManager;

import java.util.concurrent.Executor;
import java.util.concurrent.Executors;

public class MainActivity extends AppCompatActivity {

    // Holds the FragmentManager of the app
    private FragmentManager fm;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        // Sets contentView to main activity layout
        setContentView(R.layout.activity_main);

        // Sets up the ToolBar
        Toolbar toolbar = findViewById(R.id.title_bar);
        setSupportActionBar(toolbar);

        // Gets the floating button and set up an OnClickListener
        FloatingActionButton fab = findViewById(R.id.fab);
        fab.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                fm = getSupportFragmentManager();
                // Swaps out content with a newCourseDialog
                fm.beginTransaction()
                        .add(android.R.id.content, new NewCourseDialog())
                        .addToBackStack("main")
                        .commit();

                GetCanvasClass task = new GetCanvasClass();
                task.setOnCourseListImportListener( courses -> {
                    for (Course c: courses) {
                        Log.d("MainActivity", "completedCourseList: " + c.toString());
                        Executors.newSingleThreadExecutor().execute(() -> {
                            AppDatabase.getInstance(getBaseContext())
                                    .courseDAO()
                                    .insert(c);
                        });
                    }
                });
                task.fetchCourse();
            }
        });
    }

}