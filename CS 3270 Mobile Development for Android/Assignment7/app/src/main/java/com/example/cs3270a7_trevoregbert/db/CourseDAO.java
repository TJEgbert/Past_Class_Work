package com.example.cs3270a7_trevoregbert.db;

import androidx.room.Dao;
import androidx.room.Delete;
import androidx.room.Insert;
import androidx.room.Query;
import androidx.room.Update;

import java.util.List;

@Dao
public interface CourseDAO {

    // Retrieve a list of courses
    @Query("select * from Course")
    List<Course> getAll();

    // View the details of a selected course
    @Query("select * from Course where cid = :id")
    List<Course> getByID(int id);

    // Edit a selected course
    @Update()
    void update(Course course);

    // Delete a selected course
    @Delete
    void delete(Course course);

    // Add a course
    @Insert
    void insert(Course... courses);
}
