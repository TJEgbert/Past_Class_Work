package com.example.cs3270a3_trevoregbert;

import android.app.FragmentManager;
import android.util.Log;

import androidx.lifecycle.MutableLiveData;
import androidx.lifecycle.ViewModel;

public class GameViewModel extends ViewModel {
    private MutableLiveData<String> winner;

    public GameViewModel() {
        this.winner = new MutableLiveData<String>();
    }

    public void setWinner(String who_won)
    {
        winner.setValue(who_won);
    }

    public MutableLiveData<String> getWinner() {
        if(winner == null)
        {
            winner = new MutableLiveData<>();
        }
        return winner;
    }

}
