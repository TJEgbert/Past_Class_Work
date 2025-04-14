package com.example.cs3270a7_trevoregbert;

import android.annotation.SuppressLint;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.RecyclerView;

import com.example.cs3270a7_trevoregbert.db.Course;

import java.util.List;

public class CourseRecyclerViewAdapter extends RecyclerView.Adapter<CourseRecyclerViewAdapter.ViewHolder> {

    // Holds the list of courses
    public final List<Course> courses;

    // Holds the ViewAdapter
    public CourseRecyclerViewAdapter(List<Course> courses) {
        this.courses = courses;
    }

    /**
     * Adds new courses to this.courses
     *
     * @param courses: List of courses
     */
    @SuppressLint("NotifyDataSetChanged")
    public void addItems(List<Course> courses) {
        // Clears and adds all courses
        this.courses.clear();
        this.courses.addAll(courses);
        // Notifies that course list has changed
        notifyDataSetChanged();
    }

    /**
     * Creates the card the displays course information
     */
    public static class ViewHolder extends RecyclerView.ViewHolder {
        // Holds the view
        public View view;
        // Holds the course to display
        public Course course;
        // Holds the TextView components from the layout
        public TextView txtCourseName, txtCourseId, txtCourseCode, txtCourseStart, txtCourseEnd;

        /**
         * Constructor for ViewHolder and sets the TextView components
         *
         * @param itemView: View related to the card layout
         */
        public ViewHolder(@NonNull View itemView) {
            super(itemView);
            view = itemView;
            txtCourseName = view.findViewById(R.id.r_course_name);
            txtCourseId = view.findViewById(R.id.r_course_id);
            txtCourseCode = view.findViewById(R.id.r_course_code);
            txtCourseStart = view.findViewById(R.id.r_course_start_at);
            txtCourseEnd = view.findViewById(R.id.r_course_end_at);
        }
    }


    /**
     * Inflates the new recycledItem view
     *
     * @param parent   The ViewGroup into which the new View will be added after it is bound to
     *                 an adapter position.
     * @param viewType The view type of the new View.
     * @return The newly create ViewHolder
     */
    @NonNull
    @Override
    public CourseRecyclerViewAdapter.ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext())
                .inflate(R.layout.recycler_item, parent, false);
        return new ViewHolder(view);
    }

    /**
     * Sets the contents and OnClickListener for the ViewHolder
     *
     * @param holder   The ViewHolder which should be updated to represent the contents of the
     *                 item at the given position in the data set.
     * @param position The position of the item within the adapter's data set.
     */
    @Override
    public void onBindViewHolder(@NonNull CourseRecyclerViewAdapter.ViewHolder holder, int position) {
        // Gets the course for the passed position
        final Course course = courses.get(position);

        // If the course exists
        if (course != null) {
            // Sets UI elements
            holder.txtCourseName.setText(course.getName());
            holder.txtCourseId.setText(course.getCourse_number());
            holder.txtCourseCode.setText(course.getCourse_code());
            holder.txtCourseStart.setText(course.getStart_at());
            holder.txtCourseEnd.setText(course.getEnd_at());
        }

        // Sets the OnClickListener
        holder.view.setOnClickListener(v -> {
            // Creates a bundle and places the database id of the course in there
            Bundle bundle = new Bundle();
            assert course != null;
            bundle.putInt("course_pk", course.getCid());

            // Creates a courseDetailsFragment and attaches the bundle
            CourseDetailsFragment courseDetailsFragment = new CourseDetailsFragment();
            courseDetailsFragment.setArguments(bundle);

            // Switches fragments out in the content container
            AppCompatActivity activity = (AppCompatActivity) v.getContext();
            activity.getSupportFragmentManager()
                    .beginTransaction()
                    .add(android.R.id.content, courseDetailsFragment)
                    .addToBackStack("edit")
                    .commit();
        });
    }

    @Override
    public int getItemCount() {
        return courses.size();
    }
}
