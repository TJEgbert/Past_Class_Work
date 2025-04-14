package com.example.cs3270a5_trevoregbert;

import androidx.lifecycle.MutableLiveData;
import androidx.lifecycle.ViewModel;

public class AppViewModel extends ViewModel {

    private MutableLiveData<Double> madeChange;
    private MutableLiveData<Integer> dollarAmount;

    private MutableLiveData<Integer> winsCount;

    private MutableLiveData<Boolean> reset;
    private MutableLiveData<Boolean> newAmount;

    private double changeMade;
    private int totalWins;

    public MutableLiveData<Boolean> getNewAmount() {
        if (newAmount == null)
        {
            newAmount = new MutableLiveData<>();
        }
        return newAmount;
    }

    public void newAmount() {
        boolean flip = Boolean.TRUE.equals(newAmount.getValue());
        flip = !flip;
        newAmount.setValue(flip);

    }

    public MutableLiveData<Boolean> getReset() {
        if (reset == null)
        {
            reset = new MutableLiveData<>();
        }
        return reset;
    }

    public void resetChange() {
        boolean flip = Boolean.TRUE.equals(reset.getValue());
        flip = !flip;
        zeroChangeMade();
        reset.setValue(flip);

    }

    public void gameWon()
    {
        totalWins++;
        setWinsCount(totalWins);
    }
    public MutableLiveData<Integer> getWinsCount() {
        if(winsCount == null)
        {
            this.winsCount = new MutableLiveData<>();
        }
        return winsCount;
    }

    public void setWinsCount(int winsCount) {
        this.winsCount.setValue(winsCount);
    }

    public MutableLiveData<Integer> getDollarAmount() {
        if(dollarAmount == null)
        {
            this.dollarAmount = new MutableLiveData<>();
        }
        return dollarAmount;
    }

    public void setDollarAmount(int dollarAmount) {
        this.dollarAmount.setValue(dollarAmount);
    }

    public AppViewModel()
    {
        this.madeChange = new MutableLiveData<>();
        changeMade = 0;
    }

    public void setMadeChange(double madeChange)
    {
        this.madeChange.setValue(madeChange);
    }

    public MutableLiveData<Double> getMadeChange()
    {
        if (madeChange == null)
        {
            this.madeChange = new MutableLiveData<>();
        }
        return this.madeChange;
    }

    public void updateChangeMade(double amount)
    {
        changeMade += amount;
        setMadeChange(changeMade);
    }

    public void zeroChangeMade()
    {
        changeMade = 0;
        setMadeChange(changeMade);
    }

    public void zeroWinsCount()
    {
        totalWins = 0;
        setWinsCount(0);
    }

}
