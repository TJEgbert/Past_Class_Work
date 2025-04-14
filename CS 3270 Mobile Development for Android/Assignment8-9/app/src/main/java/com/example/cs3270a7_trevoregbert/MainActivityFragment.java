package com.example.cs3270a7_trevoregbert;

import android.content.Context;
import android.os.Bundle;

import androidx.fragment.app.Fragment;
import androidx.lifecycle.ViewModelProvider;
import androidx.recyclerview.widget.GridLayoutManager;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import java.util.ArrayList;


public class MainActivityFragment extends Fragment {
    // Holds the RecyclerView
    private RecyclerView recyclerView;
    // Holds the Adapter
    private CourseRecyclerViewAdapter courseRecyclerViewAdapter;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View view = inflater.inflate(R.layout.fragment_main, container, false);
        recyclerView = view.findViewById(R.id.recycler_view);
        return view;
    }

    @Override
    public void onResume() {
        super.onResume();

        Context context = getContext();
        // Create a new CourseRecyclerViewAdapter
        courseRecyclerViewAdapter = new CourseRecyclerViewAdapter(new ArrayList<>());

        // Get the number of course in the list
        int columnCount = courseRecyclerViewAdapter.getItemCount();

        // Sets the type of layout fragment
        if (columnCount <= 1) {
            recyclerView.setLayoutManager(new LinearLayoutManager(context));
        } else {
            recyclerView.setLayoutManager(new GridLayoutManager(context, columnCount));
        }

        // Finishes setting up recyclerView
        recyclerView.setAdapter(courseRecyclerViewAdapter);
        recyclerView.setHasFixedSize(false);

        // Gets the view
        AllCourseViewModel view = new ViewModelProvider(this).get(AllCourseViewModel.class);
        // Sets up an observer
        view.getCourseList(context).observe(this, courses -> {
            if (courses != null) {
                // Adds the course courseRecyclerViewAdapter
                courseRecyclerViewAdapter.addItems(courses);
            }
        });
    }
}