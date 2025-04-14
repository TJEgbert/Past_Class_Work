package com.example.cs3270a4_trevoregbert;

import androidx.lifecycle.MutableLiveData;
import androidx.lifecycle.ViewModel;

public class AppViewModel extends ViewModel {

    // Tracks the grand total in the app
    private MutableLiveData<Double> total;
    // Tracks the total tax amount in the app
    private MutableLiveData<Double> taxTotal;
    // Keeps tracks the current taxRate from the TaxFragment
    private int taxRate;
    // Keeps tracks the current item total from the TotalsFragment
    private double itemTotal;

    /**
     * Constructor sets all variables to defaults
     */
    public AppViewModel() {
        this.total = new MutableLiveData<>();
        this.taxTotal = new MutableLiveData<>();
        this.taxRate = 0;
        this.itemTotal = 0;
    }

    /**
     * Setter for total
     *
     * @param amount: The current total amount
     */
    public void setTotal(double amount) {
        this.total.setValue(amount);
    }

    /**
     * Returns the grand total from the app
     *
     * @return double total
     */
    public MutableLiveData<Double> getTotal() {
        if (total == null) {
            this.total = new MutableLiveData<>();
        }

        return this.total;
    }

    /**
     * Setter for taxTotal
     *
     * @param amount: The current amount from taxes
     */
    public void setTaxTotal(double amount) {
        this.taxTotal.setValue(amount);
    }

    /**
     * Returns the total from taxes from the app
     *
     * @return double taxTotal
     */
    public MutableLiveData<Double> getTaxTotal() {
        if (taxTotal == null) {
            this.taxTotal = new MutableLiveData<>();
        }

        return this.taxTotal;
    }

    /**
     * Setter for itemTotal
     *
     * @param amount: The current amount from all items
     */
    public void setItemTotal(double amount) {
        this.itemTotal = amount;
        this.calculateTotal();
    }

    /**
     * Setter for taxRate
     *
     * @param amount: the current tax rate
     */
    public void setTaxRate(int amount) {
        this.taxRate = amount;
        this.calculateTotal();
    }

    /**
     * Calculates the new grand total and updates
     * TaxTotal and Total
     */
    private void calculateTotal() {
        double percent = (double) taxRate / 100;
        double taxAmount = itemTotal * percent;
        this.setTaxTotal(taxAmount);
        this.setTotal(itemTotal + taxAmount);

    }

}
