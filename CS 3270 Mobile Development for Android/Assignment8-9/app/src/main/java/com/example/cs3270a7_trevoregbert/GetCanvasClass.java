package com.example.cs3270a7_trevoregbert;

import android.os.Handler;
import android.os.Looper;
import android.util.Log;

import com.example.cs3270a7_trevoregbert.db.Authorization;
import com.example.cs3270a7_trevoregbert.db.Course;
import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.concurrent.Executor;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

public class GetCanvasClass {

    private final ExecutorService executorService = Executors.newSingleThreadExecutor();
    private final Handler handler = new Handler(Looper.getMainLooper());
    private String rawJSON;
    private OnCourseListImport listener;

    public interface  OnCourseListImport {
        void completedCourseList(Course[] courses);
    }

    public void setOnCourseListImportListener(OnCourseListImport listenerFromMain)
    {
        listener = listenerFromMain;
    }

    public void fetchCourse()
    {
        executorService.execute(() -> {
            try{
                URL url = new URL("https://canvas.instructure.com/api/v1/courses");
                HttpURLConnection connection = (HttpURLConnection) url.openConnection();
                connection.setRequestProperty("Authorization", "Bearer " + Authorization.AUTH_TOKEN);
                connection.connect();

                int status = connection.getResponseCode();

                if(status == 200)
                {
                    BufferedReader bufferedReader = new BufferedReader(new InputStreamReader(connection.getInputStream()));
                    rawJSON = bufferedReader.readLine();
                    Log.d("GetCanvasClass", "Fetched JSON: " + rawJSON);
                }

                final Course[] courses = parseJson();
                handler.post(() -> {
                    if(listener != null) {
                        listener.completedCourseList(courses);
                    }
                });

            } catch (Exception e) {
                Log.d("GetCanvasClasses", "Error fetching courses: " + e.toString());
            }
        });
    }

    private Course[] parseJson()
    {
        Gson gson = new GsonBuilder().create();
        Course[] courses = null;
        try {
            courses = gson.fromJson(rawJSON, Course[].class);
        } catch (Exception e){
            Log.d("GetCanvasClasses", "Error parsing JSON: " + e.toString());
        }
        return courses;
    }
}
