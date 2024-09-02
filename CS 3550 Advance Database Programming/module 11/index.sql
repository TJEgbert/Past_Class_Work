USE NorthWind;

SELECT * FROM Customers
WHERE Phone = '0621-08460';

/*
1. I would create a nonclusted index for the phone numbers
*/

GO

CREATE NONCLUSTERED INDEX PhoneNumber
	ON Customers(Phone);