package com.example.cs3270a3_trevoregbert;

import android.os.Bundle;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;
import androidx.fragment.app.FragmentManager;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_main);
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });

        // Adds the toolbar to the top of the app
        Toolbar toolbar = findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        // Creates a fragment manager
        FragmentManager manager = getSupportFragmentManager();

        // Loads the game fragment into its container
        manager.beginTransaction()
                .replace(R.id.GameFragmentContainer, new FragmentGame())
                .commit();

        // Loads the game fragment into its container
        manager.beginTransaction()
                .replace(R.id.RecordFragmentContainer, new FragmentScore())
                .commit();
    }
}