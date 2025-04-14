package com.example.cs3270a7_trevoregbert.db;

import android.content.Context;

import androidx.room.Database;
import androidx.room.Room;
import androidx.room.RoomDatabase;

@Database(entities = {Course.class}, version = 2, exportSchema = false)
public abstract class AppDatabase extends RoomDatabase {
    // Holds the instance of the database
    private static AppDatabase instance;

    /**
     * Gets the instance of the database
     * @param context: context of the app
     * @return the instance of the database
     */
    public static AppDatabase getInstance(Context context)
    {
        if (instance == null) {
            instance = Room.databaseBuilder(context, AppDatabase.class, "user-database")
                    .build();
        }
        return instance;
    }

    public abstract  CourseDAO courseDAO();
}
