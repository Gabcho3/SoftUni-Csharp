function formatGrade(grade){
    if (grade < 3) { return 'Fail' + ` (${Math.floor(grade)})`; }
    if (grade >= 3 && grade < 3.50) { return 'Poor' + ` (${grade.toFixed(2)})`; }
    if (grade > 3.50 && grade < 4.50) { return 'Good' + ` (${grade.toFixed(2)})`; }
    if (grade >= 4.50 && grade < 5.50) { return 'Very good' + ` (${grade.toFixed(2)})`; }
    if (grade >= 5.50) { return 'Excellent' + ` (${grade.toFixed(2)})`; } 
}
