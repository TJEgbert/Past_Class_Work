package com.example.cs3270a7_trevoregbert;

import android.content.Context;

import androidx.lifecycle.LiveData;
import androidx.lifecycle.ViewModel;

import com.example.cs3270a7_trevoregbert.db.AppDatabase;
import com.example.cs3270a7_trevoregbert.db.Course;

import java.util.List;

public class AllCourseViewModel extends ViewModel {
    private LiveData<List<Course>> courseList;

    public LiveData<List<Course>> getCourseList(Context c) {
        if (courseList != null) {
            return courseList;
        }
        return courseList = AppDatabase.getInstance(c).courseDAO().getAll();
    }

    public void setCourseList(LiveData<List<Course>> courseList) {
        this.courseList = courseList;
    }
}
