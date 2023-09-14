SELECT 
	SUM(w1.DepositAmount - w2.DepositAmount) AS [Difference]
FROM WizzardDeposits AS w1
	LEFT JOIN WizzardDeposits AS w2 ON w1.Id = w2.Id - 1