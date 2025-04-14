package com.example.cs3270a2_trevoregbert;

import android.os.Bundle;
import android.widget.Button;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;

public class MainActivity extends AppCompatActivity {

    private FragmentManager manager;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        manager = getSupportFragmentManager();
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_main);
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });

        // Switches a new Fragment A with frameContainer 1
        SwitchFragment(R.id.fragmentContainer1, new FragmentA());

        // Gets button LoadFragment2
        Button btnLoadFrag2 = findViewById(R.id.LoadFragment2);
        // When button is clicked switches a new Fragment B with frameContainer 2
        btnLoadFrag2.setOnClickListener(v ->
                SwitchFragment(R.id.fragmentContainer2, new FragmentB())
        );

        // Gets button LoadFragment3
        Button btnLoadFrag3 = findViewById(R.id.LoadFragment3);
        // When button is clicked switches a new Fragment C with frameContainer 3
        btnLoadFrag3.setOnClickListener(v ->
                SwitchFragment(R.id.fragmentContainer3, new FragmentC())
        );

        // Gets button LoadFragment4
        Button btnLoadFrag4 = findViewById(R.id.LoadFragment4);
        // When button is clicked switches a new Fragment C with frameContainer 3
        btnLoadFrag4.setOnClickListener(v ->
                SwitchFragment(R.id.fragmentContainer4, new FragmentD())
        );

        // Gets button Switch 3 and 4
        Button btnSwitch3and4 = findViewById(R.id.Switch3and4);
        btnSwitch3and4.setOnClickListener(v -> {
            // When button is clicked switches Fragment d and c
            SwitchFragment(R.id.fragmentContainer3, new FragmentD());
            SwitchFragment(R.id.fragmentContainer4, new FragmentC());
        });


    }

    /**
     *  Switches the loadLocation with the Fragment the gets passed in
     *
     * @param loadLocation: The id of the location of the replacement
     * @param frag: The Fragment that will replace the loadLocation
     */
    private void SwitchFragment(int loadLocation, Fragment frag)
    {
        // Uses the FragmentManager to replace the loadLocation with frag
        manager.beginTransaction()
                .replace(loadLocation, frag)
                .addToBackStack(null)
                .commit();
    }
}