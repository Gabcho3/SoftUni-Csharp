function checkIfPositiveOrNegative(...numbers){
    let countOfNegativeNumbers = 0;

    let isNegative = (num) => { return num < 0; }
    numbers.forEach(num => { if(isNegative(num)) { countOfNegativeNumbers++; } });

    return countOfNegativeNumbers === 2 || countOfNegativeNumbers === 0 ? 'Positive' : 'Negative';
}
console.log(checkIfPositiveOrNegative(5, 12, -15)); //Negative